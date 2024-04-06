namespace Linq_Group_Join.Model
{
    public class Polaznik
    {
        public int Id { get; set; }
        public string ImePrezime { get; set; }
        public int TecajID { get; set; }
    }

    public class Tecaj
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
    }
}
