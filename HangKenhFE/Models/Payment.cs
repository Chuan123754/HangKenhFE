using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HangKenhFE.Models
{
    public class Payment
    {
        [Key]
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        [JsonIgnore]
        public virtual ICollection<Orders>? Orders { get; set; } = new List<Orders>();
    }

}
