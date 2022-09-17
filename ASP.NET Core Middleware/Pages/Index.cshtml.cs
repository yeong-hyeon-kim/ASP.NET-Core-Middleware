using ASP.NET_Core_Middleware.Lib.Interfaces;
using ASP.NET_Core_Middleware.Lib.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP.NET_Core_Middleware.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUser _Users;

        public IndexModel(IUser User)
        {
            _Users = User;
        }

        public void OnGet()
        {
            GetUsers();
        }

        public List<User> GetUsers()
        {
            return _Users.GetUser();
        }
    }
}