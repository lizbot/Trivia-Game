using Application.Model;
using Domain.Persistence;

namespace Infrastructure.Persistence
{
    public class OptionsRepository : IOptionsRepository 
    {
        public CustomOptions GetCustomOptions()
        {
            throw new System.NotImplementedException();
        }

        public GeneralOptions GetGeneralOptions()
        {
            throw new System.NotImplementedException();
        }
    }
}