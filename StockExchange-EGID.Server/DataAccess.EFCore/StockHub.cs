using Microsoft.AspNetCore.SignalR;

namespace StockExchange_EGID.Server.DataAccess.EFCore
{
    public class StockHub : Hub
    {
        public async Task SendPrice(string symbol, decimal price)
        {
            await Clients.All.SendAsync("ReceivePrice", symbol, price);
        }
    }
}
