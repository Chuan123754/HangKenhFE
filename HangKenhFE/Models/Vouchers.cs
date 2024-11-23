﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using HangKenhFE.Models;

namespace HangKenhFE.Models
{
    public class Vouchers
    {
        [Key]
        public long Id { get; set; }    
        public string? Code { get; set; }
        public string? Description { get; set; }
        public string? Quantity { get; set; }
        public string? Percent { get; set; }
        public string? MaxDiscountValue { get; set; } // giá trị giảm tối đa
        public string? Condition { get; set; }
        public DateTime Create_at { get; set; }
        public DateTime Update_at { get; set; }
        public DateTime Start_time { get; set; }
        public DateTime End_time { get; set; }
        public string? Status { get; set; }

    }
}
