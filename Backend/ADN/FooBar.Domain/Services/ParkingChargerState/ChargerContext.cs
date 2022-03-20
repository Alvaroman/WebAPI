using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FooBar.Domain.Services.ParkingChargerState
{
    public class ChargerContext
    {
        public ChargerState State { get; set; } = default!;
        public decimal CalculateCharge(int spentHours) => this.State.Calculate(spentHours);
    }
}
