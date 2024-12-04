using HangKenhFE.Models;

namespace HangKenhFE.IServices
{
    public interface ILoginService
    {
        Task<string> SignUp(SignUpModel model);
        Task<string> Login(SignInModel model);
        Task<bool> SignOut();
    }
}
