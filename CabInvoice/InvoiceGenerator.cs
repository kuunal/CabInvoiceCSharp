using CabInvoice.Enums;
using System;

namespace CabInvoice
{
    public class InvoiceGenerator
    {
        RideRepository rideRepository = new RideRepository();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public double GenerateFare(double distance, int time, RIDETYPE type= RIDETYPE.NORMAL_RIDE)
        {
            return type.CalculateFare(distance, time);
        }

        public double GenerateAverageFare(Ride[] rides, RIDETYPE type = RIDETYPE.NORMAL_RIDE)
        {
            double total = 0;
            foreach(Ride ride in rides)
            {
                total += GenerateFare(ride.distance, ride.time, type);
            }
            return total/rides.Length;
        }

        public InvoiceSummary GetInvoiceSummary(Ride[] rides, RIDETYPE type = RIDETYPE.NORMAL_RIDE)
        {
            return new InvoiceSummary(rides.Length, GenerateAverageFare(rides, type));
        }

        public InvoiceSummary GetInvoiceByUserId(string userid, RIDETYPE type = RIDETYPE.NORMAL_RIDE)
        {
           Ride[] rides = rideRepository.GetRides(userid);
            return GetInvoiceSummary(rides, type);
        }

        public void AddUserRides(string userid, Ride[] ride)
        {
            rideRepository.AddUser(userid, ride);   
        }
    }
}
