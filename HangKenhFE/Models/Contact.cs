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
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9-]+\.[a-zA-Z]{2,}(?:\.[a-zA-Z]{2,})?$", ErrorMessage = "Email phải hợp lệ (vd: example@gmail.com).")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Số điện thoại là bắt buộc.")]
        [RegularExpression(@"^0\d{9}$", ErrorMessage = "Số điện thoại phải bắt đầu bằng số 0 và có đúng 10 chữ số.")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "Nội dung là bắt buộc.")]
        public string? Message { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

    }
}
