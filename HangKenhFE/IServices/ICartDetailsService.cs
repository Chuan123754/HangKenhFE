﻿using HangKenhFE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HangKenhFE.IServices
{
    public interface ICartDetailsService
    {
        Task<List<Cart_details>> GetAll();
        Task<Cart_details> GetById(long id);
        Task Create(Cart_details cartDetails);
        Task Update(Cart_details cartDetails);
        Task Delete(long id);
    }
}
