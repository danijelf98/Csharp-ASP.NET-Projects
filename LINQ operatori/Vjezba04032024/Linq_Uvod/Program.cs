namespace Linq_Uvod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============================================================================");
            Console.WriteLine("Primjer jednostavnog Linq upita nad nizom prezimena koji pretrazuje prezime");
            Console.WriteLine("============================================================================");

            string[] prezimena = { "matic", "Ivic", "Katalenic", "Programercic" };

            var nasLinqUpit = from prezime in prezimena
                              where prezime.Contains("Ivic")
                              select prezime;

            //funkcionira
            //var test = nasLinqUpit.ToList();

            foreach (var prezime in nasLinqUpit)
            {
                Console.WriteLine(prezime + " ");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("===============================================================");
            Console.WriteLine("Primjer linq upita nad nizom imena koji trazi slovo t u iimenu");
            Console.WriteLine("===============================================================");

            string[] imena = { "Ana", "Iva", "Kata", "Marijana", "Anita" };

            var pronadiImena = from ime in imena
                               where ime.Contains('t')
                               select ime;

            foreach (var ime in pronadiImena)
            {
                string ispis = ime;
                if (ime != pronadiImena.Last())
                {
                    ispis += ", ";
                }
                Console.WriteLine(ispis);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("================================================================================");
            Console.WriteLine("Primjer linq upita nad nizom brojeva koji moraju vratiti samo pozitivne brojeve");
            Console.WriteLine("================================================================================");

            int[] brojevi = { 3, 5, 9, 1, -5, -10, 2, 6, -1, 0 };

            var pozitivniBrojevi = from broj in brojevi
                                   where broj > 0
                                   select broj;

            foreach (var broj in pozitivniBrojevi)
            {
                Console.Write(broj + ", ");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("================================================================================");
            Console.WriteLine("Primjer linq upita nad nizom brojeva koji moraju vratiti brojeve izmedju -5 i 5");
            Console.WriteLine("================================================================================");

            var trazeniBrojevi = from broj in brojevi
                                 where broj >= -5 && broj <= 5
                                 select broj;

            foreach (var broj in trazeniBrojevi)
            {
                Console.Write(broj + ", ");
            }

            Console.WriteLine();
            Console.WriteLine();
        }

    }
}
