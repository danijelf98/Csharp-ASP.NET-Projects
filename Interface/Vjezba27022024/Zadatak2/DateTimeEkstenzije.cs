namespace Zadatak2
{
    public static class DateTimeEkstenzije
    {
        public static void IspisDana(this DateTime datum)
        {
            Console.WriteLine($"Odabrani dan je: {datum.DayOfWeek}");
        }

        public static void Period(this DateTime datum)
        {
            int brojProteklihGodina = DateTime.Now.Year - datum.Year;
            if (brojProteklihGodina > 1)
            {
                Console.WriteLine($"Proslo je {brojProteklihGodina} godina!");
                return;
            }
            Console.WriteLine("Datum nije valjan");
        }
    }
}
