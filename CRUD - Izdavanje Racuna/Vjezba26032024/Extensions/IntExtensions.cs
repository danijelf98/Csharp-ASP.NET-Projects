namespace Vjezba26032024.Extensions
{
    public static class IntExtensions
    {
        public static string ToDocumentId(this int value)
        {
            return $"{value}-{DateTime.Now.Year}";
        }
    }
}
