using System;
using System.Collections.Generic;
using Application.Model;
using Domain.Persistence;

namespace Domain.Services
{
    public class OptionsServices
    {

        private IOptionsRepository _OptionsRepository;

        public OptionsServices(IOptionsRepository OptionsRepository)
        {
            _OptionsRepository = OptionsRepository;
        }

        //Get options whether general or Custom Options.
        public CustomOptions GetCustomOptions()
        {
            var CustomOption = _OptionsRepository.GetCustomOptions();
            return CustomOption;
            //throw new NotImplementedException();
        }

        //Gets the general Options
        public GeneralOptions GetGeneralOptions()
        {
            var GeneralOption = _OptionsRepository.GetGeneralOptions();
            return GeneralOption;
            //throw new NotImplementedException();
        }
    }
}
