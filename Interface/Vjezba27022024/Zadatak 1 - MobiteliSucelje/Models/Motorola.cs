using Zadatak_1___MobiteliSucelje.Models.Interface;

namespace SuceljeZaFerrari.Model
{
    public class Motorola : ITelefon, IZaslon
    {
        public string Naziv { get; set; }
        public string Model { get; set; }
        public int GeneracijaMreza { get; set; }
        public bool OtisaPrstaNaEkranu { get; set; }

        public Motorola()
        {
            this.OtisaPrstaNaEkranu = false;
        }
    }
}
