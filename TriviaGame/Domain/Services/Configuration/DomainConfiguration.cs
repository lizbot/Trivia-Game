using Application.Domain;
using Microsoft.Practices.Unity;

namespace Domain.Services.Configuration
{
    public class DomainConfiguration
    {
        public static IUnityContainer ConfigureDependencies(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IQuestionService, QuestionService>();
            unityContainer.RegisterType<ICategoryService, CategoryService>();
            unityContainer.RegisterType<IGameService, GameService>();
            unityContainer.RegisterType<IOptionsService, OptionsService>();
       //     unityContainer.RegisterType<IStatisticsService, StatisticsService>();
            
            return unityContainer;
        }
    }
}