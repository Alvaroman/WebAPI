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
            int[] currentRestrictions = { Days[(int)DateTime.Today.DayOfWeek, 0], Days[(int)DateTime.Today.DayOfWeek, 1] };
            int numberToValidate = Convert.ToInt16(plate.Last());
            return !currentRestrictions.Contains(numberToValidate);
        }
    }
}
