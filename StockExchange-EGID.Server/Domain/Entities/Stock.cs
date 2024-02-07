namespace StockExchange_EGID.Server.Domain.Entities
{
    public class Stock
    {
        public Guid Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
