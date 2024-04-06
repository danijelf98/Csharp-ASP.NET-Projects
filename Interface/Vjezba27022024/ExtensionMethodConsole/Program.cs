using ExtensionMethodConsole.Model;

namespace ExtensionMethodConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ObicnaKlasa jedna_obicna_klasa = new ObicnaKlasa();
            Console.WriteLine(jedna_obicna_klasa.Ispis());
            Console.WriteLine(jedna_obicna_klasa.Printanje());

            jedna_obicna_klasa.DodatnaMetodaEkstenzija();
        }
    }
}
