using Application.Domain;
using Domain.Persistence;


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
