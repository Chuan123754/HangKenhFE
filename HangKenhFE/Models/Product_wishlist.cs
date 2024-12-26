﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HangKenhFE.Models
{
    public class Product_wishlist
    {
        [Key]
        public long Id { get; set; }
        public long Product_Posts_Id { get; set; }
        [NotMapped]
        public long? MinPrice { get; set; }

        [NotMapped]
        public long? MaxPrice { get; set; }
        public long Wishlist_id { get; set; }
        [ForeignKey("Product_Posts_Id")]

        public virtual Product_Posts? Product_Posts { get; set; }
        [ForeignKey("Wishlist_id")]
        public virtual Wishlist? Wishlist { get; set; }

    }
}
