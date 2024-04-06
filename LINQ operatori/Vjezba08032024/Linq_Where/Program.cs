using Linq_Where.Model;

namespace Linq_Where
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Polaznik[] ListaPolaznika = {
                new Polaznik() { ID = 1, ImePrezime = "Ivo Programerić", Starost = 18 },
                new Polaznik() { ID = 2, ImePrezime = "Ana Dizajnerić", Starost = 21 },
                new Polaznik() { ID = 3, ImePrezime = "Marko Sistemovski", Starost = 25 },
                new Polaznik() { ID = 4, ImePrezime = "Ana Programerić" , Starost = 20 },
                new Polaznik() { ID = 5, ImePrezime = "Ana Marija Matić" , Starost = 31 },
                new Polaznik() { ID = 6, ImePrezime = "Marko Stojanovski", Starost = 17 },
                new Polaznik() { ID = 7, ImePrezime = "Marija Grbić", Starost = 19  }
            };

            #region LINQ Where operator - Query Syntax stil

            Console.WriteLine("=============================================================");
            Console.WriteLine("Primjer koristenja LINQ Where operatora - Query Syntax stil");
            Console.WriteLine("=============================================================");

            var filtriraj_rezultat = from p in ListaPolaznika
                                     where p.Starost > 12 && p.Starost < 20
                                     select p.ImePrezime;

            foreach (var item in filtriraj_rezultat)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region Primjer koristenja lambda izraza za filtriranje

            Console.WriteLine();
            Console.WriteLine("=============================================================");
            Console.WriteLine("Primjer koristenja lambda izraza za filtriranje:");
            Console.WriteLine("=============================================================");

            var filter = ListaPolaznika
                .Where(p => p.Starost > 12 && p.Starost < 20)
                .Select(p => p.ImePrezime);

            foreach (var item in filter)
            {
                Console.WriteLine(item);
            }

            #endregion

            #region LINQ where operator - FUNC tip delegat sa anoimnom metodom

            Console.WriteLine();
            Console.WriteLine("==============================================================");
            Console.WriteLine("Primjer koristenja LINQ where operatora - FUNC tip el delegat sa anoimnom metodom:");
            Console.WriteLine("=============================================================");

            Func<Polaznik, bool> jeTinedjer = delegate (Polaznik p)
            {
                return p.Starost > 12 && p.Starost < 20;
            };

            var filtriraj_rezultat_s_delegatom = from p in ListaPolaznika
                                                 where jeTinedjer(p)
                                                 select p.ImePrezime;

            foreach (var rezultat in filtriraj_rezultat_s_delegatom)
            {
                Console.WriteLine(rezultat);
            }
            #endregion

            #region LINQ where operator - s vanjskom metodom

            Console.WriteLine();
            Console.WriteLine("==============================================================");
            Console.WriteLine("Primjer koristenja LINQ where operatora - s vanjskom metodom:");
            Console.WriteLine("==============================================================");

            var filtriraj_s_metodom = from p in ListaPolaznika
                                      where ProvjeraAkoJetinedjer(p)
                                      select p.ImePrezime;

            // filtriranje lambda funkcijom pomocu vanjske metode 
            var filterKlasa = ListaPolaznika
                .Where(p => ProvjeraAkoJetinedjer(p))
                .Select(p => p.ImePrezime);

            foreach (var item in filterKlasa)
            {
                Console.WriteLine(item);
            }

            #endregion

            #region LINQ where operator - Method Syntax stil

            Console.WriteLine();
            Console.WriteLine("==============================================================");
            Console.WriteLine("Primjer koristenja LINQ where operatora - Method Syntax stil:");
            Console.WriteLine("==============================================================");

            var filter_rezultata_skraceno = ListaPolaznika
                .Where(p => ProvjeraAkoJetinedjer(p));

            foreach (var rezultat in filter_rezultata_skraceno)
            {
                Console.WriteLine(rezultat.ImePrezime);
            }

            #endregion

            #region LINQ where operatora - Method Syntax stil s uvjetom

            Console.WriteLine();
            Console.WriteLine("==============================================================");
            Console.WriteLine("Primjer koristenja LINQ where operatora - Method Syntax stil s uvjetom:");
            Console.WriteLine("==============================================================");

            var filtriraj_rezultat_s_uvjetom = ListaPolaznika.Where((p, i) =>
            {
                if (i % 2 == 0)
                {
                    // ako je element u listi paran
                    return true;
                }
                return false;
            });

            foreach (var rezultat in filtriraj_rezultat)
            {
                Console.WriteLine(rezultat);
            }
            #endregion

            #region LINQ where operator - visestruki where

            Console.WriteLine();
            Console.WriteLine("==============================================================");
            Console.WriteLine("Primjer koristenja LINQ where operatora - visestruki where:");
            Console.WriteLine("==============================================================");

            var filtriraj_rezultat_visestruko = from p in ListaPolaznika
                                                where p.Starost > 12
                                                where p.Starost < 20
                                                select p;

            var filtriraj_rezultat_visestruko_Lambda = ListaPolaznika
                                           .Where(p => p.Starost > 12)
                                           .Where(p => p.Starost < 20);


            foreach (var rezulatat in filtriraj_rezultat_visestruko_Lambda)
            {
                Console.WriteLine(rezulatat.ImePrezime);
            }

            #endregion
        }
        public static bool ProvjeraAkoJetinedjer(Polaznik p)
        {
            return p.Starost > 12 && p.Starost <= 20;
        }
    }
}
