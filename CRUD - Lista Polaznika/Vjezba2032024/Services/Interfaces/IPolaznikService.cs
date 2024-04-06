using Vjezba2032024.Models.Binding;
using Vjezba2032024.Models.ViewModel;

namespace Vjezba2032024.Services.Interfaces
{
    public interface IPolaznikService
    {
        List<PolaznikViewModel> DohvatiPolaznike();
        bool ObrisiPolaznika(int id);
        PolaznikViewModel SpremiPolaznika(PolaznikBinding model);
        PolaznikViewModel UrediPolaznika(PolaznikUpdateBinding model);
        /// <summary>
        /// Dohvati polaznika po Idu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PolaznikViewModel DohvatiPolaznika(int id);
    }
}