﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StockExchange_EGID.Server.Domain.Contracts;
using StockExchange_EGID.Server.DataAccess.EFCore;
using StockExchange_EGID.Server.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using StockExchange_EGID.Server.Utilities;
using StockExchange_EGID.Server.Models;

namespace StockExchange_EGID.Server.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ILogger _logger;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public UserRepository(ApplicationContext applicationContext, ILogger logger, UserManager<User> userManager, IConfiguration configuration) 
            : base(applicationContext)
        {
            _logger = logger;
            _userManager = userManager;
            _configuration = configuration;
        }

        public void UpdateUserPassword(User user)
        {

        }

        public new IEnumerable<User> GetAll()
        {
            var users =  _userManager.Users.ToList();
            

            return users;
        }


        public async Task<UserManagerResponse> CreateUserAsync(User user)
        {
            if (user == null)
            {
                throw new NullReferenceException("user  is null");
            }


            var result = await _userManager.CreateAsync(user, user.Password);

            if (!result.Succeeded)
            {
                return new UserManagerResponse
                {
                    Message = "Error while creating the user",
                    StatusCode = 400,
                    IsSuccess = false,
                    Errors = result.Errors.Select(err => err.Description)
                };
            }

            return new UserManagerResponse
            {
                Message = "User Created Successfully",
                StatusCode = 201,
                IsSuccess = true,
            };
        }

        public async Task<UserManagerResponse> LoginUserAsync(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            
            if (user == null)
                return new UserManagerResponse
                {
                    Message = "Email address doesn't exist",
                    IsSuccess = false,
                    StatusCode = 404,
                };

            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!isPasswordCorrect)
                return new UserManagerResponse
                {
                    Message = "Incorrect Password!",
                    IsSuccess = false,
                };

            var claims = new[]
            {
                new Claim("Email", model.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)

            );

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserManagerResponse
            {
                Message = tokenAsString,
                StatusCode = 200,
                IsSuccess = true,
                //ExpireDate = token.ValidTo
            };
        }

    }
}
