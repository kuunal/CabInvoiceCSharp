using System;

namespace CabInvoice
{
    public class Program
    {
        const int COST_PER_KILOMETER = 10;
        const int COST_PER_MINUTE = 1;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public double GenerateFare(double distance, int time)
        {
            return COST_PER_KILOMETER * distance + time * COST_PER_MINUTE;
        }
    }
}
