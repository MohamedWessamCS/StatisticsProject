using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Statitistics
{
    internal static class Calculator
    {
        public static float Median(ref float[] elements)
        {
            if (elements.Length % 2 == 0)       // Even
            {
                float[] middleTerms = new float[2]
                {
                    elements[(elements.Length / 2) - 1], 
                    elements[(elements.Length / 2)]
                };
                return Mean(ref middleTerms);       // Average of the 2 middle terms
            }
            else
            {
                int middleIndex = (int) Math.Floor(elements.Length / 2.0);
                float middleTerm = elements[middleIndex];
                return middleTerm;
            }
        }

        public static float Mean(ref float[] elements)
        {
            return elements.Sum() / elements.Length;
        }
        public static float Range(ref float[] elements)
        {
            return elements[elements.Length - 1] - elements[0];
        }
        public static float[] Mode(ref float[] elements)
        {
            Dictionary<float, int> elementCounts = new Dictionary<float, int>();  
            List<float> modes = new List<float>();
            CountOccurence(ref elements, ref elementCounts);
            int max;
            MaxOccurence(ref elementCounts, out max);
            GetModes(ref elementCounts, ref max, ref modes);
            return modes.ToArray();
        }
        private static void CountOccurence(ref float[] elements, ref Dictionary<float, int> elementCounts)
        {
            for (int i = 0; i < elements.Length - 1; i++)           // Loop through array and count every occurence
            {
                if (elements[i] == elements[i + 1])
                {
                    if (elementCounts.ContainsKey(elements[i]))
                    {
                        elementCounts[elements[i]]++;
                    }
                    else
                    {
                        elementCounts.Add(elements[i], 2);
                    }
                }
            }
        }
        private static void MaxOccurence(ref Dictionary<float, int> elementCounts, out int max)
        {
            max = 0;
            foreach (var pair in elementCounts)          // Find maximum number of occurunces
            {
                if (pair.Value >= max)
                {
                    max = pair.Value;
                }
            }
        }
        private static void GetModes(ref Dictionary<float, int> elementCounts, ref int max, ref List<float> modes)
        {
            foreach (var pair in elementCounts)          // Get the mode
            {
                if (pair.Value == max)
                {
                    modes.Add(pair.Key);
                }
            }
        }
        public static float Percentile(int percentage, ref float[] elements)
        {
            percentage = percentage >= 0 && percentage <= 100 ? percentage : 100;
            float index = (percentage / 100.0f) * elements.Length - 1;
            int ceiledIndex = (int) Math.Ceiling(index);
            if(ceiledIndex != index)
            {
                return elements[ceiledIndex];
            }
            float[] percentileTerms = { elements[(int)index], elements[(int)index+1] };
            return Mean(ref percentileTerms);
        }
        public static float Interquartile(float[] elements)
        {
            return Percentile(75, ref elements) - Percentile(25, ref elements);
        }
        public static float[] OutlierBoundaries(ref float[] elements)
        {
            float[] boundaries = new float[2]
            {
                (float) (Percentile(25, ref elements) - 1.5 * Interquartile(elements)),
                (float) (Percentile(75, ref elements) + 1.5 * Interquartile(elements))
            };
            return boundaries;
        }

        public static bool IsOutlier(float value, ref float[] elements)
        {
            float[] boundaries = OutlierBoundaries(ref elements);
            return value <= boundaries[0] || value >= boundaries[1];
        }
    }
}
