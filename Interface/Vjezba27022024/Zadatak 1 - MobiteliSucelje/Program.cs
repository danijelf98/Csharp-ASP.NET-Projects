using SuceljeZaFerrari.Model;
using Zadatak_1___MobiteliSucelje.Models.Interface;

namespace Zadatak_1___MobiteliSucelje
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<ITelefon> listaTelefona = new List<ITelefon>();
            listaTelefona.Add(new Motorola()
            {
                Naziv = typeof(Motorola).Name,
                Model = "T40",
                GeneracijaMreza = 3
            });
            listaTelefona.Add(new Nokia()
            {
                Naziv = typeof(Nokia).Name,
                Model = "A55",
                GeneracijaMreza = 4
            });
            listaTelefona.Add(new Samsung()
            {
                Naziv = typeof(Samsung).Name,
                Model = "s55",
                GeneracijaMreza = 5
            });

            foreach (var telefon in listaTelefona)
            {
                IspisTelefona(telefon);
            }
        }
        static void IspisTelefona(ITelefon telefon)
        {

            if (telefon.GeneracijaMreza > 3)
            {
                Console.WriteLine($"Telefon: {telefon.Naziv}, {telefon.Model}, Mreza: {telefon.GeneracijaMreza}");

                if (telefon is IZaslon)
                {
                    Console.WriteLine($"Telefon {telefon.Naziv} ima detalje o ekranu");
                }

                if (((IZaslon)telefon).OtisaPrstaNaEkranu)
                {
                    Console.WriteLine("Zaslon ima fingerprint");
                }
                Console.WriteLine();
            }
        }
    }
}
