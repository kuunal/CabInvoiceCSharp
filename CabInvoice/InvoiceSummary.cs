using CabInvoice;

namespace CabInvoice
{
    public class InvoiceSummary
    {
        int totalRides;
        double totalFare;
        double averageFarePerRide;


        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceSummary"/> class.
        /// </summary>
        /// <param name="totalRides">The total rides.</param>
        /// <param name="AverageFare">The average fare.</param>
        public InvoiceSummary(int totalRides, double AverageFare)
        {
            this.totalRides = totalRides;
            this.totalFare = AverageFare*totalRides;
            this.averageFarePerRide = AverageFare;
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
                return true;
            if (this == null)
                return false;
            InvoiceSummary obj = (InvoiceSummary)that;
            return this.averageFarePerRide == obj.averageFarePerRide
                && this.totalFare == obj.totalFare
                && this.totalRides == obj.totalRides; 
        }
    }
}