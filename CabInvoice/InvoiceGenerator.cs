// <copyright file="InvoiceGenerator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoice
{
    using System;
    using CabInvoice.Enums;

    /// <summary>
    /// Responsible for generating fare for the user.
    /// </summary>
    public class InvoiceGenerator
    {
        /// <summary>
        /// The ride repository object
        /// </summary>
        public RideRepository rideRepository = new RideRepository();

        /// <summary>
        /// Dummy test method
        /// </summary>
        /// <param name="args">Command line argument</param>
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
        /// <returns> Returns generated fare</returns>
        public double GenerateFare(double distance, int time, RIDETYPE type = RIDETYPE.NORMAL_RIDE)
        {
            return type.CalculateFare(distance, time);
        }

        /// <summary>
        /// Generates and returns average fare of total rides.
        /// </summary>
        /// <param name="rides">Array of object Ride providing multiple rides.</param>
        /// <param name="type">Type of ride.</param>
        /// <returns>Average fare for multiple rides</returns>
        public double GenerateAverageFare(Ride[] rides, RIDETYPE type = RIDETYPE.NORMAL_RIDE)
        {
            double total = 0;
            foreach (Ride ride in rides)
            {
                total += this.GenerateFare(ride.Distance, ride.Time, type);
            }

            return total / rides.Length;
        }

        /// <summary>
        /// Returns the generated invoice summary of given rides.
        /// </summary>
        /// <param name="rides">Array of object Ride for providing multiple rides.</param>
        /// <param name="type">Type of ride.</param>
        /// <returns>Invoice summary</returns>
        public InvoiceSummary GetInvoiceSummary(Ride[] rides, RIDETYPE type = RIDETYPE.NORMAL_RIDE)
        {
            return new InvoiceSummary(rides.Length, this.GenerateAverageFare(rides, type));
        }

        /// <summary>
        /// Returns the generated invoice based on userId. 
        /// </summary>
        /// <param name="userId">user id</param>
        /// <param name="type">enum type of ride</param>
        /// <returns>Invoice summary for given user id</returns>
        public InvoiceSummary GetInvoiceByuserId(string userId, RIDETYPE type = RIDETYPE.NORMAL_RIDE)
        {
           Ride[] rides = this.rideRepository.GetRides(userId);
           return this.GetInvoiceSummary(rides, type);
        }

        /// <summary>
        /// Adds user into ride repository.
        /// </summary>
        /// <param name="userId">user id</param>
        /// <param name="ride">array of ride object</param>
        public void AddUserRides(string userId, Ride[] ride)
        {
            this.rideRepository.AddUser(userId, ride);   
        }
    }
}
