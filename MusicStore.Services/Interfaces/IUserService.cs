using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MusicStore.ViewModels;

namespace MusicStore.Services.Interfaces
{
    public interface IUserService
    {
        SignInResult UserLogin(LoginViewModel loginModel);

        Task<SignInResult> RegisterUser(RegisterViewModel registerModel);

        void Logout();
    }
}