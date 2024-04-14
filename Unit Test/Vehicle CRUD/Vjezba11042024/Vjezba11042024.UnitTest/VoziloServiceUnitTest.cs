using Vjezba11042024.Service.Interface;
using Vjezba11042024.Models.Binding;

namespace Vjezba11042024.UnitTest
{
    public class VoziloServiceUnitTest : Vjezba11042024Setup
    {
        private readonly IVoziloService voziloService;

        public VoziloServiceUnitTest()
        {
            this.voziloService = GetVoziloService();
        }

        [Fact]
        public void AddVehicle_AddsNewVehicleToTheBAse_ReturnsPopulatedViewModel()
        {

            var result = voziloService.AddVehicle(new Models.Binding.VoziloBinding
            {
                BrojVrata = 5,
                Marka = "Škoda",
                Model = "Scala",
                Tip = "1.0"
            });

            Assert.NotNull(result);

        }

        [Fact]
        public void GetAllVehicles_GetsAllVehiclesFromBase_ReturnsGeneratedVehicleList()
        {
            var result = voziloService.GetAllVehicles();
            Assert.NotEmpty(result);
            Assert.Equal(5, result.Count);
        }

        [Fact]
        public void DeleteVehicle_GetsAllVehiclesFromBaseAndDeletesTheFirstVehicle_VehicleIsDeletedfromTheBase()
        {
            var vehicles = voziloService.GetAllVehicles();
            int vehicleIdForDeletion = vehicles[0].Id;
            Assert.NotEmpty(vehicles);
            Assert.Equal(5, vehicles.Count);

            voziloService.DeleteVehicle(vehicleIdForDeletion);
            vehicles = voziloService.GetAllVehicles();

            var deletedVehicle = vehicles.FirstOrDefault(y => y.Id == vehicleIdForDeletion);
            Assert.Null(deletedVehicle);
        }

        [Fact]
        public void GetVehicles_GetVehicleFromBase_ReturnsObjectFromThebase()
        {
            var vehicles = voziloService.GetAllVehicles();
            int vehicleId = vehicles[0].Id;

            var vehicle = voziloService.GetVehicle(vehicleId);
            Assert.NotNull(vehicle);
        }

        [Fact]
        public void UpdateVehicle_GetsVehicleFromTheBaseThroughId_ReturnsAnUpdatedObjectFromThebase()
        {
            var vehicles = voziloService.GetAllVehicles();
            int vehicleForUpdate = vehicles[0].Id;

            VoziloUpdateBinding input = new VoziloUpdateBinding
            {
                BrojVrata = 5,
                Marka = "Ford",
                Model = "Focus",
                Tip = "1.9 TDCi",
                Id = vehicleForUpdate
            };

            voziloService.UpdateVehicle(input);

            var vehicle = voziloService.GetVehicle(vehicleForUpdate);
            Assert.NotNull(vehicle);

            Assert.Equal(input.Marka, vehicle.Marka);

        }
    }
}
