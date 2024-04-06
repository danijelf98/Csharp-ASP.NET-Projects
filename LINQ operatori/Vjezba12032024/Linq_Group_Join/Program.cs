using Linq_Group_Join.Model;

namespace Linq_Group_Join
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Polaznik> ListaPolaznika = new List<Polaznik>()
            {
              new Polaznik() { Id = 1, ImePrezime = "Ivo Programeric", TecajID = 1 },
              new Polaznik() { Id = 1, ImePrezime = "Ana Dizajneric", TecajID = 1 },
              new Polaznik() { Id = 1, ImePrezime = "Marko Sistemovski", TecajID = 3 },
              new Polaznik() { Id = 1, ImePrezime = "Ana Programeric", TecajID = 2 },
              new Polaznik() { Id = 1, ImePrezime = "Ana Marija Matic", TecajID = 2 },
              new Polaznik() { Id = 1, ImePrezime = "Marko Stojankovic", TecajID = 1 },
              new Polaznik() { Id = 1, ImePrezime = "Marija Grbic" },
            };

            List<Tecaj> ListaTecajeva = new List<Tecaj>()
            {
                new Tecaj() { Id = 1, Naziv = "Tecaj 1" },
                new Tecaj() { Id = 2, Naziv = "Tecaj 2" },
                new Tecaj() { Id = 3, Naziv = "Tecaj 3" }
            };

            Console.WriteLine("===============================================================");
            Console.WriteLine("Linq GroupJoin Operator - Method syntax");
            Console.WriteLine("===============================================================");

            var ms_group_join = ListaTecajeva.GroupJoin 
                (ListaPolaznika, 
                tecaj => tecaj.Id, 
                polaznik => polaznik.TecajID, 
                (tecaj, grupaPoalznika) => new 
                { 
                    Polaznici = grupaPoalznika, 
                    NazivTecaja = tecaj.Naziv 
                });

            foreach (var item in ms_group_join)
            {
                Console.WriteLine(item.NazivTecaja);
                foreach (var polaznik in item.Polaznici)
                    Console.WriteLine(polaznik.ImePrezime);

                Console.WriteLine("-------------------------------------");
            }

            Console.WriteLine();
            Console.WriteLine("===============================================================");
            Console.WriteLine("Linq GroupJoin Operator - Query syntax");
            Console.WriteLine("===============================================================");

            var qs_group_jooin = from tecaj in ListaTecajeva
                                 join polaznik in ListaPolaznika
                                 on tecaj.Id equals polaznik.TecajID
                                 into grupaPoalznika
                                 select new
                                 {
                                     Polaznici = grupaPoalznika,
                                     NazivTecaja = tecaj.Naziv
                                 };

            foreach (var item in qs_group_jooin)
            {
                Console.WriteLine(item.NazivTecaja);

                foreach (var polanzik in item.Polaznici)
                {
                    Console.WriteLine(polanzik.ImePrezime);
                }
                Console.WriteLine("---------------------------------------");
            }
        }
    }
}
