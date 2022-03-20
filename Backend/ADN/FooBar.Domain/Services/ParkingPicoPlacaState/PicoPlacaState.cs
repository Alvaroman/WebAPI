using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FooBar.Domain.Services.ParkingPicoPlacaState
{
    public abstract class PicoPlacaState
    {
        protected int[,] Days = new int[5, 2] { { 6, 9 }, { 2, 3 }, { 4, 8 }, { 0, 7 }, { 5, 1 } };
        public abstract bool PicoPlacaValidator(string plate);
    }
}
