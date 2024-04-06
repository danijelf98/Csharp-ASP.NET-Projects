using Linq_group_lookup.Model;

namespace Linq_group_lookup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Polaznik[] ListaPolaznika = {
              new Polaznik() { Id = 1, Ime = "Ivo Programerić", Starost = 18 },
              new Polaznik() { Id = 2, Ime = "Ana Dizajnerić", Starost = 21 },
              new Polaznik() { Id = 3, Ime = "Marko Sistemovski", Starost = 21 },
              new Polaznik() { Id = 4, Ime = "Ana Programerić" , Starost = 18 },
              new Polaznik() { Id = 5, Ime = "Ana Marija Matić" , Starost = 21 },
              new Polaznik() { Id = 6, Ime = "Marko Stojanovski", Starost = 18 },
              new Polaznik() { Id = 7, Ime = "Marija Grbić", Starost = 18  }
          };

            Console.WriteLine("======================================================");
            Console.WriteLine("LINQ GroupBy Operator - grupiranje po starosti");
            Console.WriteLine("======================================================");

            var grupiraj_po_starosti = from p in ListaPolaznika
                                       group p by p.Starost;

            foreach (var grupaPoStarosti in grupiraj_po_starosti)
            {
                Console.WriteLine("Grupa starosti: {0}", grupaPoStarosti.Key);

                foreach (Polaznik p in grupaPoStarosti)
                {
                    Console.WriteLine("Ime polaznika: {0}", p.Ime);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("==============================================================");
            Console.WriteLine("LINQ GroupBy Operator - grupiranje po starosti - Method syntax");
            Console.WriteLine("==============================================================");

            var grupiraj_po_starosti_skraceno = ListaPolaznika
                .GroupBy(y => y.Starost);

            foreach (var grupaPoStarosti in grupiraj_po_starosti_skraceno)
            {
                Console.WriteLine("Grupa starosti: {0}", grupaPoStarosti.Key);

                foreach (Polaznik p in grupaPoStarosti)
                {
                    Console.WriteLine("Ime polaznika: {0}", p.Ime);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("===============================================================");
            Console.WriteLine("LINQ ToLookUp Operator - grupiranje po starosti - Method syntax");
            Console.WriteLine("===============================================================");

            //ToLookUp je isto sto i GroupBy; jedina razlika je sto je izvrsenje GroupBy odgodjeno,
            //dok je izvrsavanje LookUp trenutno.
            //LookUp je primjenjiv samo u sintaksi metode (Method syntax)
            //Look up nije podrzan u sintaksi upita

            var grupiraj_s_lookup = ListaPolaznika
                .ToLookup(y => y.Starost);

            foreach (var grupaPoStarosti in grupiraj_s_lookup)
            {
                Console.WriteLine("Grupa starosti: {0}", grupaPoStarosti.Key);

                foreach (Polaznik p in grupaPoStarosti)
                {
                    Console.WriteLine("Ime polaznika: {0}", p.Ime);
                }
                Console.WriteLine();
            }


        }
    }
}
