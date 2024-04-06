using SuceljeZaFerrari.Model.Interfaces;

namespace SuceljeZaFerrari.Model
{
    public class Ferrari : IAutomobil
    {
        public Ferrari(string vozac, string model)
        {
            Vozac = vozac;
            Model = model;
        }

        public string Model { get; private set; }
        public string Vozac { get; private set; }

        public string Gorivo()
        {
            return "Jako puno goriva";
        }

        public string Kocnice()
        {
            return "Koci";
        }
    }
}
