using System.Diagnostics.CodeAnalysis;

namespace FrontToBack.Models
{
    public class Work : BaseAuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public int ServicesId { get; set; }
        public Services? Services { get; set; }
    }
}
