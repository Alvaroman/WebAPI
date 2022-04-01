namespace Ceiba.ParkingLotADN.Domain.Services.ParkingChargerState
{
    public class MotorcycleCharger : ChargerState
    {
        protected override decimal HourCharge { get; set; } = 500;
        protected override decimal DayCharge { get; set; } = 4000;
        protected override bool CylinderRestriction { get; set; } = true;
        protected override decimal CylinderOverCharge { get; set; } = 2000;
        protected override decimal CylinderLimit { get; set; } = 500;

    }
}
