using Primjer1.Model;
using System.Threading.Channels;

namespace Primjer1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Polaznik polaznik = new Polaznik()
            {
                Ime = "Polaznik ime",
                Prezime = "Polaznik Prezime",
                OIB = "123456789"
            };

            Predavac predavac = new Predavac()
            {
                Ime = "Predavac ime",
                Prezime = "Predavac Prezime",
                OIB = "123456789"
            };

            Zaposlenik Zaposlenik = new Zaposlenik()
            {
                Ime = "Zaposlenik ime",
                Prezime = "Zaposlenik Prezime",
                OIB = "123456789"
            };

            IspisOsobe(polaznik);
            IspisOsobe(predavac);
            IspisOsobe(Zaposlenik);

            Console.WriteLine();
            IspisZaposlenika(Zaposlenik);
            IspisZaposlenika(predavac);
        }

        static void IspisZaposlenika(IZaposlenik zaposlenik)
        {
            zaposlenik.IspisiOdjel();
            zaposlenik.IspisiRukovoditelja();
        }

        static void IspisOsobe(IOsoba osoba)
        {
            Console.WriteLine($"Ime i Prezime osobe: {osoba.Ime} {osoba.Prezime}, OIB: {osoba.OIB}");
        }
        
    }
}
