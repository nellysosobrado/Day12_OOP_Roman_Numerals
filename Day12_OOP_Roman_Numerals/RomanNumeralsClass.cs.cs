using System;
using System.Collections.Generic;
using System.Linq;
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
                string ErrorMessage = ""; //To store error-messages

                //Regex symbol/rules/pattern declares into an string variable.
                //Reason: To use this variable as an comparer, if user input is similiar to an 'rom number/pattern'
                string romanPattern = "^M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";


                //GET user input ---------------
                Console.Clear();
                Console.WriteLine();
                Console.Write("Enter");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(" 'Roman Number': ");
                Console.ResetColor();//Resets color, so green doesn' affect other texts
                string input = Console.ReadLine() ?? string.Empty; //Gets uesrs input, and if its empty returns emptry string instead of null

                // If-statement: Check user input ---------------------------------------------
                if (input != input.ToUpper())
                {
                    Console.Clear();
                    ErrorMessage = "Input needs to be uppercase letters";
                    Console.WriteLine(ErrorMessage);
                    Console.WriteLine("Press any key to continue.. :P");
                    Console.WriteLine();
                    Console.ReadKey();
                    continue; //Goes back to while-loop, until user enters correct input


                }
                else if (!Regex.IsMatch(input, romanPattern)) // Compares user input to roman number pattern. If not then error messages displays
                {
                    ErrorMessage = "Input is not a valid Roman number";
                    Console.WriteLine(ErrorMessage);
                    Console.WriteLine("Press any key to try again :P Loser");
                    Console.WriteLine();
                    Console.ReadKey();
                    continue;
                }

                else if (string.IsNullOrWhiteSpace(input) || input.Any(c => !char.IsUpper(c) && !char.IsWhiteSpace(c))) //Checks if user input is empty
                {
                    ErrorMessage = "Input should not contain spaces or symbols that are not Roman letters.";
                    Console.WriteLine(ErrorMessage);
                    Console.WriteLine("You can try again. Press any key to continue.");
                    Console.WriteLine();
                    Console.ReadKey();
                    continue;

                }
                else //CONVERT Roman Number to decimal ----------------
                {

                    decimal UserConvertedInput= RomanToInt(input); //Call method, sends user input as parameter

                    Console.WriteLine($"Roman number {input} " +
                            $"\nDecimal: {UserConvertedInput:F2}");

                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();

                }//End if-statements

                Console.Clear();

                PlayAgain PlayAgain = new PlayAgain();
                bool answer = PlayAgain.StartAgain();

                if (answer == false)
                {
                    Console.WriteLine("Program ending");
                    prgmRun = false;
                }
                else
                {
                    prgmRun = true;
                }


            }
            static decimal RomanToInt(string input)
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
}