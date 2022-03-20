using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FooBar.Domain.Services.ParkingPicoPlacaState
{
    public class CarPicoPlaca : PicoPlacaState
    {
        public override bool PicoPlacaValidator(string plate)
        {
            int[] currentRestrictions = { PICO_Y_PLACA_DAYS[(int)DateTime.Today.DayOfWeek, 0], PICO_Y_PLACA_DAYS[(int)DateTime.Today.DayOfWeek, 1] };
            int numberToValidate = Convert.ToInt16(plate.Last());
            return !currentRestrictions.Contains(numberToValidate);
        }
    }
}
