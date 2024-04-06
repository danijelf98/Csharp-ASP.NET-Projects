using System.Runtime.CompilerServices;

namespace ExtensionMethodsPrimjer
{
    public static class DodajEkstenziju
    {
        public static bool JeVeciOd(this int i, int broj)
        {
             return i > broj;
        }
    }
}
