﻿namespace Ceiba.ParkingLotADN.Domain.Services.ParkingChargerState
{
    public abstract class ChargerState
    {
        protected abstract decimal HourCharge { get; set; }
        protected abstract decimal DayCharge { get; set; }
        protected abstract bool CylinderRestriction { get; set; }
        protected abstract decimal CylinderOverCharge { get; set; }
        protected abstract decimal CylinderLimit { get; set; }

        public virtual decimal Calculate(int spentHours, int cylinder)
        {
            decimal charge = 0;
            if (spentHours < 9)
                charge = spentHours * HourCharge;
            else
            {
                do
                {
                    charge += DayCharge;
                    spentHours -= 24;
                } while (spentHours / 24 >= 1);
                if (spentHours > 0)
                    charge += spentHours * HourCharge;
            }
            if (CylinderRestriction && cylinder >= CylinderLimit)
                charge += CylinderOverCharge;

            return charge;
        }
    }
}
