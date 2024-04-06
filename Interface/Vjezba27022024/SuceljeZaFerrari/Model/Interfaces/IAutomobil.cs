namespace SuceljeZaFerrari.Model.Interfaces
{
    public interface IAutomobil
    {
        string Model { get; }
        string Vozac { get; }

        string Kocnice();
        string Gorivo();
    }
}
