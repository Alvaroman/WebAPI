using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FooBar.Domain.Services.ParkingChargerState
{
    public class CarCharger: ChargerState
    {
        protected override decimal HourCharge { get; set; } = 500;
        protected override decimal DayCharge { get; set; } = 4000;

    }
}
