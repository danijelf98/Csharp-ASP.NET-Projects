using AutoMapper;
using Vjezba2032024.Models.Binding;
using Vjezba2032024.Models.Dbo;
using Vjezba2032024.Models.ViewModel;

namespace Vjezba2032024.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PolaznikBinding, Polaznik>();
            CreateMap<PolaznikUpdateBinding, Polaznik>();
            CreateMap<Polaznik, PolaznikViewModel>();
            CreateMap<PolaznikViewModel, PolaznikUpdateBinding>();
        }
    }
}
