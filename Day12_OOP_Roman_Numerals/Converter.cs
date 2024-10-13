using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12_OOP_Roman_Numerals
{
    public class Converter
    {
        public decimal RomanToInt(string input)
        {
            //Roman rule: If first number is small, it will substract the 

            Dictionary<char, int> RomanNumbers = new Dictionary<char, int>// A collection of key value pairs = Dictionary
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };

            decimal total = 0;//Variables, to store the rom number as a value
            decimal previousValue = 0; //In order to compare the different index value incase program recieves an special roman number like: IV


            for (int i = 0; i < input.Length; i++) //String variables, are an array of chars. Which means we can loop trough user's input index seperatetly. 
            {
                int currentValue = RomanNumbers[input[i]];

                //If-statements, to handle special roman numbers-----------
                if (previousValue < currentValue)
                {
                    // Minus the previous value, reason being it was already added earlier
                    total += currentValue - 2 * previousValue;
                }
                else
                {
                    // Current values added with the total
                    total += currentValue;
                }

                // Update the previous value to the current one for the next iteration
                previousValue = currentValue;
            }

            return total;
        }
    }
}
