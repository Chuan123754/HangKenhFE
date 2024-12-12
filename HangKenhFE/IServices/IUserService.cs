﻿using HangKenhFE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HangKenhFE.IServices
{
    public interface IUserService
    {
        Task<List<Users>> GetAll();
        Task<Users> GetById(long id);
        Task<Users> Create(Users user);
        Task Register(Users user);
        Task<Users> Login(Users user, bool rememberMe);
        Task<Users> AutoLogin(string rememberToken);
        Task Logout(long idUser);
        Task Update(Users user);
        Task Delete(long id);
        Task<bool> IsEmailExists(string email); // Kiểm tra email
        Task<bool> IsPhoneExists(string phone); // Kiểm tra số điện thoại
    }
}
