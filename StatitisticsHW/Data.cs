using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statitistics
{
    internal sealed class Data
    {
        private readonly uint numOfElements;
        private float[] elements;
        private readonly Input inputs;
        public uint NumOfElements
        {
            get { return numOfElements; }
        }
        public ref float[] Elements
        {
            get
            {
                return ref elements;
            }
        }
        public Data()
        {
            inputs = new Input();
            inputs.InputHandler(out numOfElements, out elements);
            Array.Sort(elements);
        }
    }

    
}
