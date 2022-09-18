using ASP.NET_Core_Middleware.Lib.Interfaces;
using ASP.NET_Core_Middleware.Lib.Models;
using ASP.NET_Core_Middleware.Lib.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP.NET_Core_Middleware.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ActionService actionService;
        private readonly IActionTransient actionTransient;
        private readonly IActionScoped actionScoped;
        private readonly IActionSingleton actionSingleton;
        private readonly IActionSingleton actionSingletonInstance;
        private readonly IUser _Users;

        public IndexModel(IUser User,IActionTransient actionTransient, IActionScoped actionScoped, IActionSingleton actionSingleton, IActionSingleton actionSingletonInstance)
        {
            this.actionTransient = actionTransient;
            this.actionScoped = actionScoped;
            this.actionSingleton = actionSingleton;
            this.actionSingletonInstance = actionSingletonInstance;
            _Users = User;
        }

        public void OnGet()
        {
            ViewData["Transient"] = actionTransient;
            ViewData["Scoped"] = actionScoped;
            ViewData["Singleton"] = actionSingleton;
            ViewData["SingletonInstance"] = actionSingletonInstance;

            GetUsers();
        }

        public List<User> GetUsers()
        {
            return _Users.GetUser();
        }
    }
}