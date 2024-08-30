namespace SAOnlineMartMVC.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } // Navigation property
        public int ProductId { get; set; }
        public Product Product { get; set; } // Navigation property
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
