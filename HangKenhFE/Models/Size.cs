﻿
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HangKenhFE.Models
{
    public class Size
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Slug { get; set; }
        public string? Description { get; set; }
        public bool? Deleted { get; set; }
        public DateTime Create_at { get; set; }
        public DateTime Update_at { get; set; }
        public DateTime Delete_at { get; set; }
        public virtual ICollection<Product_Attributes> Product_Attributes { get; set; } = new List<Product_Attributes>();

    }
}
