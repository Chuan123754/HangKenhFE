﻿using HangKenhFE.Models.DTO;

namespace HangKenhFE.Models.DTO
{
    public class PostTagDto
    {
        public long Id { get; set; }
        public long PostId { get; set; }
        public long TagId { get; set; }
        public TagDto? Tag { get; set; } // Thông tin chi tiết về Tag
    }
}
