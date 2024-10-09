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
            string ErrorMessage = ""; //Variabel to store, error messages

            //Array: Numbers & Roman numbers
            int[] values = { 1000, 500, 100, 50, 10, 5, 1 };
            char[] symbols = { 'M', 'D', 'C', 'L', 'X', 'V', 'I' };

            // INPUT----------------
            Console.Write("Enter 'Roman Number': ");
            string input = Console.ReadLine();

            // Regex into variabel. Usage: to controll if input is valid with roman number,and special rules
            string romanPattern = "^M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";

            //If statements: Uppercase?, Valid roman number?
            if (input != input.ToUpper())
            {
                ErrorMessage = "Input needs to be uppercase letters";
                Console.WriteLine(ErrorMessage);
                return;
            }
            else if (!Regex.IsMatch(input, romanPattern)) // COmpares, if Input is not a roman number
            {
                ErrorMessage = "Input is not a valid Roman number";
                Console.WriteLine(ErrorMessage);
                return;
            }//----------------
            else // Converts input to number
            {

                int total = 0;//Variables, to store the rom number as a value
                int previousValue = 0; //To handle roman substraction

                for (int i = 0; i < input.Length; i++)
                {
                    char currentSymbol = input[i]; // STring is an array of char, so we can sepereate each element in input
                    int currentValue = 0;

                    //Loop, to check in symbol array 
                    for (int j = 0; j < symbols.Length; j++)
                    {
                        if (currentSymbol == symbols[j])
                        {
                            currentValue = values[j];// Roman number value adds into variable
                            break;
                        }
                    }

                    // If the roman number is for example IV, it will handle the calculation to correct value
                    if (currentValue > previousValue)
                    {
                        total += currentValue - 2 * previousValue;
                    }
                    else
                    {
                        total += currentValue;
                    }

                    previousValue = currentValue; // Update previous value for next iteration
                }

                //Decimal convert
                decimal decimalResult = Convert.ToDecimal(total);

                Console.WriteLine($"Roman number {input} " +
                    $"\nDecimal: {decimalResult:F2}");
            }

        }
    }
}
    