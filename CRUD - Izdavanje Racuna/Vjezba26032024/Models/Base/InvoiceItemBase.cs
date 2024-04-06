namespace Vjezba26032024.Models.Base
{
    public abstract class InvoiceItemBase
    {
        public string Title { get; set; }
        public decimal Quantity { get; set; } // količina stavke
        public decimal Price { get; set; } //jedinična cijena stavke
        public decimal Total
        {
            get { return InvoiceItemTotal(); }

        }
        private decimal InvoiceItemTotal()
        {
            return this.Price * this.Quantity;
        }
    }
}
