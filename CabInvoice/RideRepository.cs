// <copyright file="RideRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CabInvoice.Enums;
    using CabInvoice.Exceptions;

    /// <summary>
    /// Repository stores users and user's rides.
    /// </summary>
    public class RideRepository
    {
        /// <summary>
        /// Stores user and rides of that user.
        /// </summary>
        private Dictionary<string, List<Ride>> userDict = new Dictionary<string, List<Ride>>();

        /// <summary>
        /// Adds the user to dictionary by user id for records.
        /// </summary>
        /// <param name="userId">The userId.</param>
        /// <param name="rides">Array of object Ride containing multiple ride as Ride objects.</param>
        public void AddUser(string userId, Ride[] rides)
        {
            if (this.userDict.ContainsKey(userId))
            { 
                this.userDict[userId].AddRange(rides.ToList());
            }
            else
            { 
                this.userDict.Add(userId, rides.ToList());
            }
        }

        /// <summary>
        /// Gets the rides based on user id.
        /// </summary>
        /// <param name="userId">The userId.</param>
        /// <returns>Rides of given userId.</returns>
        /// <exception cref="CabInvoiceExceptions">If no user throws NO_SUCH_USER exception.</exception>
        public Ride[] GetRides(string userId)
        {
            try
            {
                return this.userDict[userId].ToArray();
            }
            catch (KeyNotFoundException)
            {
                throw new CabInvoiceExceptions(ExceptionEnums.ExceptionType.NO_SUCH_USER);
            }
        }
    }
}
