using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FooBar.Domain.Exception
{
    public class NonExistentVehicle : AppException
    {
        public NonExistentVehicle() { }
        public NonExistentVehicle(string message) : base(message) { }
        public NonExistentVehicle(string message, System.Exception inner) : base(message, inner) { }
        protected NonExistentVehicle(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
