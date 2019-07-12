using Udaiyan.MaxNumberFouledUnits.Models;
using System;

namespace MaxNumberFouledUnits
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter a path to the WaterUnits file, e.g. MaxNumberFouledUnits [Path to WaterUnits file]");
            }
            else
            {
                try
                {
                    var WaterUnits = new WaterUnits(args[0]);
                    Console.WriteLine("The maximum number of WaterUnits is = " + WaterUnits.GetMaxNumberOfFouledUnits());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
