using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Vjezba11042024.Context;
using Vjezba11042024.Models.Dbo;
using Vjezba11042024.Service.Implementations;
using Vjezba11042024.Service.Interface;

namespace Vjezba11042024.UnitTest
{
    public abstract class Vjezba11042024Setup
    {
        protected IMapper Mapper { get; private set; }

        protected ApplicationDbContext InMemoryDbContext;

        public Vjezba11042024Setup()
        {
            SetupInMemoryDbContext();
            GenerateVehicleList(5);

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Mapping.MappingProfile());
            });
            Mapper = mappingConfig.CreateMapper();
        }

        protected IVoziloService GetVoziloService(ApplicationDbContext? db = null)
        {
            if (db != null)
            {
                return new VoziloService(Mapper, db);
            }

            return new VoziloService(Mapper, InMemoryDbContext);
        }
        private void SetupInMemoryDbContext()
        {
            var inMemoryOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            InMemoryDbContext = new ApplicationDbContext(inMemoryOptions);
        }

        private List<Vozilo> GenerateVehicleList(int quantity)
        {
            List<Vozilo> vehicleList = new List<Vozilo>();
            Random random = new Random();
            for (int i = 1; i <= quantity; i++)
            {
                vehicleList.Add(

                new Vozilo
                {
                    BrojVrata = random.Next(1, 5),
                    Marka = $"Marka pod brojem {i}",
                    Model = $"Model pod brojem {i}",
                    Tip = $"Tip pod brojem {i}"
                }

                );
            }
            
            InMemoryDbContext.AddRange( vehicleList );
            InMemoryDbContext.SaveChanges();
            return vehicleList;
        }
    }
}
