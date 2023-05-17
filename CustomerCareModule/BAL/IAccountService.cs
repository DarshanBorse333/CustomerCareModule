using CustomerCareModule.Models;

namespace CustomerCareModule.BAL
{
    public interface IAccountService
    {
        UserViewModel GetUser(LoginViewModel loginViewModel);
    }
}
