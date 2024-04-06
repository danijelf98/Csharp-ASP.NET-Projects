using Linq_Select.Model;

namespace Linq_Select
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Polaznik> ListaPolaznika = new List<Polaznik>()
            {
              new Polaznik() { Id = 1, ImePrezime = "Ivo Programeric", Starost = 18 },
              new Polaznik() { Id = 1, ImePrezime = "Ana Dizajneric", Starost = 21 },
              new Polaznik() { Id = 1, ImePrezime = "Marko Sistemovski", Starost = 25 },
              new Polaznik() { Id = 1, ImePrezime = "Ana Programeric", Starost = 20 },
              new Polaznik() { Id = 1, ImePrezime = "Ana Marija Matic", Starost = 31 },
              new Polaznik() { Id = 1, ImePrezime = "Marko Stojankovic", Starost = 17 },
              new Polaznik() { Id = 1, ImePrezime = "Marija Grbic", Starost = 19 },
            };

            Console.WriteLine("======================================");
            Console.WriteLine("LINQ Select Operaotr - query syntax");
            Console.WriteLine("======================================");

            var qs_samo_ime_prezime = from p in ListaPolaznika
                                      select p.ImePrezime;

            foreach (var item in qs_samo_ime_prezime)
            {
                Console.WriteLine("Polaznik se zove: {0}", item);
            }

            Console.WriteLine();
            Console.WriteLine("===============================================================");
            Console.WriteLine("LINQ Select operator - anmoimnom tipom rezultata - query sytnax");
            Console.WriteLine("===============================================================");

            var sq_sa_anoimnom_tipom = from p in ListaPolaznika
                                       select new
                                       {
                                           Polaznik = p.ImePrezime,
                                           Godine = p.Starost
                                       };
            
            foreach (var item in sq_sa_anoimnom_tipom)
            {
                Console.WriteLine("Polaznik: {0}, Godine: {1}", item.Polaznik, item.Godine);
            }

            Console.WriteLine();
            Console.WriteLine("================================================================");
            Console.WriteLine("LINQ Select operator - anmoimnom tipom rezultata - Method sytnax");
            Console.WriteLine("================================================================");

            var ms_sa_anoimnom_tipom = ListaPolaznika.Select(p => new
            {
                Polaznik = p.ImePrezime,
                Godine = p.Starost
            });

            foreach (var item in sq_sa_anoimnom_tipom)
            {
                Console.WriteLine("Polaznik: {0}, Godine: {1}", item.Polaznik, item.Godine);
            }
        }
    }
}
