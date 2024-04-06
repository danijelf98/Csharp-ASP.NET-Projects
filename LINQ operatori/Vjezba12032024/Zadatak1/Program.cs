using Zadatak1.Model;

namespace Zadatak1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //napraviti 2 liste jedna od Proizvod a druga od SkladisniProizvod
            //napraviti anoonimni tip podataka koji objedinjuje 2 liste

            List<Prozivodi> ListaProzivoda = new List<Prozivodi> {
                new Prozivodi() { Naziv = "Proizvod1", Kolicina = 2, SifraProizvoda = 1, TipProizvoda = TipProizvoda.Tehnika },
                new Prozivodi() { Naziv = "Proizvod2", Kolicina = 3, SifraProizvoda = 2, TipProizvoda = TipProizvoda.PekarskiProizvodi },
                new Prozivodi() { Naziv = "Proizvod3", Kolicina = 1, SifraProizvoda = 3, TipProizvoda = TipProizvoda.Deterdenti },
                new Prozivodi() { Naziv = "Proizvod4", Kolicina = 7, SifraProizvoda = 2113, TipProizvoda = TipProizvoda.Deterdenti }
            };

            List<SkladisniProzivod> listaSkladisnihProizvoda = new List<SkladisniProzivod> {
                new SkladisniProzivod() { Naziv = "SKLProizvod1", Kolicina = 2, IdProizvoda = 1, TipProizvoda = TipProizvoda.Tehnika },
                new SkladisniProzivod() { Naziv = "SKLProizvod2", Kolicina = 3, IdProizvoda = 2, TipProizvoda = TipProizvoda.PekarskiProizvodi },
                new SkladisniProzivod() { Naziv = "SKLProizvod3", Kolicina = 1, IdProizvoda = 3, TipProizvoda = TipProizvoda.Deterdenti }
            };

            var ms_inner_join = ListaProzivoda.Join( //vanjski izvor podataka
                listaSkladisnihProizvoda, //unutarnji izvor podataka
                proizvod => proizvod.SifraProizvoda, //vanjski kljuc slekcija (prvi ID koji uparujemo)
                skladisniProizvod => skladisniProizvod.IdProizvoda, //unutranji kljuc slekcija (drugi Id koji uparujemo)
                (proizvod, skladisniProizvod) => new // slijed za format rezultata
                { 

                    Naziv = proizvod.Naziv,
                    Tip = proizvod.TipProizvoda,
                    Sifra = skladisniProizvod.IdProizvoda,
                    PrisutanNaSkladistu = true

                });

            foreach (var item in ms_inner_join)
            {
                Console.WriteLine(item);
            }
        }
    }
}
