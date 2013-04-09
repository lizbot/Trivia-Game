﻿using Application.Domain;
using Application.Model;
using Domain.Persistence;

namespace Domain.Services
{
    public class OptionsService : IOptionsService 
    {

        private readonly IOptionsRepository _OptionsRepository;

        public OptionsService(IOptionsRepository optionsRepository)
        {
            _OptionsRepository = optionsRepository;
        }

        //Get options whether general or Custom Options.
        public CustomOptions GetCustomOptions()
        {
            var customOption = _OptionsRepository.GetCustomOptions();
            return customOption;
        }

        //Gets the general Options
        public GeneralOptions GetGeneralOptions()
        {
            var generalOption = _OptionsRepository.GetGeneralOptions();
            return generalOption;
        }
    }
}