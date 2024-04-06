namespace Primjer1.Model
{
    public class Zaposlenik : IOsoba, IZaposlenik
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string OIB { get; set; }

        public void IspisiOdjel()
        {
            Console.WriteLine("Odjel opcih poslova:");
        }

        public void IspisiRukovoditelja()
        {
            Console.WriteLine("Ivan Horvat");
            Console.WriteLine();
        }
    }
}
