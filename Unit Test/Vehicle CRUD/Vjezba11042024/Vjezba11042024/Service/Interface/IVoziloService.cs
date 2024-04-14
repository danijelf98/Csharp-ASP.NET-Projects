using Vjezba11042024.Models.Binding;
using Vjezba11042024.Models.ViewModel;

namespace Vjezba11042024.Service.Interface
{
    public interface IVoziloService
    {
        VoziloViewModel AddVehicle(VoziloBinding model);
        List<VoziloViewModel> GetAllVehicles();
        VoziloViewModel GetVehicle(int id);
        VoziloViewModel DeleteVehicle(int id);
        VoziloViewModel UpdateVehicle(VoziloUpdateBinding model);
    }
}