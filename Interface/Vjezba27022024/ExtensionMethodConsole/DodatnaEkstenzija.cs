using ExtensionMethodConsole.Model;

namespace ExtensionMethodConsole
{
    public static class DodatnaEkstenzija
    {
        public static void DodatnaMetodaEkstenzija(this ObicnaKlasa objektObicneKlase)
        {
            Console.WriteLine("Ja sam prosirena metoda klase ObicnaKlasa koju je kreirao jedan programer.");
        }
    }
}
