using FooBar.Domain.Exception;
using FooBar.Domain.Ports;
using FooBar.Domain.Services;
using FooBar.Domain.Services.ParkingChargerState;
using FooBar.Domain.Services.ParkingPicoPlacaState;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Threading.Tasks;

namespace FooBar.Domain.Tests.ParkingLot
{
    [TestClass]
    public class ParkingLotServiceTest
    {
        IGenericRepository<FooBar.Domain.Entities.ParkingLot> _parkingLotRepository = default!;
        ParkingLotService _parkingLotService = default!;
        ChargerContext _chargerContext = default!;
        PicoPlacaContext _picoPlacaContext = default!;
        [TestInitialize]
        public void Init()
        {
            _parkingLotRepository = Substitute.For<IGenericRepository<FooBar.Domain.Entities.ParkingLot>>();
            _chargerContext = Substitute.For<ChargerContext>();
            _picoPlacaContext = Substitute.For<PicoPlacaContext>();
            _parkingLotService = new ParkingLotService(_parkingLotRepository, _chargerContext, _picoPlacaContext);
        }

        [TestMethod]
        public async Task FailToRegisterAnNotAllowedVehicle()
        {
            try
            {
                Domain.Entities.ParkingLot notAllowedVehicle = new()
                {
                    Cylinder = 0,
                    Plate = "abc-123",
                    StartedAt = System.DateTime.Now,
                    Status = false,
                    VehicleType = 3
                };
                await _parkingLotService.RegisterParkingLotAsync(notAllowedVehicle);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is VehicleNotAllowed);
            }
        }
        [TestMethod]
        public async Task FailToRegisterMotorcyclePicoPlaca()
        {
            try
            {
                Domain.Entities.ParkingLot notAllowedVehicle = new()
                {
                    Cylinder = 450,
                    Plate = "abc-623",
                    StartedAt = new System.DateTime(year: 2022, month: 03, day: 21),
                    Status = false,
                    VehicleType = 2
                };
                await _parkingLotService.RegisterParkingLotAsync(notAllowedVehicle);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is PicoPlacaException);
            }
        }
        [TestMethod]
        public async Task FailToRegisterCarPicoPlaca()
        {
            try
            {
                FooBar.Domain.Entities.ParkingLot parkingLotNowAllowed = new ParkingLotDataBuilder()
                  .WithCylinder(1800)
                  .WithVehicleType(1)
                  .WithStartAt(new System.DateTime(year: 2022, month: 03, day: 21))
                  .WithPlate("abc-126")
                  .WithStaus(false).Build();
                await _parkingLotService.RegisterParkingLotAsync(parkingLotNowAllowed);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is PicoPlacaException);
            }
        }
        [TestMethod]
        public async Task SuccessToRegisterParkingLot()
        {
            FooBar.Domain.Entities.ParkingLot parkingLot = new ParkingLotDataBuilder()
                    .WithCylinder(1600)
                    .WithVehicleType(1)
                    .WithStartAt(new System.DateTime(year: 2022, month: 03, day: 20))
                    .WithPlate("abc-123")
                    .WithStaus(false).Build();

            _parkingLotRepository.AddAsync(Arg.Any<FooBar.Domain.Entities.ParkingLot>()).Returns(Task.FromResult(parkingLot));

            var result = await _parkingLotService.RegisterParkingLotAsync(parkingLot);

            Assert.IsTrue(result is FooBar.Domain.Entities.ParkingLot && result?.Id is not null);
        }
        [TestMethod]
        public void SuccessToObtainCostCar()
        {
            var cost = _chargerContext.CalculateCharge(27, 1800, Enums.VehicleType.Car);
            Assert.IsTrue(11000 == cost);
        }
        [TestMethod]
        public void SuccessToObtainCostMotorcycle()
        {
            var cost = _chargerContext.CalculateCharge(10, 650, Enums.VehicleType.Motorcycle);
            Assert.IsTrue(6000 == cost);
        }
    }
}
