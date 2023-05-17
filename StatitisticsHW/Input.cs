using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statitistics
{
    internal sealed class Input
    {
        public void InputHandler(out uint numOfElements, out float[] elements)
        {
            Console.Write("Enter number of elements : ");
            numOfElements = NumOfElementInput(Console.ReadLine());
            Console.Write("\n Enter array elements \n");
            elements = new float[numOfElements];
            ElementArrayInput(ref elements, numOfElements);
            

        }
        private uint NumOfElementInput(string input)
        {
            try
            { 
                return uint.Parse(input);
            }
            catch
            {
                ErrorHandler.InvalidInputError($"{input} || is not a valid input! \n"
                    + "Please enter a positive integer");
                return NumOfElementInput(Console.ReadLine());
            }
        }
        private void ElementArrayInput(ref float[] elements, uint ArrayLength)
        {
            for (uint i = 0; i < ArrayLength; i++)
            {
                Console.Write($"|| {i + 1} => ");
                elements[i] = ElementInput(Console.ReadLine());
                Console.Write("|| \n");
            }
        }
        public static float ElementInput(string input)
        {
            try
            {
                return float.Parse(input);
            }
            catch
            {
                ErrorHandler.InvalidInputError($"{input} || is not a valid input! \n"
                    + "Please enter a valid number");
                return ElementInput(Console.ReadLine());
            }
        }
    }
}
