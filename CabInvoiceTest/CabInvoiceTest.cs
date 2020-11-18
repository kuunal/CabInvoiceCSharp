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
        public void givenDistanceAndTime_WhenToCalculateFare_ShouldReturnFare()
        {
            double fare = program.GenerateFare(2, 5);
            Assert.AreEqual(25, fare);
        }

        [Test]
        public void givenDistanceAndTime_WhenToCalculateMinimumFare_ShouldReturnMinimumFare()
        {
            double fare = program.GenerateFare(0.1, 1);
            Assert.AreEqual(5, fare);
        }
    }
}