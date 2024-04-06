using linq_sintaksa.Model;

namespace linq_sintaksa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Polaznik[] ListaPolaznika = 
            {
                new Polaznik() { Id = 1, Ime_i_Prezime = "Ivo Programercic", Starost = 18 },
                new Polaznik() { Id = 1, Ime_i_Prezime = "Ana Dizajnercic", Starost = 21 },
                new Polaznik() { Id = 1, Ime_i_Prezime = "Marko Sistemovski", Starost = 25 },
                new Polaznik() { Id = 1, Ime_i_Prezime = "Ana Programercic", Starost = 20 },
                new Polaznik() { Id = 1, Ime_i_Prezime = "Ana Marija Matic", Starost = 31 },
                new Polaznik() { Id = 1, Ime_i_Prezime = "Marko Stojanovski", Starost = 17 },
                new Polaznik() { Id = 1, Ime_i_Prezime = "Marija Grbic", Starost = 19 }
            };

            Console.WriteLine("============================================================================================");
            Console.WriteLine("Primjer jednostavnog nacina itercije kroz kolekciju");
            Console.WriteLine("Pronadji razlike izmedju 12 i 20 godina starostii pohranite ih u niz koji se zove polaznici");
            Console.WriteLine("============================================================================================");
            Console.WriteLine();



            Polaznik[] polaznici = new Polaznik[10];
            int i = 0;
            foreach (Polaznik polaznik in ListaPolaznika)
            {
                if (polaznik.Starost > 12 && polaznik.Starost < 20)
                {
                    polaznici[i] = polaznik;
                    i++;
                }
            }

            for (int x = 0; x < polaznici.Length; x++)
            {
                if (polaznici.ElementAtOrDefault(x) != null)
                {
                    Console.WriteLine(polaznici[x].Id + ": " + polaznici[x].Ime_i_Prezime + ", " + polaznici[x].Starost);
                }
            }

            Console.WriteLine();
            Console.WriteLine();

            polaznici = (from polaznik in ListaPolaznika
                         where polaznik.Starost > 12 && polaznik.Starost < 20
                         select polaznik).ToArray();

            for (int x = 0; x <= polaznici.Length; x++)
            {
                if (polaznici.ElementAtOrDefault(x) != null)
                {
                    Console.WriteLine(polaznici[x].Id + ": " + polaznici[x].Ime_i_Prezime + ", " + polaznici[x].Starost);
                }
            }

            polaznici = ListaPolaznika.Where(s => s.Starost > 12 && s.Starost < 20).ToArray();
            
        }
    }
}
