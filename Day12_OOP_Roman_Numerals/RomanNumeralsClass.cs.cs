using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day12_OOP_Roman_Numerals
{
    public class RomanNumeralsClass
    {

        public void GatherRomanInput()//Responbisbility of users input, and give error message
        {
            bool prgmRun = true;

            while (prgmRun)
            {
                //GET user input ---------------
                Console.Clear();
                Console.WriteLine();
                Console.Write("Enter");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(" 'Roman Number': ");
                Console.ResetColor();//Resets color, so green doesn' affect other texts
                string input = Console.ReadLine() ?? string.Empty; //Gets uesrs input, and if its empty returns emptry string instead of null


                //ERROR MANAGER ----------------------------------------
                ErrorManager errorManager= new ErrorManager();

                //Check the input 
                string errorMessage;
                bool isValid = errorManager.CheckUserInput(input, out errorMessage);

                //Check the errrormesage
                if (!isValid)
                {
                    Console.Clear();
                    Console.WriteLine(errorMessage);
                    Console.WriteLine("Press any key to try again");
                    Console.ReadKey();
                    continue; //goes back to the loop, to try again
                }

                //Converting ------------
                Converter romantoint = new Converter();
                decimal UserConvertedInput = romantoint.RomanToInt(input);

                Console.WriteLine($"Roman number {input}" +
                    $"\nDecimal: {UserConvertedInput}");

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();

                //Play again
                PlayAgain playagain = new PlayAgain();
                playagain.StartAgain();

            }

            
        }

    }
}