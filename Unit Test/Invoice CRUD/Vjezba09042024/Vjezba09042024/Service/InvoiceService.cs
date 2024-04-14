using System.Threading.Tasks.Dataflow;
using Vjezba09042024.Model;

namespace Vjezba09042024.Service
{
    public class InvoiceService
    {
        private static List<Racun> invoices = new List<Racun>()
        {
            new Racun()
            {
                Id = 1,
                KupacIme = "Kupac Ime 1",
                KupacPrezime = "Kupac Prezime 1",
                DatumDospijeca = DateTime.Now.AddDays(1),
                DatumIzrade = DateTime.Now,
                Iznos = 200
            }
        };

        public int GetNextId()
        {
            int id = 1;

            if (invoices == null || !invoices.Any())
            {
                return id;
            }

            return invoices.OrderByDescending(x => x.Id).First().Id + 1;
        }

        #region CRUD Operations

        /// <summary>
        /// Gets Invoice by ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Racun GetInvocie(int Id)
        {
            var response = invoices.FirstOrDefault(x => x.Id == Id);
            return response;
        }

        /// <summary>
      /// Creates Invoice
      /// </summary>
      /// <param name="racun"></param>
      /// <returns></returns>
        public Racun CreateInovice(Racun racun)
        {
            racun.Id = GetNextId();
            invoices.Add(racun);
            return racun;
        }

        /// <summary>
        /// Gets all Invoices
        /// </summary>
        /// <returns></returns>
        public List<Racun> GetAllInvoices()
        {
            return invoices.ToList();
        }

        /// <summary>
        /// Delete Inovice
        /// </summary>
        /// <param name="Id"></param>
        /// <exception cref="Exception"></exception>
        public void DeleteInvoice(int Id)
        {
            if (invoices.Count > 1)
            {
                var invoice = invoices.FirstOrDefault(x => x.Id == Id);
                invoices.Remove(invoice);
            }
        }

        /// <summary>
        /// Update Invoice
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="kupacIme"></param>
        /// <param name="kupacPrezime"></param>
        /// <param name="datumDospijeca"></param>
        /// <param name="datumIzrade"></param>
        /// <param name="iznos"></param>
        /// <returns></returns>
        public Racun UpdateInvoice(Racun invoice)
        {
            var dbo = invoices.FirstOrDefault(x => x.Id == invoice.Id);

            dbo.Iznos = invoice.Iznos;
            dbo.DatumIzrade = invoice.DatumIzrade;
            dbo.DatumDospijeca = invoice.DatumDospijeca;
            dbo.KupacIme = invoice.KupacIme;
            dbo.KupacPrezime = invoice.KupacPrezime;
            return dbo;
        }

        #endregion
    }
}
