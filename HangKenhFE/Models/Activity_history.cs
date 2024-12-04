﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HangKenhFE.Models
{
    public class Activity_history
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Log_name { get; set; }
        public string Descripcion { get; set; }
        public string Subject_type { get; set; }
        public DateTime Time { get; set; }
        public string AccountId { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }

    }
}
