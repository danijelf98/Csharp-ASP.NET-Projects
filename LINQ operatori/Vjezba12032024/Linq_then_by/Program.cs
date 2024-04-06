using Linq_then_by.Model;

namespace Linq_then_by
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Polaznik[] ListaPolaznika = {
                new Polaznik() { Id = 1, Ime = "Ivo", Starost = 18 },
                new Polaznik() { Id = 2, Ime = "Ana", Starost = 21 },
                new Polaznik() { Id = 3, Ime = "Marko", Starost = 25 },
                new Polaznik() { Id = 4, Ime = "Ana Marija", Starost = 20 },
                new Polaznik() { Id = 5, Ime = "Ana", Starost = 31 },
                new Polaznik() { Id = 6, Ime = "Marko", Starost = 17 },
                new Polaznik() { Id = 7, Ime = "Marija", Starost = 19 }
            };

            Console.WriteLine("======================================================");
            Console.WriteLine("LINQ ThenBy Operator - visestruko uzlazno sortiranje");
            Console.WriteLine("======================================================");
            

            var sortiraj_visestruko_uzlazno = ListaPolaznika
                .OrderBy(y => y.Ime)
                .ThenBy(y => y.Starost);

            foreach (var rezultat in sortiraj_visestruko_uzlazno)
            {
                Console.WriteLine($"Ime: {rezultat.Ime},  Starost: {rezultat.Starost}");
            }

            Console.WriteLine();
            Console.WriteLine("======================================================");
            Console.WriteLine("LINQ ThenBy Operator - visestruko silazno sortiranje");
            Console.WriteLine("======================================================");

            var sortiraj_visestruko_silazno = ListaPolaznika.OrderBy(y => y.Ime)
                .ThenByDescending(y => y.Starost);

            foreach (var rezultat in sortiraj_visestruko_silazno)
            {
                Console.WriteLine($"Ime: {rezultat.Ime},  Starost: {rezultat.Starost}");
            }

        }
    }
}
