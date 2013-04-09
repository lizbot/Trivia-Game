using Application.Model;

namespace Domain.Persistence
{
    public interface IOptionsRepository
    {
       CustomOptions GetCustomOptions();

       GeneralOptions GetGeneralOptions();
    }
}
