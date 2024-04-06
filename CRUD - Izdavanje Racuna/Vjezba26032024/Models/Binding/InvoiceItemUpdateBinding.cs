using Vjezba26032024.Models.Base;

namespace Vjezba26032024.Models.Binding
{
    public class InvoiceItemUpdateBinding: InvoiceItemBase
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
    }
}
