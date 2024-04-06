using Linq_of_type.Model;
using System.Collections;

namespace Linq_of_type
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList mjesovitaLista = new ArrayList();
            mjesovitaLista.Add(0);
            mjesovitaLista.Add("Jedan");
            mjesovitaLista.Add("Dva");
            mjesovitaLista.Add(3);
            mjesovitaLista.Add(new Polaznik() { Id = 1, ImePrezime = "Mato Rimad" });

            #region LINQ OfType operator - Pronadi string tipove

            Console.WriteLine("==================================================================");
            Console.WriteLine("LINQ OfType operator - Pronadji int tipove");
            Console.WriteLine("==================================================================");

            var string_reultat = from s in mjesovitaLista.OfType<string>()
                                 select s;

            foreach (var rezultat in string_reultat)
            {
                Console.WriteLine(rezultat);
            }

            #endregion

            #region Prooadji int tipove

            Console.WriteLine();
            Console.WriteLine("==================================================================");
            Console.WriteLine("LINQ OfType operator - Pronadji int tipove");
            Console.WriteLine("==================================================================");

            var int_rezultat = from s in mjesovitaLista.OfType<int>()
                               select s;

            foreach (var rezultat in int_rezultat)
            {
                Console.WriteLine(rezultat);
            }

            #endregion

            #region Pronadji string tipove - skraceno

            Console.WriteLine();
            Console.WriteLine("==================================================================");
            Console.WriteLine("LINQ OfType operator - Pronadi string tipove");
            Console.WriteLine("==================================================================");

            var string_reultat_skraceno = mjesovitaLista.OfType<string>();

            foreach (var rezultat in string_reultat_skraceno)
            {
                Console.WriteLine(rezultat);
            }

            #endregion

            #region Zadatak 1 
            ArrayList mjesovitiBrojevi = new ArrayList();
            mjesovitiBrojevi.Add(1);
            mjesovitiBrojevi.Add("2");
            mjesovitiBrojevi.Add(10);
            mjesovitiBrojevi.Add("3");
            mjesovitiBrojevi.Add(4);
            mjesovitiBrojevi.Add("7");
            mjesovitiBrojevi.Add(5m);
            mjesovitiBrojevi.Add("8");
            mjesovitiBrojevi.Add(6f);

            //napraviti listu svih brojeva od mjesovitiBrojevi varijable poredane od najmanje do najveceg
            //napraviti listu svih parnih brojeva od mjesovitiBrojevi varijable
            //napraviti listu svih brojeva od mjesovitiBrojevi varijable, vecih od 2 a manjih od 8
            //korissteci LINQ OfType

            List<int> listaCistihBrojeva = new List<int>();

            //jedan od nacina
            foreach (var item in mjesovitiBrojevi)
            {
                if (item is int)
                {
                    listaCistihBrojeva.Add((int)item);
                }
                else if (item is decimal)
                {
                    listaCistihBrojeva.Add(Convert.ToInt32((decimal)item));
                }
                else if (item is float)
                {
                    listaCistihBrojeva.Add(Convert.ToInt32((float)item));
                }

                else if (item is string)
                {
                    listaCistihBrojeva.Add(int.Parse(((string)item)));
                }
            }

            //drugi nacin

            var brojevi = mjesovitiBrojevi.OfType<IComparable>()
                .Select(b => Convert.ToDecimal(b))
                .ToList();

            //Lista svih brojeva poredana od najmanjeg do najveceg
            var sortirani_broejvi = brojevi.OrderBy(x => x).ToList();
            Console.WriteLine("Sorirani brojevi: " + string.Join(", ", sortirani_broejvi));

            //Lista svih parnih brojeva
            var parniBrojevi = brojevi.Where(x => x % 2 == 0).ToList();
            Console.WriteLine("Parni brojevi: " + string.Join(", ", parniBrojevi));

            //Lista svih brojeva vecih od 2 i manjih od 8
            var veciIManji = brojevi.Where(x => x > 2 && x < 8).ToList();
            Console.WriteLine("Veci od 2, a manji od 8 su: " + string.Join(", ", veciIManji));
            #endregion
        }
    }
}
