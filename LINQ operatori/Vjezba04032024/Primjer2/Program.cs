using Primjer2.Model;

namespace Primjer2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Klijent> listaKlijenata = new List<Klijent>()
            {
                new Klijent() { ImePrezime = "Mico Programercic", Stanje = 80345.66, Banka = "Erste" },
                new Klijent() { ImePrezime = "Ana Dizajneric", Stanje = 9284756.21, Banka = "ZABA" },
                new Klijent() { ImePrezime = "Marko Sistemovski", Stanje = 487233.01, Banka = "PBZ" },
                new Klijent() { ImePrezime = "Ive Pavlo Maric", Stanje = 7001449.92, Banka = "PBZ" },
                new Klijent() { ImePrezime = "Ana katic", Stanje = 790872.12, Banka = "Erste" },
                new Klijent() { ImePrezime = "Gandalf Bjelobradi", Stanje = 8374892.54, Banka = "PBZ" },
                new Klijent() { ImePrezime = "Oto Maric", Stanje = 957436.39, Banka = "ZABA" },
                new Klijent() { ImePrezime = "Sara Ivic", Stanje = 56562389.85, Banka = "ZABA" },
                new Klijent() { ImePrezime = "Kristina Kristic", Stanje = 10000000.00, Banka = "Erste" },
                new Klijent() { ImePrezime = "Pingvin Madagaskaric", Stanje = 10049582.68, Banka = "Erste" }
            };

            var GrupirajPremaBanci = listaKlijenata.Where(k => k.Stanje >= 1000000)
                .GroupBy(
                p => p.Banka,
                p => p.ImePrezime, 
                (banka, milijunas) => new GrupiraniMilijunasi()
                {
                    Banka = banka,
                    Milijunasi = milijunas
                }
                ).ToList();

            foreach (var stavka in GrupirajPremaBanci)
            {
                Console.WriteLine($"{stavka.Banka}: {string.Join(" i ", stavka.Milijunasi)}");
            }
        }
    };
}
