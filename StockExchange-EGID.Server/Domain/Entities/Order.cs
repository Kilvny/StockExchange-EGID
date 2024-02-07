using StockExchange_EGID.Server.Common.Enums;

namespace StockExchange_EGID.Server.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Symbol { get; set; }
        public decimal Price { get; set; } = 0;
        public int Quntity { get; set; }
        public OrderType OrderType { get; set; }
    }
}
