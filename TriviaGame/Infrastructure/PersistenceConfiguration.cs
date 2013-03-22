using System.IO;
using System.Reflection;

namespace Infrastructure
{
    using Domain.Persistence;
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

  //      public static void ConfigureDependencies(IUnityContainer unityContainer)
  //      {
  //          unityContainer.RegisterType<IQuestionRepository, QuestionRepository>();
  //      }
    }
}
