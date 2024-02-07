using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StockExchange_EGID.Server.Common;
using StockExchange_EGID.Server.DataAccess.EFCore;
using StockExchange_EGID.Server.Domain.Entities;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("APIContext") ??
throw new InvalidOperationException("Connections string: APIContext was not found"))
, ServiceLifetime.Singleton);

builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();



// set up signalR service
builder.Services.AddSignalR();
builder.Services.AddSingleton<StockPriceGenerator>();

// set up Jwt auth services
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };

    });

// Add services to the container.
builder.Services.AddControllers(setupAction =>
{
    setupAction.ReturnHttpNotAcceptable = true; // disallow unsupported contentTypes
}).AddXmlDataContractSerializerFormatters();
// Add this service to the container to get run on runtime
builder.Services.ConfigureUnitOfWork();

builder.Services.ConfigureAutoMapper();

builder.Services.AddSwaggerGen(
    c =>
    {
        // configurations to add the authorize lock symbol on Swagger UI
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "EGID-SC API", Version = "v1" });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = @"JWT Authorization header using the Bearer scheme. <BR/>  
                      Enter 'Bearer' [space] and then your token in the text input below.
                      <BR/> Example: 'Bearer 12345abcdef'",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement()
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              },
              Scheme = "oauth2",
              Name = "Bearer",
              In = ParameterLocation.Header,

            },
            new List<string>()
          }
        });
        //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        //c.IncludeXmlComments(xmlPath);
    }
    );

// Add Cors services
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });

    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler(appBuilder =>
    {
        appBuilder.Run(async context =>
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("A Fault occurred in the server. Please Try again later");
        });
    });
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseSwagger();

// This middleware serves the Swagger documentation UI
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "EGID-SC API V1");
    c.RoutePrefix = string.Empty; // swagger UI now is accessible in the root path of the app
});

app.UseCors();

// set up our api to use attribute based routing
// SignalR hub mapping
//app.MapHub<StockHub>("/stockhub");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<StockHub>("/stockhub");
});
// Start the stock price generator
//var stockPriceGenerator = app.Services.GetRequiredService<StockPriceGenerator>();
//stockPriceGenerator.Start();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var stockPriceGenerator = services.GetRequiredService<StockPriceGenerator>();
    stockPriceGenerator.Start();
}

app.Run();
