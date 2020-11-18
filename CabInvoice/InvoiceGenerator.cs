﻿using System;

namespace CabInvoice
{
    public class Program
    {
        const int COST_PER_KILOMETER = 10;
        const int COST_PER_MINUTE = 1;
        const int MINIMUM_FARE = 5;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public double GenerateFare(double distance, int time)
        {
            return Math.Max(COST_PER_KILOMETER * distance + time * COST_PER_MINUTE, MINIMUM_FARE);
        }
    }
}