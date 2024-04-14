using Vjezba09042024.Model;

namespace Vjezba09042024.Service
{
    public class InoviceServiceUnitTest
    {
        private readonly InvoiceService _invoiceService;

        public InoviceServiceUnitTest()
        {
           _invoiceService = new InvoiceService();
        }

        [Fact]
        public void GetInvoice_GetsInvoiceById_ReturnsTheObject()
        {
            var response = _invoiceService.GetInvocie(1);
            Assert.NotNull(response);
        }

        [Fact]
        public void GetNextId_GeneratesNextId_ReturnsTheNextId()
        {
            var response = _invoiceService.GetNextId();
            Assert.Equal(2, response);
        }

        [Fact]
        public void CreateInvoice_GeneratesInvoiceAndAddToListOfInvoices_ReturnsPopulatedModel()
        {
            var response = _invoiceService.CreateInovice
            (
                new Model.Racun

                {
                    DatumIzrade = DateTime.Now,
                    DatumDospijeca = DateTime.Now,
                    Iznos = 100,
                    KupacIme = "Buyer Name",
                    KupacPrezime = "Buyer LastName"
                }

              );
            Assert.NotNull(response);
            Assert.Equal(2, response.Id);
            _invoiceService.DeleteInvoice(response.Id);
        }

        [Fact]
        public void GetAllInvoices_GetsAllInvoices_ReturnsTheListOfInvoices()
        {
            var response = _invoiceService.GetAllInvoices();
            Assert.NotEmpty(response);
            Assert.Single(response);
        }

        [Fact]
        public void DeleteInvoice_GetsAllInvoicesAndDeletesTheFirstOne_ChecksTheNumberOfRemainingInvoices()
        {
            var invoices = _invoiceService.GetAllInvoices();
            Assert.NotEmpty(invoices);
            Assert.Single(invoices);

            _invoiceService.DeleteInvoice(invoices[0].Id);
            invoices = _invoiceService.GetAllInvoices();
            Assert.Single(invoices);
        }

        [Fact]
        public void UpdateInovic_GetsAllInvoicesAndChangeTheValueOnce_ReturnsUpdatedInvoice()
        {
            var invoices = _invoiceService.GetAllInvoices();
            Assert.NotEmpty(invoices);
            Assert.Single(invoices);

            var result = invoices[0];
            string testName = "New Name";
            string testLastName = "New LastName";

            result.KupacIme = testName;
            result.KupacPrezime = testLastName;

            _invoiceService.UpdateInvoice(result);

            Assert.Equal(testName, result.KupacIme);
            Assert.Equal(testLastName, result.KupacPrezime);
        }
    }
}
