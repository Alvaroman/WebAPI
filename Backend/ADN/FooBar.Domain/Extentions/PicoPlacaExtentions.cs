using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FooBar.Domain.Extentions
{
    public static class PicoPlacaExtentions
    {
        /// <summary>
        /// Indicates wether the plate is in pico-placa or not.
        /// </summary>
        /// <param name="value">String value.</param>
        /// <returns></returns>
        public static bool ValidatePicoPlaca(this string value)
        {
            return true;
        }
    }
}
