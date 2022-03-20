using FooBar.Domain.Entities;
using FooBar.Domain.Enums;
using FooBar.Domain.Exception;
using FooBar.Domain.Extentions;
using FooBar.Domain.Ports;
using FooBar.Domain.Services.ParkingChargerState;
using FooBar.Domain.Services.ParkingPicoPlacaState;

namespace FooBar.Domain.Services
{
    [DomainService]
    public class ParkingLotService
    {
        readonly IGenericRepository<ParkingLot> _repository;
        private readonly ChargerContext _chargerContext;
        private readonly PicoPlacaContext _picoPlacaContext;

        public ParkingLotService(IGenericRepository<ParkingLot> repository, ChargerContext chargerContext, PicoPlacaContext picoPlacaContext)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository), "No repo available");
            this._chargerContext = chargerContext ?? throw new ArgumentNullException(nameof(repository), "No repo available");
            this._picoPlacaContext = picoPlacaContext;
        }


        public async Task<ParkingLot> RegisterParkingLotAsync(ParkingLot parkingLot)
        {
            if (!parkingLot.IsVehicleAllowed())
                throw new VehicleNotAllowed("You must register a valid vehicle type");

            if (!_picoPlacaContext.ValidatePicoPlaca(parkingLot.Plate, (VehicleType)parkingLot.VehicleType))
                throw new PicoPlacaException("Your vehicle is not allowed due to 'pico y placa' rule");

            var vehiclesInUse = await _repository.GetAsync(x => x.Status && x.VehicleType == parkingLot.VehicleType);
            if (vehiclesInUse != null && vehiclesInUse.Any())
            {
                int maxCapacity = ((VehicleType)parkingLot.VehicleType).GetParkingCapacity();
                if (vehiclesInUse.Count() < maxCapacity)
                    return await _repository.AddAsync(parkingLot);
                else
                    throw new FullCapacityException("There is not capacity available for this type of vehicle");
            }
            else
                return await _repository.AddAsync(parkingLot);
        }

        public async Task<decimal> ReleaseParkingLotAsync(Guid id)
        {
            var model = await _repository.GetByIdAsync(id);
            model.FinishedAt = DateTime.Now;
            model.Status = false;

            await _repository.UpdateAsync(model);
            return _chargerContext.CalculateCharge((model.FinishedAt.Value - model.StartedAt).Hours, model.Cylinder, (VehicleType)model.VehicleType);
        }
    }
}
dding 