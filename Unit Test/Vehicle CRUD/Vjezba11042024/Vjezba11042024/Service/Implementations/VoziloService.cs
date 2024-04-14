using AutoMapper;
using Vjezba11042024.Context;
using Vjezba11042024.Models.Binding;
using Vjezba11042024.Models.Dbo;
using Vjezba11042024.Models.ViewModel;
using Vjezba11042024.Service.Interface;

namespace Vjezba11042024.Service.Implementations
{
    public class VoziloService : IVoziloService
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext db;

        public VoziloService(IMapper mapper, ApplicationDbContext db)
        {
            this.mapper = mapper;
            this.db = db;
        }

        /// <summary>
        /// Add Vehicle
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public VoziloViewModel AddVehicle(VoziloBinding model)
        {
            var dbo = mapper.Map<Vozilo>(model);
            db.Vehicles.Add(dbo);
            db.SaveChanges();
            var response = mapper.Map<VoziloViewModel>(dbo);
            return response;
        }

        /// <summary>
        /// Gets All Vehicles
        /// </summary>
        /// <returns></returns>
        public List<VoziloViewModel> GetAllVehicles()
        {
            var dbo = db.Vehicles.ToList();
            return dbo.Select(y => mapper.Map<VoziloViewModel>(y)).ToList();
        }

        /// <summary>
        /// Gets a vehicle through Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VoziloViewModel GetVehicle(int id)
        {
            var dbo = db.Vehicles.Find(id);
            return mapper.Map<VoziloViewModel>(dbo);
        }

        /// <summary>
        /// Deletes the Vehicle
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VoziloViewModel DeleteVehicle(int id)
        {
            var dbo = db.Vehicles.Find(id);
            db.Vehicles.Remove(dbo);
            db.SaveChanges();
            return mapper.Map<VoziloViewModel>(dbo);
        }

        /// <summary>
        /// Updates vehicle from the base 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public VoziloViewModel UpdateVehicle(VoziloUpdateBinding model)
        {
            var dbo = db.Vehicles.Find(model.Id);
            mapper.Map(model, dbo);
            db.SaveChanges();

            return mapper.Map<VoziloViewModel>(dbo);
        }
    }
}
