using BookShop.Web.Enums;

namespace BookShop.Web.Entities;

public class Order
{
        public Guid OrderId { get; set; }
        public Guid BookId { get; set; }
        public virtual Book Book { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public Guid UserId { get; set; }
        public virtual User User{ get; set; }
}