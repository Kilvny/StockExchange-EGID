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
            _timer = new Timer(UpdateStockPrice, null, TimeSpan.Zero, TimeSpan.FromSeconds(10)); // a 10 seconds timer
        }

        private void UpdateStockPrice(object state)
        {
            UpdateStock("AAPL");
            UpdateStock("GOOGL");
            UpdateStock("MSFT");
            UpdateStock("AMZN");
            UpdateStock("TSLA");
            //// Generating a random price for simplicity
            //decimal price = new Random().Next(101, 113);
            //_stockHub.Clients.All.SendAsync("ReceivePrice", "AAPL", price);
            //_stockHub.Clients.All.SendAsync("ReceivePrice", "GOOGL", price);
            //_stockHub.Clients.All.SendAsync("ReceivePrice", "MSFT", price);
            //_stockHub.Clients.All.SendAsync("ReceivePrice", "AMZN", price);
            //_stockHub.Clients.All.SendAsync("ReceivePrice", "TSLA", price);

        }

        private void UpdateStock(string symbol)
        {
            // Simulating actual price changes and updating the timestamp
            decimal currentPrice = GetCurrentPrice(symbol);
            decimal newPrice = SimulatePriceChange(currentPrice);
            DateTime timestamp = DateTime.UtcNow;


            UpdateDatabase(symbol, newPrice, timestamp);
            // Sending updated price and timestamp to clients
            _stockHub.Clients.All.SendAsync("ReceivedPrice", symbol, newPrice, timestamp);
            _applicationContext.StocksHistories.Add(new StockHistory
            {
                Symbol = symbol,
                Price = newPrice,
                Timestamp = timestamp
            });


        }

        private decimal GetCurrentPrice(string symbol)
        {
            decimal price = _applicationContext.Stocks.AsNoTracking().Where(x => x.Symbol == symbol).FirstOrDefault().Price;
            return price;
        }

        private decimal SimulatePriceChange(decimal currentPrice)
        {
            decimal priceChange = (decimal)new Random().NextDouble() * 2 - 1; // Random change between -1 and 1
            return currentPrice + priceChange;
        }
        private void UpdateDatabase(string symbol, decimal newPrice, DateTime timestamp)
        {
            Stock stock = _applicationContext.Stocks.Where(x => x.Symbol == symbol).FirstOrDefault();
            stock.Price = newPrice;

            // Store the updated stock information in the database
            var stockHistory = new StockHistory
            {
                Symbol = symbol,
                Price = newPrice,
                Timestamp = timestamp
            };

            _applicationContext.Stocks.Update(stock);
            _applicationContext.SaveChanges();
        }
    }
}
