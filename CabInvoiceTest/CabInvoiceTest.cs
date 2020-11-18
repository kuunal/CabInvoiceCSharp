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
        public void Test1()
        {
            double fare = program.GenerateFare(2, 5);
            Assert.AreEqual(25, fare);
        }
    }
}