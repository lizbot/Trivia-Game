using Application.Domain;
using Microsoft.Practices.Unity;

namespace Domain.Services.Configuration
{
    public class ApplicationConfiguration
    {
        public static IUnityContainer ConfigureDependencies(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IQuestionService, QuestionService>();

            unityContainer.Resolve<IQuestionService>();

            return unityContainer;
        }
    }
}