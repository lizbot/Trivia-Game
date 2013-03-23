using Application.Domain;
using Microsoft.Practices.Unity;

namespace Domain.Services.Configuration
{
    public class DomainConfiguration
    {
        public static IUnityContainer ConfigureDependencies(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IQuestionService, QuestionService>();
            
            return unityContainer;
        }
    }
}