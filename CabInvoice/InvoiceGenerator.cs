using CabInvoice.Enums;
using System;

namespace CabInvoice
{
    /// <summary>
    /// Responsible for generating fare for the user.
    /// </summary>
    public class InvoiceGenerator
    {
        RideRepository rideRepository = new RideRepository();

        /// <summary>
        /// Dummy test method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// Returns the generated fare based on type.
        /// </summary>
        /// <param name="distance">Distance in km.</param>
        /// <param name="time">Time in minutes.</param>
        /// <param name="type">Type of ride.</param>
        /// <returns></returns>
        public double GenerateFare(double distance, int time, RIDETYPE type= RIDETYPE.NORMAL_RIDE)
        {
            return type.CalculateFare(distance, time);
        }

        /// <summary>
        /// Generates and returns average fare of total rides.
        /// </summary>
        /// <param name="rides">Array of object Ride providing multiple rides.</param>
        /// <param name="type">Type of ride.</param>
        /// <returns></returns>
        public double GenerateAverageFare(Ride[] rides, RIDETYPE type = RIDETYPE.NORMAL_RIDE)
        {
            double total = 0;
            foreach(Ride ride in rides)
            {
                total += GenerateFare(ride.distance, ride.time, type);
            }
            return total/rides.Length;
        }

        /// <summary>
        /// Returns the generated invoice summary of given rides.
        /// </summary>
        /// <param name="rides">Array of object Ride for providing multiple rides.</param>
        /// <param name="type">Type of ride.</param>
        /// <returns></returns>
        public InvoiceSummary GetInvoiceSummary(Ride[] rides, RIDETYPE type = RIDETYPE.NORMAL_RIDE)
        {
            return new InvoiceSummary(rides.Length, GenerateAverageFare(rides, type));
        }

        /// <summary>
        /// Returns the generated invoice based on userid. 
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public InvoiceSummary GetInvoiceByUserId(string userid, RIDETYPE type = RIDETYPE.NORMAL_RIDE)
        {
           Ride[] rides = rideRepository.GetRides(userid);
            return GetInvoiceSummary(rides, type);
        }

        /// <summary>
        /// Adds user into ride repository.
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="ride"></param>
        public void AddUserRides(string userid, Ride[] ride)
        {
            rideRepository.AddUser(userid, ride);   
        }
    }
}
