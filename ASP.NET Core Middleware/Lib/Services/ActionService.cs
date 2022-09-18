using ASP.NET_Core_Middleware.Lib.Interfaces;

namespace ASP.NET_Core_Middleware.Lib.Services
{
    public class ActionService
    {
        public IActionTransient ActionTransient { get; set; }
        public IActionScoped ActionScoped { get; set; }
        public IActionSingleton ActionSingleton { get; set; }
        public IActionSingletonInstance ActionSingletonInstance { get; set; }

        public ActionService(IActionTransient actionTransient, IActionScoped actionScoped, IActionSingleton actionSingleton, IActionSingletonInstance actionSingletonInstance)
        {
            ActionTransient = actionTransient;
            ActionScoped = actionScoped;
            ActionSingleton = actionSingleton;
            ActionSingletonInstance = actionSingletonInstance;  
        }
    }
}
