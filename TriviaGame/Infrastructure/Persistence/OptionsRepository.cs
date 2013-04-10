using Application.Model;
using Domain.Persistence;
using System;

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

        public void UpdateGeneralOptions(GeneralOptions options)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomOptions(CustomOptions options)
        {
            throw new NotImplementedException();
        }
    }
}