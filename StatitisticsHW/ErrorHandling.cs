using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statitistics
{
    internal static class ErrorHandler
    {
        public static void InvalidInputError(string errorMessage)
        {
            Console.WriteLine(errorMessage);
        }
    }
}
