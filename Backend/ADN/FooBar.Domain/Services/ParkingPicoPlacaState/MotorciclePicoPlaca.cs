namespace FooBar.Domain.Services.ParkingPicoPlacaState
{
    public class MotorciclePicoPlaca : PicoPlacaState
    {
        public override bool PicoPlacaValidator(string plate)
        {
            int[] currentRestrictions = { Days[(int)DateTime.Today.DayOfWeek, 0], Days[(int)DateTime.Today.DayOfWeek, 1] };
            int numberToValidate = Convert.ToInt16(plate.Substring(plate.Length - 3));
            return !currentRestrictions.Contains(numberToValidate);
        }
    }
}
