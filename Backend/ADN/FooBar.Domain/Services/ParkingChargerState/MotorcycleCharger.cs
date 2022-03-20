namespace FooBar.Domain.Services.ParkingChargerState
{
    public class MotorcycleCharger : ChargerState
    {
        protected override decimal HourCharge { get; set; } = 500;
        protected override decimal DayCharge { get; set; } = 4000;
        private decimal CylinderOverCharge = 2000;

        public override decimal Calculate(int spentHours) => base.Calculate(spentHours) + CylinderOverCharge;

    }
}
