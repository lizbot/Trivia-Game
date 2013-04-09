using Application.Model;

namespace Application.Domain
{
    public interface IOptionsService
    {
        CustomOptions GetCustomOptions();

        GeneralOptions GetGeneralOptions();
    }
}