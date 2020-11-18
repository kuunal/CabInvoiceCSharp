using CabInvoice;
using NUnit.Framework;

namespace CabInvoiceTest
{
    public class Tests
    {
        Program program = new Program();
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenDistanceAndTime_WhenToCalculateFare_ShouldReturnFare()
        {
            double fare = program.GenerateFare(2, 5);
            Assert.AreEqual(25, fare);
        }

        [Test]
        public void GivenDistanceAndTime_WhenToCalculateMinimumFare_ShouldReturnMinimumFare()
        {
            double fare = program.GenerateFare(0.1, 1);
            Assert.AreEqual(5, fare);
        }

        [Test]
        public void GivenDistanceAndTime_WhenToCalculateForMultipleFare_ShouldReturnAverageFare()
        {
            Ride[] rides = {
            new Ride(2.0,5),
            new Ride(0.1,1)
            };
            Assert.AreEqual(15, program.GenerateAverageFare(rides));
        }

        [Test]
        public void GivenMultipleRides_WhenToCalculate_ShouldReturnsInvoiceSummary()
        {
            Ride[] rides = {
            new Ride(2.0,5),
            new Ride(0.1,1)
            };
            InvoiceSummary invoiceSummary = program.GetInvoiceSummary(rides);
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
            program.AddUserRides(userid, rides);
            InvoiceSummary invoiceSummary = program.GetInvoiceByUserId("2");
            InvoiceSummary invoiceSummary1 = new InvoiceSummary(2, 15);
            Assert.AreEqual(invoiceSummary, invoiceSummary1);
        }
    }
}