namespace FrontToBack.Models
{
    public class BaseAuditableEntity : BaseEntity
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
