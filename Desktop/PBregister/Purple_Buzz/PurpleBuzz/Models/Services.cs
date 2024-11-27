﻿using System.Diagnostics.CodeAnalysis;

namespace PurpleBuzz.Models
{
    public class Services : BaseAuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Work>? Works { get; set; }
    }
}