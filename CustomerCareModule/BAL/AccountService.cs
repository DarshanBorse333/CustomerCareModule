using CustomerCareModule.DAL;
using CustomerCareModule.Models;

namespace CustomerCareModule.BAL
{
    public class AccountService : IAccountService
    {
        private readonly ProjectContext db;


        public AccountService(ProjectContext _db)
        {
            this.db = _db;
        }
        public UserViewModel GetUser(LoginViewModel loginViewModel)
        {
           

            var user = db.Users.FirstOrDefault(user=>user.Email == loginViewModel.Email
                                     && user.Password == loginViewModel.Password);
            var userViewModel = new UserViewModel();
            if (user != null)
            {
                userViewModel.Name = user.Name;
                userViewModel.Email = user.Email;
                userViewModel.RoleId = user.RoleId;

            }

            return userViewModel;
        }
    }
}
