using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day12_OOP_Roman_Numerals
{
    public class ErrorManager
    {
        public bool CheckUserInput(string input, out string ErrorMessage)
        {
            ErrorMessage = string.Empty;

            //Regex symbol/rules/pattern declares into an string variable.
            //Reason: To use this variable as an comparer, if user input is similiar to an 'rom number/pattern'
            string romanPattern = "^M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";

            // If-statement: Check user input ---------------------------------------------
            if (input != input.ToUpper())
            {

                Console.Clear();
                ErrorMessage = "Input needs to be uppercase letters";
                return false;



            }
            else if (!Regex.IsMatch(input, romanPattern)) // Compares user input to roman number pattern. If not then error messages displays
            {
                ErrorMessage = "Input is not a valid Roman number";
                Console.WriteLine(ErrorMessage);
                Console.WriteLine("Press any key to try again :P Loser");
                Console.WriteLine();
                Console.ReadKey();
                return false;
            }

            else if (string.IsNullOrWhiteSpace(input) || input.Any(c => !char.IsUpper(c) && !char.IsWhiteSpace(c))) //Checks if user input is empty
            {
                ErrorMessage = "Input should not contain spaces or symbols that are not Roman letters.";
                Console.WriteLine(ErrorMessage);
                Console.WriteLine("You can try again. Press any key to continue.");
                Console.WriteLine();
                Console.ReadKey();
                return false;

            }
            //If there's no error
            ErrorMessage = string.Empty;
            return true;

        }
    }
}
