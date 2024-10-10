using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Day12_OOP_Roman_Numerals
{
    internal class Program
    {
        //INPUT
          //Check correct input (IF STATEMENTS)
          //>Check if it's a string
          //Check Uppercase
          //>Check if it's a rom number

        //->Calculate rom number to decimal-format


        //OUTPUT
        static void Main(string[] args)
        {
            string ErrorMessage = "";

            
            Console.Write("Enter Roman Number:");
            string input = Console.ReadLine();

            string romanPattern = "^M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";

            

            if(input != input.ToUpper())
            {
                ErrorMessage = "Input needs to be uppercase letters";
                Console.WriteLine(ErrorMessage);
            }
            else if(!Regex.IsMatch(input,romanPattern)) 
            {
                ErrorMessage = "Input is not a valid Roman number";
                Console.WriteLine(ErrorMessage);
            }
            else
            {
                //Convert rom to number
                decimal total = 0;
                decimal value = 0;

                Dictionary<char, int> RomerskaSiffrorBetydelse = new Dictionary<char, int>
                {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
                };
                for (int i = input.Length - 1; i >= 0; i--) 
                {
                    int currentValue = RomerskaSiffrorBetydelse[input[i]];
                
                if (currentValue > value)
                    {
                        total += currentValue - 2 * value;
                    }
                    else
                    {
                        total += currentValue;
                    }

                    value = currentValue;

                }
                Console.WriteLine($"ROman number {input} " +
                    $"\nDecimal: {total}");


            }

        }
    }
}
    
