﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace HangKenhFE.Models
{
    [Table("product_variants")]
    public partial class Product_variants
    {
        [Key]
        public long Id { get; set; }
        public long Post_Id { get; set; }
        [StringLength(255)]
        public string? Image { get; set; }
        [StringLength(20)]
        public string? Status { get; set; }
        public string? Description { get; set; }
        public long? Textile_technology_id { get; set; }
        public long? Material_id { get; set; }
        public long? Style_id { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public DateTime? Deleted_at { get; set; }
        [ForeignKey("Post_Id")]
        [JsonIgnore]
        public virtual Product_Posts? Posts { get; set; }
        [ForeignKey("Style_id")]
        [JsonIgnore]
        public virtual Style? Style { get; set; }
        [ForeignKey("Material_id")]
        [JsonIgnore]
        public virtual Material? Material { get; set; }
        [ForeignKey("Textile_technology_id")]
        [JsonIgnore]
        public virtual Textile_technology? Textile_Technology { get; set; }
        [JsonIgnore]
        public virtual ICollection<P_attribute_discount> p_variants_discount { get; set; } = new List<P_attribute_discount>();
        [JsonIgnore]
        public virtual ICollection<Product_variants_wishlist> Product_Variants_Wishlists { get; set; } = new List<Product_variants_wishlist>();
        [JsonIgnore]
        public virtual ICollection<Product_Attributes> Product_Attributes { get; set; } = new List<Product_Attributes>();
    }
}
