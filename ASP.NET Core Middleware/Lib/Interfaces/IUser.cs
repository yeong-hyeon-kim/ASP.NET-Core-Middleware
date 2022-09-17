using ASP.NET_Core_Middleware.Lib.Models;

namespace ASP.NET_Core_Middleware.Lib.Interfaces
{
    public interface IUser
    {
        public List<User> GetUser();
    }
}
