using Linq_OrderBy.Model;

namespace Linq_OrderBy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Polaznik[] ListaPolaznika = {
                new Polaznik() { Id = 1, ImePrezime = "Ivo Programerić", Starost = 18 },
                new Polaznik() { Id = 2, ImePrezime = "Ana Dizajnerić", Starost = 21 },
                new Polaznik() { Id = 3, ImePrezime = "Marko Sistemovski", Starost = 25 },
                new Polaznik() { Id = 4, ImePrezime = "Ana Programerić" , Starost = 20 },
                new Polaznik() { Id = 5, ImePrezime = "Ana Marija Matić" , Starost = 31 },
                new Polaznik() { Id = 6, ImePrezime = "Marko Stojanovski", Starost = 17 },
                new Polaznik() { Id = 7, ImePrezime = "Marija Grbić", Starost = 19  }
            };

            #region LINQ OrderBy operator - sortiraj uzlazno

            Console.WriteLine("===================================================================");
            Console.WriteLine("Primjeri koristenja LINQ OrderBy operatora - sortiraj uzlazno");
            Console.WriteLine("===================================================================");

            var sortiranje_uzlazno = from p in ListaPolaznika
                                     orderby p.ImePrezime
                                     select p;

            foreach (var rezulat in sortiranje_uzlazno)
            {
                Console.WriteLine(rezulat.ImePrezime);
            }

            Console.WriteLine();
            Console.WriteLine();

            sortiranje_uzlazno = ListaPolaznika.OrderBy(y => y.ImePrezime);

            foreach (var rezulat in sortiranje_uzlazno)
            {
                Console.WriteLine(rezulat.ImePrezime);
            }
            #endregion

            #region LINQ OrderBy operator - sortiranje silazno

            Console.WriteLine();
            Console.WriteLine("===================================================================");
            Console.WriteLine("Primjeri koristenja LINQ OrderBy operatora - sortiraj silazno");
            Console.WriteLine("===================================================================");

            var sortiranje_silanzo = from p in ListaPolaznika
                                     orderby p.ImePrezime descending
                                     select p;

            foreach (var rezultat in sortiranje_silanzo)
            {
                Console.WriteLine(rezultat.ImePrezime);
            }

            Console.WriteLine();
            Console.WriteLine();

            sortiranje_uzlazno = ListaPolaznika.OrderByDescending(y => y.ImePrezime);

            foreach (var rezultat in sortiranje_silanzo)
            {
                Console.WriteLine(rezultat.ImePrezime);
            }
            #endregion

            #region LINQ OrderBy operator - visestruko sortirnaje

            Console.WriteLine();
            Console.WriteLine("===================================================================");
            Console.WriteLine("Primjeri koristenja LINQ OrderBy operatora - visestruko sortiranje");
            Console.WriteLine("===================================================================");

            var sortrinaje_visestruko = from p in ListaPolaznika
                                        orderby p.ImePrezime, p.Starost
                                        select new { p.ImePrezime, p.Starost};

            foreach (var rezultat in sortrinaje_visestruko)
            {
                Console.WriteLine(rezultat.ImePrezime);
            }

            #endregion
        }
    }
}
