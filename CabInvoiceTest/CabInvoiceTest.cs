using CabInvoice;
using CabInvoice.Enums;
using CabInvoice.Exceptions;
using NUnit.Framework;

namespace CabInvoiceTest
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenDistanceAndTime_WhenToCalculateFare_ShouldReturnFare()
        {
            double fare = invoiceGenerator.GenerateFare(2, 5);
            Assert.AreEqual(25, fare);
        }

        [Test]
        public void GivenDistanceAndTime_WhenToCalculateMinimumFare_ShouldReturnMinimumFare()
        {
            double fare = invoiceGenerator.GenerateFare(0.1, 1);
            Assert.AreEqual(5, fare);
        }

        [Test]
        public void GivenDistanceAndTime_WhenToCalculateForMultipleFare_ShouldReturnAverageFare()
        {
            Ride[] rides = {
            new Ride(2.0,5),
            new Ride(0.1,1)
            };
            Assert.AreEqual(15, invoiceGenerator.GenerateAverageFare(rides));
        }

        [Test]
        public void GivenMultipleRides_WhenToCalculate_ShouldReturnsInvoiceSummary()
        {
            Ride[] rides = {
            new Ride(2.0,5),
            new Ride(0.1,1)
            };
            InvoiceSummary invoiceSummary = invoiceGenerator.GetInvoiceSummary(rides);
            InvoiceSummary invoiceSummary1 = new InvoiceSummary(2, 15);
            Assert.AreEqual(invoiceSummary, invoiceSummary1);
        }
        
        [Test]
        public void givenUserId_WhenCorrect_ShouldReturnsInvoiceSummary()
        {
            string userid = "1";
            Ride[] rides = {
            new Ride(2.0,5),
            new Ride(0.1,1)
            };
            invoiceGenerator.AddUserRides(userid, rides);
            InvoiceSummary invoiceSummary = invoiceGenerator.GetInvoiceByUserId(userid);
            InvoiceSummary invoiceSummary1 = new InvoiceSummary(2, 15);
            Assert.IsTrue(invoiceSummary.Equals(invoiceSummary1));
        }

        [Test]
        public void givenUserId_WhenInCorrect_ShouldThrowNoSuchUserException()
        {
            try { 
                InvoiceSummary invoiceSummary = invoiceGenerator.GetInvoiceByUserId("4");
                InvoiceSummary invoiceSummary1 = new InvoiceSummary(2, 15);
                Assert.AreEqual(invoiceSummary, invoiceSummary1);
            }catch(CabInvoiceExceptions e) {
                Assert.AreEqual(e.exceptionType, ExceptionEnums.ExceptionType.NO_SUCH_USER);
            }
        }

        [Test]
        public void GivenPremiumRide_WhenToCalculateFare_ShouldReturnPremiumFare()
        {
            string userid = "2";
            Ride[] rides = {
            new Ride(3,3)
            };
            invoiceGenerator.AddUserRides(userid, rides);
            InvoiceSummary invoiceSummary = invoiceGenerator.GetInvoiceByUserId(userid, RIDETYPE.PREMUIM_RIDE);
            InvoiceSummary invoiceSummary1 = new InvoiceSummary(1, 51);
            Assert.AreEqual(invoiceSummary, invoiceSummary1);
        }

        [Test]
        public void GivenPremiumRide_WhenToCalculateMinimumFare_ShouldReturnPremiumMinimumFare()
        {
            string userid = "10";
            Ride[] rides = {
            new Ride(0.1,1)
            };
            invoiceGenerator.AddUserRides(userid, rides);
            InvoiceSummary invoiceSummary = invoiceGenerator.GetInvoiceByUserId(userid, RIDETYPE.PREMUIM_RIDE);
            InvoiceSummary invoiceSummary1 = new InvoiceSummary(1, 20);
            Assert.AreEqual(invoiceSummary, invoiceSummary1);
        }
    }
}