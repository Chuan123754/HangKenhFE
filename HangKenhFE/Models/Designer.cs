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
        public MetaData GetMetaData()
        {
            return !string.IsNullOrEmpty(meta_data)
                ? JsonSerializer.Deserialize<MetaData>(meta_data)
                : new MetaData();
        }

        // Serialize MetaData to JSON string
        public void SetMetaData(MetaData data)
        {
            meta_data = JsonSerializer.Serialize(data);
        }
    }
    public class MetaData
    {
        public string? facebook { get; set; }
        public string? twitter { get; set; }
        public string? instagram { get; set; }
        public string? youtube { get; set; }
        public string? tiktok { get; set; }
        public string? linkedin { get; set; }
        public string? pinterest { get; set; }
    }
}
