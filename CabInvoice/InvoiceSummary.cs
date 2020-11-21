// <copyright file="InvoiceSummary.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoice
{
    using CabInvoice;

    /// <summary>
    /// Generates invoice summary for given rides
    /// </summary>
    public class InvoiceSummary
    {
        /// <summary>
        /// The total number of rides
        /// </summary>
        private int totalRides;

        /// <summary>
        /// The total fare
        /// </summary>
        private double totalFare;

        /// <summary>
        /// The average fare per ride
        /// </summary>
        private double averageFare;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceSummary"/> class.
        /// </summary>
        /// <param name="totalRides">The total rides.</param>
        /// <param name="averageFare">The average fare.</param>
        public InvoiceSummary(int totalRides, double averageFare)
        {
            this.totalRides = totalRides;
            this.totalFare = averageFare * totalRides;
            this.averageFare = averageFare;
        }

        /// <summary>
        /// Determines whether the two InvoiceSummary objects are equal based on values.
        /// </summary>
        /// <param name="that">InvoiceSummary object to compare with this instance.</param>
        /// <returns>
        ///   true, if the both InvoiceSummary objects are equal; otherwise, false.
        /// </returns>
        public override bool Equals(object that)
        {
            if (this == that) 
            { 
                return true;
            }

            if (this == null) 
            { 
                return false;
            }

            InvoiceSummary obj = (InvoiceSummary)that;
            return this.averageFare == obj.averageFare
                && this.totalFare == obj.totalFare
                && this.totalRides == obj.totalRides; 
        }
    }
}