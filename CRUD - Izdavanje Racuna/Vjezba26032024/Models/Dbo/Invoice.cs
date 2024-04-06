using Vjezba26032024.Models.Base;

namespace Vjezba26032024.Models.Dbo
{
    public class Invoice: InvoiceBase
    {
        public int Id { get; set; }
        public List<InvoiceItem> InvoiceItems { get; set; }
    }
}
