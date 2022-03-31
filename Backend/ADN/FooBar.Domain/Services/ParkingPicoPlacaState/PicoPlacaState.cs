using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FooBar.Domain.Services.ParkingPicoPlacaState
{
    public abstract class PicoPlacaState
    {
        protected static readonly int[,] PICO_Y_PLACA_DAYS = new int[7, 2] { { -1, -1 }, { 6, 9 }, { 2, 3 }, { 4, 8 }, { 0, 7 }, { 5, 1 }, { -1, -1 } };
        protected static readonly int INITIAL_HOUR = 5;
        protected static readonly int FINAL_HOUR = 20;

        public abstract bool PicoPlacaValidator(string plate);
    }
}
