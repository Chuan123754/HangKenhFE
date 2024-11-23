﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HangKenhFE.Models
{
    [Table("Designer")]
    public class Designer
    {
        [Key]
        public long id_Designer { get; set; }
        public string? Name { get; set; }
        public string? ShortName { get; set; }
        public string? slug { get; set; }
        public string? short_description { get; set; }
        public string? description { get; set; }
        public string? image { get; set; }
        public bool? Deleted { get; set; }
        public string? image_library { get; set; }
        public string? status { get; set; }
        public string? meta_data { get; set; }
        public DateTime create_at { get; set; }
        public DateTime update_at { get; set; }
    }
}
