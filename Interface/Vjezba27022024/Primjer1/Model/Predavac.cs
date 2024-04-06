namespace Primjer1.Model
{
    public class Predavac : IOsoba, IZaposlenik
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string OIB { get; set; }

        public void IspisiOdjel()
        {
            Console.WriteLine("Obrazovanje Odraslih:");
        }

        public void IspisiRukovoditelja()
        {
            Console.WriteLine("Mato Matic");
            Console.WriteLine();
        }
    }
}
