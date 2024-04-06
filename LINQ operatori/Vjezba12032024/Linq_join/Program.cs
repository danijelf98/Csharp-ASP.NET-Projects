using Linq_join.Model;

namespace Linq_join
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IList<string> list = new List<string>()
            {
                "Jedan",
                "Dva",
                "Tri",
                "Cetiri"
            };

            List<string> list2 = new List<string>()
            {
                "Jedan",
                "Dva",
                "Pet",
                "Sest"
            };

            Console.WriteLine("======================================================");
            Console.WriteLine("LINQ Join Operator - samo podudarne vrijednosti");
            Console.WriteLine("======================================================");

            //Sljedeci primjer pridruzuje dvije kolekcije nizova i vraca novu kolekciju koja ukljucuje podudarne nizove u obje kolekcije)

            var podudarne_vrijednosti = list.Join(list2,
                str1 => str1,
                str2 => str2,
                (str1, str2) => str2);

            foreach (var rezultat in podudarne_vrijednosti)
            {
                Console.WriteLine(rezultat);
            }

            Console.WriteLine();
            Console.WriteLine("==========================================================");
            Console.WriteLine("LINQ Join Operator - sa razlicitim klasama - Method syntax");
            Console.WriteLine("==========================================================");

            //Sada, shvatimo JOIN metodu koristeci sljedecu klasu 
            //Polaznik i Tecaj gdej polaznik klasa ukljucuje svojstvo 
            //TecajID koji se podudara sa svojstvom ID klase Tecaj

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

            var ms_inner_join = ListaPolaznika.Join //vanjski izvor podataka
                (ListaTecajeva, //unutarnji izvor podataka
                polaznk => polaznk.TecajID, //vanjski kljuc slekcija (prvi ID koji uparujemo)
                tecaj => tecaj.Id, //unutranji kljuc slekcija (drugi Id koji uparujemo)
                (polaznik, tecaj) => new // slijed za format rezultata
                { ImePrezimePoalznika = polaznik.ImePrezime, NazivTecaja = tecaj.Naziv });

            foreach (var rezultat in ms_inner_join)
            {
                Console.WriteLine($"Tecaj: {rezultat.NazivTecaja} polaznik: {rezultat.ImePrezimePoalznika}");
            }

            Console.WriteLine();
            Console.WriteLine("=========================================================");
            Console.WriteLine("LINQ Join Operator - sa razlicitim klasama - Query syntax");
            Console.WriteLine("=========================================================");

            //JOIN u syntaxi upita
            // Query Sytnax vraca koklekciju elemenata iz ListaPoalanznika i 
            //ListaTecajeva ako se podudaraju njihovi Polaznik.TecajID i Tecaj.ID

            var qs_inner_join = from p in ListaPolaznika  //vanjski izvor podataka
                                join t in ListaTecajeva   // unutarnji izvor podataka
                                on p.TecajID equals t.Id  //kljuc selekcije
                                select new
                                {
                                    ImePrezimePolaznika = p.ImePrezime,
                                    Nazivtecaj = t.Naziv
                                };

            foreach (var rezultat in qs_inner_join)
            {
                Console.WriteLine($"Tecaj: {rezultat.Nazivtecaj} polaznik: {rezultat.ImePrezimePolaznika}");
            }
            

        } 
    }
}
