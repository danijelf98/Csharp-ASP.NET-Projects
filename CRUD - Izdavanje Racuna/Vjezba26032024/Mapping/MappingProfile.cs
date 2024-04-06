using AutoMapper;
using Vjezba26032024.Models.Binding;
using Vjezba26032024.Models.Dbo;
using Vjezba26032024.Models.ViewModels;

namespace Vjezba26032024.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<InvoiceBinding, Invoice>();
            CreateMap<InvoiceUpdateBinding, Invoice>();
            CreateMap<Invoice, InvoiceViewModel>();
            CreateMap<InvoiceItemBinding, InvoiceItem>();
            CreateMap<InvoiceItemUpdateBinding, InvoiceItem>();
            CreateMap<InvoiceItem, InvoiceItemViewModel>();

            CreateMap<InvoiceViewModel, InvoiceUpdateBinding>();
            CreateMap<InvoiceItemViewModel, InvoiceItemUpdateBinding>();
        }


    }
}
