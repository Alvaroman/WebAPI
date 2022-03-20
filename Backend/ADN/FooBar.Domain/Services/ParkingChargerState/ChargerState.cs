using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FooBar.Domain.Services.ParkingChargerState
{
    public abstract class ChargerState
    {
        protected abstract decimal HourCharge { get; set; }
        protected abstract decimal DayCharge { get; set; }
        public virtual decimal Calculate(int spentHours)
        {
            if (spentHours < 9)
                return spentHours * HourCharge;
            else
            {
                if (spentHours % 24 <= 1)
                {
                    return DayCharge;
                }
                else
                {
                    decimal timeCharge = 0;
                    do
                    {
                        timeCharge += DayCharge;
                        spentHours -= 24;
                    } while (spentHours % 24 > 1);
                    return timeCharge + spentHours * HourCharge;
                }
            }
        }
    }
}
