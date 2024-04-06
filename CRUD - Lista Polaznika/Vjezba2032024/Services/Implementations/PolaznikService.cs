using AutoMapper;
using Vjezba2032024.Models.Binding;
using Vjezba2032024.Models.Dbo;
using Vjezba2032024.Models.ViewModel;
using Vjezba2032024.Services.Interfaces;

namespace Vjezba2032024.Services.Implementations
{
    public class PolaznikService : IPolaznikService
    {
        private readonly IMapper mapper;
        private static List<Polaznik> polaznici = new List<Polaznik>
        {
            new Polaznik
            {
                Id = 1,
                Ime = "Polaznik Ime 1",
                Prezime = "Polaznik Prezime 1",
                Oib = "12345678901"
            },
            new Polaznik
            {
                Id = 2,
                Ime = "Polaznik Ime 2",
                Prezime = "Polaznik Prezime 2",
                Oib = "12345678901"
            },
           new Polaznik
            {
                Id = 3,
                Ime = "Polaznik Ime 3",
                Prezime = "Polaznik Prezime 3",
                Oib = "12345678901"
            }


        };

        public PolaznikService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        #region Definicija modela
        //Klasa koja se vraca iz metode
        //PolaznikViewModel

        //Klasa koja glumi tablicu u bazi, ostaje samo unutar servisne klase
        //Polaznik

        //Koristimo je za unos podataka (argument u metodi).
        //Nikad ne vracamo kao rezultat vec je ona uvijek samo argument/parametar metodi
        //PolaznikBinding

        //Slicno kao i kod Binding, samo što ju koristimo za update zapisa u bazi,
        //Nikad ne vracamo kao rezultat vec je ona uvijek samo argument/parametar metodi
        //PolaznikUpdateBinding
        #endregion



        ///// <summary>
        ///// Uredi polaznika
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //public PolaznikViewModel UrediPolaznika(PolaznikUpdateBinding model)
        //{
        //    Polaznik dbo = polaznici.FirstOrDefault(p => p.Id == model.Id);
        //    dbo.Prezime = model.Prezime;
        //    dbo.Oib = model.Oib;
        //    dbo.Ime = model.Ime;
        //    //db.SaveChanges();

        //    return new PolaznikViewModel { Id = dbo.Id, Ime = dbo.Ime, Oib = dbo.Oib, Prezime = dbo.Prezime };
        //}



        /// <summary>
        /// Uredi polaznika
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PolaznikViewModel UrediPolaznika(PolaznikUpdateBinding model)
        {
            Polaznik dbo = polaznici.FirstOrDefault(p => p.Id == model.Id);
            mapper.Map(model, dbo);
            //db.SaveChanges();
            return mapper.Map<PolaznikViewModel>(dbo);
        }




        private int GenerirajId()
        {

            if (!polaznici.Any())
            {
                return 1;
            }

            return polaznici.OrderByDescending(y => y.Id).First().Id+1;

        }

        ///// <summary>
        ///// Spremi polaznika putem modela
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //public PolaznikViewModel SpremiPolaznika(PolaznikBinding model)
        //{

        //    Polaznik dbo = new Polaznik
        //    {
        //        Id = GenerirajId(),
        //        Ime = model.Ime,
        //        Prezime = model.Prezime,
        //        Oib = model.Oib,
        //    };


        //    polaznici.Add(dbo);
        //    //db.SaveChanges();
        //    return new PolaznikViewModel { Id = dbo.Id, Ime = dbo.Ime, Oib = dbo.Oib, Prezime = dbo.Prezime };

        //}



        /// <summary>
        /// Spremi polaznika putem modela
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PolaznikViewModel SpremiPolaznika(PolaznikBinding model)
        {

            var dbo = mapper.Map<Polaznik>(model);
            dbo.Id = GenerirajId();
            polaznici.Add(dbo);
            //db.SaveChanges();
            return mapper.Map<PolaznikViewModel>(dbo);

        }

        //public List<PolaznikViewModel> DohvatiPolaznike()
        //{
        //    return polaznici
        //        .Select(y => new PolaznikViewModel
        //        {
        //            Id = y.Id,
        //            Ime = y.Ime,
        //            Prezime = y.Prezime,
        //            Oib = y.Oib
        //        })
        //        .ToList();
        //}


        public List<PolaznikViewModel> DohvatiPolaznike()
        {
            return polaznici.Select(y => mapper.Map<PolaznikViewModel>(y)).ToList();
        }



        ///// <summary>
        ///// Dohvati polaznika po Idu
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //PolaznikViewModel DohvatiPolaznika(int id)
        //{
        //    Polaznik dbo = polaznici.FirstOrDefault(p => p.Id == id);

        //    return new PolaznikViewModel { Id = dbo.Id, Ime = dbo.Ime, Oib = dbo.Oib, Prezime = dbo.Prezime };
        //}


        /// <summary>
        /// Dohvati polaznika po Idu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PolaznikViewModel DohvatiPolaznika(int id)
        {
            Polaznik dbo = polaznici.FirstOrDefault(p => p.Id == id);
            return mapper.Map<PolaznikViewModel>(dbo);
        }

        /// <summary>
        /// Obrisi polaznika
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ObrisiPolaznika(int id)
        {

            try
            {
                var polaznik = polaznici.FirstOrDefault(x => x.Id == id);
                if (polaznik == null)
                {
                    return false;
                }

                polaznici.Remove(polaznik);

                return true;
            }
            catch
            {

                return false; ;
            }

        }


    }
}
