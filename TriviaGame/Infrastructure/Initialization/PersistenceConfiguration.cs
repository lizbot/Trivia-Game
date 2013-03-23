using System.IO;
using Infrastructure.Persistence;
using Microsoft.Practices.Unity;
using Domain.Persistence;

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

            unityContainer.Resolve<IQuestionRepository>();
            unityContainer.Resolve<IGameRepository>();

            return unityContainer;
        }
    }
}
