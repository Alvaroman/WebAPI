namespace Ceiba.ParkingLotADN.Domain.Services.ParkingChargerState
{
    public class CarCharger : ChargerState
    {
        protected override decimal HourCharge { get; set; } = 1000;
        protected override decimal DayCharge { get; set; } = 8000;
        protected override bool CylinderRestriction { get; set; } = false;
        protected override decimal CylinderOverCharge { get; set; } = 0;
        protected override decimal CylinderLimit { get; set; } = 0;
    }
}
