// <copyright file="Ride.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoice
{
    /// <summary>
    /// Stores ride information
    /// </summary>
    public class Ride
    {
        /// <summary>
        /// The distance in km
        /// </summary>
        private double distance;
        
        /// <summary>
        /// The time in minutes
        /// </summary>
        private int time;

        /// <summary>
        /// Initializes a new instance of the <see cref="Ride"/> class.
        /// </summary>
        /// <param name="distance">The distance.</param>
        /// <param name="time">The time.</param>
        public Ride(double distance, int time)
        {
            this.Distance = distance;
            this.Time = time;
        }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public int Time
        {
            get
            {
                return this.time;
            }

            set
            {
                this.time = value;
            }
        }

        /// <summary>
        /// Gets or sets the distance.
        /// </summary>
        /// <value>
        /// The distance.
        /// </value>
        public double Distance
        {
            get
            {
                return this.distance;
            }

            set
            {
                this.distance = value;
            } 
        }
    }
}
