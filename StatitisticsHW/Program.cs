using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Statitistics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            Data data = new Data();
            if(FunctionInput(FunctionMenu(), ref data.Elements))
            {
                RestartProgram();
            }

        }

        private static void RestartProgram()
        {
            int choice = (int)Input.ElementInput("Thank you for using our application! Would you like to perform another operation?\\n Press 1 to go back to Main Menu or 0 to Exit => ");
            switch (choice)
            {
                case 0:
                    Quit();
                    break;
                case 1:
                    MainMenu();
                    break;
            }
        }

        static uint FunctionMenu()
        {
            bool isInput = true;
            uint function = 0;
            while (isInput && function != 12)
            {
                Console.Write("Choose your service: \n" +
                    "1: Mean \n" +
                    "2: Mode \n" +
                    "3: Median \n" +
                    "4: N Percentile \n" +
                    "5: First Quartile \n" +
                    "6: Third Quartile \n" +
                    "7: Interquartile \n" +
                    "8: Boundaries of Outlier Region \n" +
                    "9: Range of the values \n" +
                    "10: Check if input is Outlier \n" +
                    "11: All functions 1-10 \n" +
                    "12: Exit \n"
                );
                try
                {
                    function = uint.Parse(Console.ReadLine());
                    if (function >= 12 || function < 1)
                    {
                        ErrorHandler.InvalidInputError("Invalid function!");
                        isInput = true;
                    }
                    else
                    {
                        isInput = false;
                    }
                }
                catch
                {
                    ErrorHandler.InvalidInputError("You must provide an integer!");
                    isInput = true;
                }
            }
            return function;
        }
        static bool FunctionInput(uint funcType, ref float[] elements)
        {
            bool canPerformAll = false;
            for(int i = -1; i <= 10 * Convert.ToInt32(canPerformAll); i++)           // Loop through every function iff it canPerformAll
            {
                if (!canPerformAll)
                {
                    i = (int) funcType;         // If only function is to be performed, then i will equal that function
                }
                switch (i)
                {
                    case 1:
                        Mean(ref elements);
                        break;
                    case 2:
                        Mode(ref elements);
                        break;
                    case 3:
                        Median(ref elements);
                        break;
                    case 4:
                        Console.Write("|| Enter Percentile => ");
                        int percentage = (int)Input.ElementInput(Console.ReadLine());
                        NPercentile(percentage, ref elements);
                        break;
                    case 5:
                        FirstQuartile(ref elements);
                        break;
                    case 6:
                        ThirdQuartile(ref elements);
                        break;
                    case 7:
                        Interquartile(ref elements);
                        break;
                    case 8:
                        OutlierBoundaries(ref elements);
                        break;
                    case 9:
                        Range(ref elements);
                        break;
                    case 10:
                        Console.Write("|| Enter value to check if it's an outlier => ");
                        float outlier = Input.ElementInput(Console.ReadLine());
                        IsOutlier(outlier, ref elements);
                        break;
                    case 11:
                        canPerformAll = true;
                        i = 0;
                        break;
                    case 12:
                        Quit();
                        break;
                }
            }
            return true;

        }
        // Pass by reference to save memory and not have to copy the array
        static void Mean(ref float[] elements)
        {
            Console.WriteLine($"|| Mean => {Calculator.Mean(ref elements)} ||");
        }
        static void Mode(ref float[] elements)
        {
            foreach(var element in Calculator.Mode(ref elements))
            {
                Console.Write($"|| Mode => {element} || \n");
            }
        }
        static void Median(ref float[] elements)
        {
            Console.WriteLine($"|| Median => {Calculator.Median(ref elements)} ||");
        }
        static void NPercentile(int percentage, ref float[] elements)
        {
            Console.WriteLine($"|| The value of the {percentage} percentile is => {Calculator.Percentile(percentage, ref elements)} ||");
        }
        static void FirstQuartile(ref float[] elements)
        {
            Console.WriteLine($"|| The value of Q1 => {Calculator.Percentile(25, ref elements)} ||");
        }
        static void ThirdQuartile(ref float[] elements)
        {
            Console.WriteLine($"|| The value of Q3 => {Calculator.Percentile(75, ref elements)} ||");
        }
        static void Interquartile(ref float[] elements)
        {
            Console.WriteLine($"|| The value of the Interquartile => {Calculator.Percentile(75, ref elements) - Calculator.Percentile(25, ref elements)} ||");
        }
        static void OutlierBoundaries(ref float[] elements)
        {
            float[] boundaries = Calculator.OutlierBoundaries(ref elements);
            Console.WriteLine($"|| The lower bound is => {boundaries[0]} and the uper bound is => {boundaries[1]} ||");
        }
        static void Range(ref float[] elements)
        {
            Console.WriteLine($"|| Range => {Calculator.Range(ref elements)} ||");
        }
        static void IsOutlier(float value, ref float[] elements)
        {
            bool isOutlier = Calculator.IsOutlier(value, ref elements);
            if (isOutlier)
            {
                Console.WriteLine($"|| {value} is an outlier ||");
            }
            else
            {
                Console.WriteLine($"|| {value} is not an outlier ||");
            }
        }
        static void Quit()
        {
            Console.WriteLine("Thank you for using our application!");
            Environment.Exit(0);
        }

    }
}
