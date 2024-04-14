using AutoMapper;
using Vjezba11042024.Models.Binding;
using Vjezba11042024.Models.Dbo;
using Vjezba11042024.Models.ViewModel;

namespace Vjezba11042024.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VoziloUpdateBinding, Vozilo>();
            CreateMap<VoziloBinding, Vozilo>();
            CreateMap<Vozilo, VoziloViewModel>();
        }
    }
}
