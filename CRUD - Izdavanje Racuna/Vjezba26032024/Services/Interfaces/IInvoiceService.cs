using Vjezba26032024.Models.Binding;
using Vjezba26032024.Models.ViewModels;

namespace Vjezba26032024.Services.Interfaces
{
    public interface IInvoiceService
    {
        /// <summary>
        /// Update Invoice Item
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        InvoiceItemViewModel UpdateInvoiceItem(InvoiceItemUpdateBinding model);
        /// <summary>
        /// Add invoice Item
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        InvoiceItemViewModel AddInvoiceItem(InvoiceItemBinding model);
        InvoiceViewModel AddInvoice(InvoiceBinding model);
        InvoiceViewModel DeleteInvoice(int id);
        InvoiceViewModel GetInvoice(int id);
        int GetNextInvoiceId();
        List<InvoiceViewModel> GetInvoices();
        bool TryDeleteInvoice(int id);
        InvoiceViewModel UpdateInvoice(InvoiceUpdateBinding model);
        InvoiceItemViewModel DeleteInvoiceItem(int id, int invoiceId);
        /// <summary>
        /// Get invoice item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="invoiceId"></param>
        /// <returns></returns>
        InvoiceItemViewModel GetInvoiceItem(int id, int invoiceId);
    }
}