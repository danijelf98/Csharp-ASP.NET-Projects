namespace Zadatak2
{
    public static class StringEkstenzije
    {
        public static void IspisiBrojZnakova(this string unos)
        {
            Console.WriteLine($"Uneseni string '{unos}' ima: {unos.Count()} znakova");
        }
        public static void ObrnutiString(this string unos)
        {
            string obrnuto = string.Empty;

            foreach (var znak in unos.Reverse())
            {
                obrnuto += znak;
            }
            Console.WriteLine($"Uneseni string obrnuto je: {obrnuto}");
        }
    }
}
