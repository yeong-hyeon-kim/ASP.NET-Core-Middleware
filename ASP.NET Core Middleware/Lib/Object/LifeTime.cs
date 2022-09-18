using ASP.NET_Core_Middleware.Lib.Interfaces;

namespace ASP.NET_Core_Middleware.Lib.Object
{
    public class LifeTime : IActionTransient, IActionScoped, IActionSingleton, IActionSingletonInstance
    {
        public Guid Guid { get; set; }

        public LifeTime()
        {
            Guid = Guid.NewGuid();
        }

        public LifeTime(Guid guid)
        {
            Guid = guid;
        }

        public Guid GetID()
        {
            return Guid;
        }
    }
}
