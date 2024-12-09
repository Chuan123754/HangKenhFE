using System.ComponentModel.DataAnnotations;

namespace HangKenhFE.Models
{
    public class Contact
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage = "Họ tên là bắt buộc.")]
        public string? FullName { get; set; }
        [Required(ErrorMessage = "Email là bắt buộc.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Số điện thoại là bắt buộc.")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "Nội dung là bắt buộc.")]
        public string? Message { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

    }
}
