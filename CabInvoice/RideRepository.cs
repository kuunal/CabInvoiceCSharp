using CabInvoice.Enums;
using CabInvoice.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CabInvoice
{
    public class RideRepository
    {
        Dictionary<string, List<Ride>> userDict = new Dictionary<string, List<Ride>>();


        /// <summary>
        /// Adds the user to dictionary by user id for records.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="rides">Array of object Ride containing multiple ride as Ride objects.</param>
        public void AddUser(string userid, Ride[] rides)
        {
            if (userDict.ContainsKey(userid))
                userDict[userid].AddRange(rides.ToList());
            else
                userDict.Add(userid, rides.ToList());
        }


        /// <summary>
        /// Gets the rides based on user id.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns>Rides of given userid.</returns>
        /// <exception cref="CabInvoiceExceptions">If no user throws NO_SUCH_USER exception.</exception>
        public Ride[] GetRides(string userid)
        {
            try { 
                return userDict[userid].ToArray();
            }catch(Exception)
            {
                throw new CabInvoiceExceptions(ExceptionEnums.ExceptionType.NO_SUCH_USER);
            }
        }
    }
}
