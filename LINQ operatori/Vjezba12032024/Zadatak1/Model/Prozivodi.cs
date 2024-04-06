namespace Zadatak1.Model
{
    public class Prozivodi
    {
        public string Naziv { get; set; }
        public int Kolicina { get; set; }
        public int SifraProizvoda { get; set; }
        public TipProizvoda TipProizvoda { get; set; }
    }

    public class SkladisniProzivod
    {
        public string Naziv { get; set; }
        public int Kolicina { get; set; }
        public int IdProizvoda { get; set; }
        public TipProizvoda TipProizvoda { get; set; }
    }

    public enum TipProizvoda
    {
        Tehnika,
        PekarskiProizvodi,
        Deterdenti
    }
}
