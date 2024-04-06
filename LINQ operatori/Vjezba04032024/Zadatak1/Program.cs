namespace Zadatak1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Zadatak je napraviti listu boja
            //Prikazati boje korisniku i pitati koju boju zeli
            //Koristeci LINQ  filtrirati boju koju korisnik je odabrao
            //Postaviti kosirniku pitanje da odabere porvo slovo boje
            //koristeci liq ispisite sve boje koje pocinju sa slovom koje je korisnik unio

            string[] boje = { "plava", "crvena", "zuta", "zelena", "crna", "bijela" };

            Console.WriteLine("Odaberi jednu boju");
            Console.WriteLine();
            Console.WriteLine();

            foreach (var boja in boje)
            {
                Console.WriteLine(boja);
            }

            Console.WriteLine();
            Console.WriteLine();

            string odabirBoje = Console.ReadLine();

            if (string.IsNullOrEmpty(odabirBoje))
            {
                Console.WriteLine("Nisi unio boju");
            }

            //var odabranaBoja = boje.FirstOrDefault(y => y == odabirBoje);

            var ispis = from boja in boje
                        where boja == odabirBoje
                        select boja;

            //var ispisBoje = ispis.ToList()[0];

            Console.WriteLine();

            foreach (var boja in ispis)
            {
                Console.Write("Uniso si boju: " + boja);
            }
            Console.WriteLine();
        }
    }
}
