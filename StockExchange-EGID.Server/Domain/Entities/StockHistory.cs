namespace StockExchange_EGID.Server.Domain.Entities
{
    public class StockHistory
    {
        public Guid Id { get; set; }
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
