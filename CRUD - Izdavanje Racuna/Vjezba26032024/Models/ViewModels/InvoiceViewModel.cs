using Vjezba26032024.Models.Base;

namespace Vjezba26032024.Models.ViewModels
{
    public class InvoiceViewModel:InvoiceBase
    {
        public int Id { get; set; }
        public List<InvoiceItemViewModel> InvoiceItems { get; set; }
    }
}
