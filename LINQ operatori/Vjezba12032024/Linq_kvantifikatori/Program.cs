using Linq_kvantifikatori.Model;

namespace Linq_kvantifikatori
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Operatori kvatifikatora procjenjuju elemente izvora
            //podataka pod nekim uvjetom i vracaju logicku vrijednost
            //kako bi ukazali da neki ili svi elementi zadovoljavaju vujet
            //Operatori kvantifikatora nisu podrzani s query syntax stilom u C# ili VB.NET

            //to su operatori ALL, Any, Contains


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

            Console.WriteLine("===============================================");
            Console.WriteLine("LINQ All Operaotr - Method syntax");
            Console.WriteLine("===============================================");

            var provjeri_ako_su_svi_tinedjeri = ListaPolaznika.All(y => y.Starost > 12 && y.Starost < 20);
            var alternativa = ListaPolaznika.Where(y => y.Starost > 12 && y.Starost < 20).Any();

            Console.WriteLine(provjeri_ako_su_svi_tinedjeri);

            Console.WriteLine();
            Console.WriteLine("===============================================");
            Console.WriteLine("LINQ Contains Operator - Method syntax");
            Console.WriteLine("===============================================");

            IList<int> intLista = new List<int>() { 1, 2, 3, 4, 5 };
            bool postojiliBroj10 = intLista.Contains(10);
            Console.WriteLine(postojiliBroj10);

            bool postojiLiBroj1 = intLista.Contains(1);
            Console.WriteLine(postojiLiBroj1);
        }
    }
}
