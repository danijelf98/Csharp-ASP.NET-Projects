namespace Zadatak2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Napraviti ekstenziju stringa, koji ce ispisati u konzoli broj nakova
            string ispis = "IspisZnakova";
            ispis.IspisiBrojZnakova();

            // Napraviti ekstenziju stringa, koji e ispisati obrnuto ono sto je uneseno
            ispis.ObrnutiString();
            Console.WriteLine();

            // Napraviti ekstenziju datetime, koja ispisuje u konzoli koji je dan u tjednu
            DateTime datum = DateTime.Now.AddYears(-3);
            datum.IspisDana();
            datum.Period();
            DateTime.Now.AddYears(20).Period();

            // Napraviti ekstenziju DateTime, koliko je godina proslo od danas do unesene godine
            // Ako je godina u minusu, ispisite da je neispravan unos godine
        }
    }
}
