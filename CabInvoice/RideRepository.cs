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

        public void AddUser(string userid, Ride[] rides)
        {
            if (userDict.ContainsKey(userid))
                userDict[userid].AddRange(rides.ToList());
            else
                userDict.Add(userid, rides.ToList());
        }

        public Ride[] GetRides(string userid)
        {
            try { 
                return userDict[userid].ToArray();
            }catch(Exception e)
            {
                throw new CabInvoiceExceptions(ExceptionEnums.ExceptionType.NO_SUCH_USER);
            }
        }
    }
}
