
using FooBar.Domain.Enums;
using FooBar.Domain.Exception;

namespace FooBar.Domain.Extentions
{
    public static class EnumExtentions
    {
        private static int CAR_CAPACITY = 20;
        private static int MOTORCYCLE_CAPACITY = 10;

        public static int GetParkingCapacity(this System.Enum value)
        {
            switch (value)
            {
                case VehicleType.Car: return CAR_CAPACITY;
                case VehicleType.Motorcycle: return MOTORCYCLE_CAPACITY;
                default:
                    throw new VehicleNotAllowed("This vehicle type is not considered");
            }
        }
    }
}
