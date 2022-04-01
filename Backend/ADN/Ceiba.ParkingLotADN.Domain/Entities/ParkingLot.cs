using Ceiba.ParkingLotADN.Domain.Entities.Base;
using Ceiba.ParkingLotADN.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Ceiba.ParkingLotADN.Domain.Entities
{
    public class ParkingLot : EntityBase<Guid>
    {
        [Range(1, 2, ErrorMessage = "Please enter a valid vehicle type.")]
        public int VehicleType { get; set; } = default!;
        [StringLength(7, ErrorMessage = "Please enter a valid plate.")]
        public string Plate { get; set; } = default!;
        public int Cylinder { get; set; } = default!;
        public bool Status { get; set; } = default!;
        public DateTime StartedAt { get; set; } = default!;
        public DateTime? FinishedAt { get; set; } = default!;

        /// <summary>
        /// Validate the allowed vehicle types.
        /// </summary>
        /// <returns>Boolean.</returns>
        public bool IsVehicleAllowed() => Enum.IsDefined(typeof(VehicleType), this.VehicleType);


    }
}
