using Microsoft.Practices.Unity;

namespace Application.Helpers
{
    public class ApplicationConfiguration
    {
        public static IUnityContainer ConfigureDependencies(IUnityContainer unityContainer)
        {
            return unityContainer;
        }
    }
}