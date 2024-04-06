using AutoMapper;
using Vjezba26032024.Extensions;
using Vjezba26032024.Models.Binding;
using Vjezba26032024.Models.Dbo;
using Vjezba26032024.Models.ViewModels;
using Vjezba26032024.Services.Interfaces;


namespace Vjezba26032024.Services.Implementations
{
    public class InvoiceService : IInvoiceService
    {

        #region StaticValues
        private static List<Invoice> invoices = new List<Invoice>
        {
            new Invoice
            {
                Id = 1,
                DateOfIssue = DateTime.Now.AddDays(-2),
                InvoiceItems = new List<InvoiceItem>
                {
                    new InvoiceItem
                    {
                        Id = 1,
                        Price = 1000,
                        Quantity = 1,
                        Title = "Tv"
                    },
                    new InvoiceItem
                    {
                        Id = 2,
                        Price = 500,
                        Quantity = 1,
                        Title = "PS5"
                    }
                },
                InvoiceNumber = 1.ToDocumentId()
            },
                        new Invoice
            {
                Id = 2,
                DateOfIssue = DateTime.Now.AddDays(-1),
                InvoiceItems = new List<InvoiceItem>
                {
                    new InvoiceItem
                    {
                        Id = 3,
                        Price = 610,
                        Quantity = 2,
                        Title = "AC"
                    },
                    new InvoiceItem
                    {
                        Id = 4,
                        Price = 499,
                        Quantity = 3,
                        Title = "Xbox"
                    }
                },
                InvoiceNumber =2.ToDocumentId()
            }

        };
        #endregion

        private IMapper mapper;

        public InvoiceService(IMapper mapper)
        {
            this.mapper = mapper;
        }


        /// <summary>
        /// Get invoice by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public InvoiceViewModel GetInvoice(int id)
        {
            var invoice = invoices.FirstOrDefault(x => x.Id == id);
            var response = mapper.Map<InvoiceViewModel>(invoice);
            return response;
        }

        /// <summary>
        /// Creates new invoice and adds to static list
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public InvoiceViewModel AddInvoice(InvoiceBinding model)
        {
            var dbo = mapper.Map<Invoice>(model);
            dbo.Id = GetNextInvoiceId();
            dbo.InvoiceNumber = model.InvoiceNumber;

            invoices.Add(dbo);
            //db.SaveChanges();
            return mapper.Map<InvoiceViewModel>(dbo);
        }

        /// <summary>
        /// Fetches all invoices
        /// </summary>
        /// <returns></returns>
        public List<InvoiceViewModel> GetInvoices()
        {
            return invoices.Select(y => mapper.Map<InvoiceViewModel>(y)).ToList();
        }

        /// <summary>
        /// Delete invoice
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public InvoiceViewModel DeleteInvoice(int id)
        {
            var invoice = invoices.FirstOrDefault(x => x.Id == id);
            invoices.Remove(invoice);
            var response = mapper.Map<InvoiceViewModel>(invoice);
            return response;
        }

        /// <summary>
        /// Tries to delete invoice
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool TryDeleteInvoice(int id)
        {
            try
            {
                var invoice = invoices.FirstOrDefault(x => x.Id == id);
                invoices.Remove(invoice);
                return true;
            }
            catch
            {

                return false;
            }
        }

        /// <summary>
        /// Update invoice
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public InvoiceViewModel UpdateInvoice(InvoiceUpdateBinding model)
        {
            var dbo = invoices.FirstOrDefault(x => x.Id == model.Id);
            mapper.Map(model, dbo);
            var response = mapper.Map<InvoiceViewModel>(dbo);
            return response;
        }

        /// <summary>
        /// Delete Invoice Item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="invoiceId"></param>
        /// <returns></returns>
        public InvoiceItemViewModel DeleteInvoiceItem(int id, int invoiceId)
        {
            var invoice = invoices.FirstOrDefault(y => y.Id == invoiceId);
            var invoiceItem = invoice.InvoiceItems.FirstOrDefault(y => y.Id == id);
            invoice.InvoiceItems.Remove(invoiceItem);
            return mapper.Map<InvoiceItemViewModel>(invoiceItem);

        }

        public InvoiceItemViewModel DeleteInvoiceItem(int id)
        {
            InvoiceItemViewModel response = new InvoiceItemViewModel();

            foreach (var invoice in invoices)
            {
                var invoiceItem = invoice.InvoiceItems.FirstOrDefault(y => y.Id == id);
                if (invoiceItem != null)
                {
                    invoice.InvoiceItems.Remove(invoiceItem);
                    response = mapper.Map<InvoiceItemViewModel>(invoiceItem);
                    break;
                }

            }

            return response;

        }

        /// <summary>
        /// Update Invoice Item
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public InvoiceItemViewModel UpdateInvoiceItem(InvoiceItemUpdateBinding model)
        {
            var invoice = invoices.FirstOrDefault(y => y.Id == model.InvoiceId);
            var invoiceItem = invoice.InvoiceItems.FirstOrDefault(y => y.Id == model.Id);
            mapper.Map(model, invoiceItem);
            var response = mapper.Map<InvoiceItemViewModel>(invoiceItem);
            response.InvoiceId = model.InvoiceId;
            return response;

        }


        /// <summary>
        /// Get invoice item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="invoiceId"></param>
        /// <returns></returns>
        public InvoiceItemViewModel GetInvoiceItem(int id, int invoiceId)
        {
            var invoice = invoices.FirstOrDefault(y => y.Id == invoiceId);
            var invoiceItem = invoice.InvoiceItems.FirstOrDefault(y => y.Id == id);
            var response = mapper.Map<InvoiceItemViewModel>(invoiceItem);
            response.InvoiceId = invoiceId;
            return response;

        }

        /// <summary>
        /// Get Invoice item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public InvoiceItemViewModel GetInvoiceItem(int id)
        {
            InvoiceItemViewModel response = new InvoiceItemViewModel();

            foreach (var invoice in invoices)
            {
                var invoiceItem = invoice.InvoiceItems.FirstOrDefault(y => y.Id == id);
                if (invoiceItem != null)
                {
                    response = mapper.Map<InvoiceItemViewModel>(invoiceItem);
                    response.InvoiceId = invoice.Id;
                    break;
                }

            }

            return response;

        }

        /// <summary>
        /// Add invoice Item
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public InvoiceItemViewModel AddInvoiceItem(InvoiceItemBinding model)
        {
            var invoice = invoices.FirstOrDefault(y => y.Id == model.InvoiceId);
            var dbo = mapper.Map<InvoiceItem>(model);
            dbo.Id = GetNextInvoiceItemId();
            invoice.InvoiceItems.Add(dbo);
            return mapper.Map<InvoiceItemViewModel>(dbo);
        }




        public int GetNextInvoiceId()
        {
            var lasInvoice = invoices.OrderByDescending(y => y.Id).First();
            return lasInvoice.Id + 1;
        }

        #region Private methods

        private int GetNextInvoiceItemId()
        {

            var lasId = 0;

            foreach (var invoice in invoices)
            {
                if (invoice.InvoiceItems.Any())
                {
                    var invoiceItemLastId = invoice.InvoiceItems.OrderByDescending(y => y.Id).First();
                    if (lasId < invoiceItemLastId.Id)
                    {
                        lasId = invoiceItemLastId.Id;
                    }
                }



            }

            return lasId + 1;

        }

        #endregion

    }
}
