using ASP.NET_Core_Middleware.Lib.Interfaces;
using ASP.NET_Core_Middleware.Lib.Models;

namespace ASP.NET_Core_Middleware.Lib.Object
{
    public class UserList : IUser
    {
        public List<User> GetUser()
        {
            return new List<User>(){
                new User()
                {
                    Name = "김사장",
                    Email = "sajang@test.co.kr",
                    Age = 1,
                    AccessDateTime = DateTime.Now
                },
                new User()
                {
                    Name = "유영업",
                    Email = "yousale@test.co.kr",
                    Age = 1,
                    AccessDateTime = DateTime.Now
                },
                new User()
                {
                    Name = "백사람",
                    Email = "100saram@test.co.kr",
                    Age = 1,
                    AccessDateTime = DateTime.Now
                }
            };
        }
    }
}
