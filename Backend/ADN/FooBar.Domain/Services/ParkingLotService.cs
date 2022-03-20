using FooBar.Domain.Entities;
using FooBar.Domain.Enums;
using FooBar.Domain.Exception;
using FooBar.Domain.Extentions;
using FooBar.Domain.Ports;
using FooBar.Domain.Services.ParkingChargerState;

namespace FooBar.Domain.Services
{
    [DomainService]
    public class ParkingLotService
    {
        readonly IGenericRepository<ParkingLot> _repository;
        private readonly ChargerContext _chargerContext;

        public ParkingLotService(IGenericRepository<ParkingLot> repository, ChargerContext chargerContext)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository), "No repo available");
            this._chargerContext = chargerContext;
        }


        public async Task<ParkingLot> RegisterParkingLotAsync(ParkingLot parkingLot)
        {
            if (!parkingLot.IsVehicleAllowed())
                throw new VehicleNotAllowed("You must register a valid vehicle type");

            if (!parkingLot.Plate.ValidatePicoPlaca())
                throw new PicoPlacaException("Your vehicle is not allowed due to 'pico y placa' rule");

            return await _repository.AddAsync(parkingLot);
        }

        public async Task<decimal> ReleaseParkingLotAsync(Guid id)
        {
            var model = await _repository.GetByIdAsync(id);
            model.FinishedAt = DateTime.Now;
            model.Status = false;

            await _repository.UpdateAsync(model);
            return _chargerContext.CalculateCharge((model.FinishedAt.Value - model.StartedAt).Hours, (VehicleType)model.VehicleType);
        }
    }
}
