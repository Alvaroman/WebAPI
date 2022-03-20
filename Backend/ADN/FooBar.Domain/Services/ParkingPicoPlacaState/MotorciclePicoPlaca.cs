namespace FooBar.Domain.Services.ParkingPicoPlacaState
{
    public class MotorciclePicoPlaca : PicoPlacaState
    {
        public override bool PicoPlacaValidator(string plate)
        {
            int[] currentRestrictions = { PICO_Y_PLACA_DAYS[(int)DateTime.Today.DayOfWeek, 0], PICO_Y_PLACA_DAYS[(int)DateTime.Today.DayOfWeek, 1] };
            int numberToValidate = Convert.ToInt16(plate.Substring(plate.Length - 3, 1));
            return !currentRestrictions.Contains(numberToValidate);
        }
    }
}
