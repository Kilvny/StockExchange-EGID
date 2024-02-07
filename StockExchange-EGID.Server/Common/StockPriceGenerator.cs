using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using StockExchange_EGID.Server.DataAccess.EFCore;
using StockExchange_EGID.Server.Domain.Contracts;
using StockExchange_EGID.Server.Domain.Entities;

namespace StockExchange_EGID.Server.Common
{
    public class StockPriceGenerator
    {
        private readonly IHubContext<StockHub> _stockHub;
        private readonly ApplicationContext _applicationContext;
        private Timer _timer;

        public StockPriceGenerator(IHubContext<StockHub> stockHub, ApplicationContext applicationContext)
        {
            _stockHub = stockHub;
            _applicationContext = applicationContext;
        }
        /// <summary>
        /// Starts the updateStockPrices 
        /// </summary>
        public void Start()
        {
            _timer = new Timer(async state => await UpdateStockPriceAsync(state), null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
            // a 10 seconds timer
        }

        public async Task UpdateStockPriceAsync(object state)
        {
            await UpdateStock("AAPL");
            await UpdateStock("GOOGL");
            await UpdateStock("MSFT");
            await UpdateStock("AMZN");
            await UpdateStock("TSLA");

        }

        private async Task UpdateStock(string symbol)
        {
            // Simulating actual price changes and updating the timestamp
            decimal currentPrice = await GetCurrentPrice(symbol);
            decimal newPrice = SimulatePriceChange(currentPrice);
            DateTime timestamp = DateTime.UtcNow;


            await UpdateDatabase(symbol, newPrice, timestamp);
            // Sending updated price and timestamp to clients
            await _stockHub.Clients.All.SendAsync("ReceivedPrice", symbol, newPrice, timestamp);
            _applicationContext.StocksHistories.Add(new StockHistory
            {
                Symbol = symbol,
                Price = newPrice,
                Timestamp = timestamp
            });


        }

        private async Task<decimal> GetCurrentPrice(string symbol)
        {
  
            decimal price = await _applicationContext.Stocks.Where(x => x.Symbol == symbol).Select(x => x.Price).FirstOrDefaultAsync();
            return price;
        }

        private decimal SimulatePriceChange(decimal currentPrice)
        {
            decimal priceChange = (decimal)new Random().NextDouble() * 2 - 1; // Random change between -1 and 1
            return currentPrice + priceChange;
        }
        private async Task UpdateDatabase(string symbol, decimal newPrice, DateTime timestamp)
        {
            Stock stock = await _applicationContext.Stocks.Where(x => x.Symbol == symbol).FirstOrDefaultAsync();
            stock.Price = newPrice;

            // Store the updated stock information in the database
            var stockHistory = new StockHistory
            {
                Symbol = symbol,
                Price = newPrice,
                Timestamp = timestamp
            };

            _applicationContext.Stocks.Update(stock);
            await _applicationContext.SaveChangesAsync();
        }
    }
}
