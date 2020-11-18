using CabInvoice;

namespace CabInvoice
{
    public class InvoiceSummary
    {
        int totalRides;
        double totalFare;
        double averageFarePerRide;

        public InvoiceSummary(int totalRides, double AverageFare)
        {
            this.totalRides = totalRides;
            this.totalFare = AverageFare*totalRides;
            this.averageFarePerRide = AverageFare;
        }

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