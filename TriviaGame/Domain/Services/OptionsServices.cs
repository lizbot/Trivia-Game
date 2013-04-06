using System;
using System.Collections.Generic;
using Application.Model;

namespace Domain.Services
{
    class OptionsServices
    {
        //Get options whether general or Custom Options.
        public IEnumerable<CustomOptions> GetCustomOptions()
        {
            throw new NotImplementedException();
        }

        //Gets the general Options
        public IEnumerable<GeneralOptions> GetGeneralOptions()
        {
            throw new NotImplementedException();
        }

    }
}
