using System;
using Application.Domain;
using Application.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    class OptionsServices
    {
        //Get options whether general or Custom Options.
        public IEnumerable<CustomOptionsDto> GetCustomOptions()
        {
            throw new NotImplementedException();
        }

        //Gets the general Options
        public IEnumerable<GeneralOptionsDto> GetGeneralOptions()
        {
            throw new NotImplementedException();
        }

    }
}
