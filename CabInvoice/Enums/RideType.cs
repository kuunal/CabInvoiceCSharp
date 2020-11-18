using CabInvoice.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoice.Enums
{
    public enum RIDETYPE
    {
        NORMAL_RIDE,
        PREMUIM_RIDE
    }

    public static class Fare
    {
        const int NORMAL_COST_PER_KILOMETER = 10;
        const int NORMAL_COST_PER_MINUTE = 1;
        const int NORMAL_MINIMUM_FARE = 5;

        const int PREMIUM_COST_PER_KILOMETER = 15;
        const int PREMIUM_COST_PER_MINUTE = 2;
        const int PREMIUM_MINIMUM_FARE = 20;

        public static double CalculateFare(this RIDETYPE rideType, double distance, int time)
        {
            switch (rideType)
            {
                case RIDETYPE.NORMAL_RIDE:
                    return Math.Max(NORMAL_COST_PER_KILOMETER * distance + time * NORMAL_COST_PER_MINUTE, NORMAL_MINIMUM_FARE);
                case RIDETYPE.PREMUIM_RIDE:
                    return Math.Max(PREMIUM_COST_PER_KILOMETER * distance + time * PREMIUM_COST_PER_MINUTE, PREMIUM_MINIMUM_FARE);
                default:
                    throw new CabInvoiceExceptions(ExceptionEnums.ExceptionType.INVALID_RIDE_TYPE);
            }
        }
    }
}
