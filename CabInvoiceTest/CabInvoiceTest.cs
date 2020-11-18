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
    }
}