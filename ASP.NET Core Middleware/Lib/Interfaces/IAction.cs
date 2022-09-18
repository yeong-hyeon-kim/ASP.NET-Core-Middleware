namespace ASP.NET_Core_Middleware.Lib.Interfaces
{
    public interface IAction
    {
        public Guid GetID();
    }

    public interface IActionTransient : IAction { }
    public interface IActionScoped : IAction { }
    public interface IActionSingleton : IAction { }
    public interface IActionSingletonInstance : IAction { }
}
