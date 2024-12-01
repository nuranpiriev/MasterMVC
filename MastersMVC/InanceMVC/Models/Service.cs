namespace InanceMVC.Models
{
    public class Service : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Master>? Masters { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
