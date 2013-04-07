using System.IO;
using Domain.Persistence;
using Infrastructure.Persistence;
using Microsoft.Practices.Unity;

namespace Infrastructure.Initialization
{
//    using Microsoft.Practices.Unity;

    public static class PersistenceConfiguration
    {
        public static string ApplicationDirectory { get; set; }

        public static string Database
        {
            get
            {
                return Path.Combine(ApplicationDirectory, "trivia.sqlite");
            }
        }

        public static IUnityContainer ConfigureDependencies(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IQuestionRepository, QuestionRepository>();
            unityContainer.RegisterType<IGameRepository, GameRepository>();
            unityContainer.RegisterType<ICategoryRepository, CategoryRepository>();
            unityContainer.RegisterType<IStatisticsRepository, StatisticsRepository>();
            unityContainer.RegisterType<IOptionsRepository, OptionsRepository>();

            return unityContainer;
        }
    }
}
