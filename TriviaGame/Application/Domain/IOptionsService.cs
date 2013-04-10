using Application.Model;

namespace Application.Domain
{
    public interface IOptionsService
    {
        CustomOptions GetCustomOptions();

        GeneralOptions GetGeneralOptions();

        void UpdateCustomOptions(CustomOptions customOption);

        void UpdateGeneralOptions(GeneralOptions generalOption);
    }
}