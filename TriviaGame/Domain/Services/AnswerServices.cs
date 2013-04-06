using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Domain;
using Domain.Persistence;
using Domain.Model;
using AutoMapper;



namespace Domain.Services
{
    public class AnswerServices : IAnswerServices
    {
        private readonly IAnswerRepository _AnswerRepository;

        public AnswerServices(IAnswerRepository answerRepository) 
        {
            _AnswerRepository = answerRepository;
        }

    }
}
