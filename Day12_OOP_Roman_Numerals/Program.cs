using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Day12_OOP_Roman_Numerals
{
    internal class Program
    {

        //Max Roman number is: 3,999 = MMMCMXCIX
        static void Main(string[] args)
        {
            //----------------------------------
            //GET Input
            //Check Input (If-statements):
            // Check if input is uppercase
            //Check if input matches roman symbol/pattern
            //Check if user doesn't enter any input at all

            //Converts roman number into decimal
            //OUTPUT
            //Play again?
            //----------------------------------

            //Max Roman number is: 3,999 = MMMCMXCIX

            bool prgmRun = true;

            while (prgmRun)
            {
                string ErrorMessage = ""; //To store error-messages

                //Regex symbol/rules/pattern declares into an string variable.
                //Reason: To use this variable as an comparer, if user input is similiar to an 'rom number/pattern'
                string romanPattern = "^M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";

                // A collection of key value pairs = Dictionary
                Dictionary<char, int> RomanNumbers = new Dictionary<char, int>
                {
                    { 'I', 1 },
                    { 'V', 5 },
                    { 'X', 10 },
                    { 'L', 50 },
                    { 'C', 100 },
                    { 'D', 500 },
                    { 'M', 1000 }
                };

                //GET user input ---------------
                Console.WriteLine();
                Console.Write("Enter");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(" 'Roman Number': ");
                Console.ResetColor();//Resets color, so green doesn' affect other texts
                string input = Console.ReadLine();

                // If-statement: Check user input ---------------------------------------------
                if (input != input.ToUpper())
                {
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
                    Console.WriteLine($"Roman number {input} " +
                            $"\nDecimal: {total:F2}");

                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();

                }//End if-statements

                //Controlls if player wants to play again-------------------------------
                int selectedIndex = 0;
                string[] options = { "Yes", "No" };
                ConsoleKey key;//reads pressed key, declares into key as variable
                do
                {
                    Console.Clear();//Resets console window
                    Console.WriteLine("Do you want to play again?");
                    Console.WriteLine();
                    Console.WriteLine("Use arrow key to navigate. Press 'Enter' to select");

                    for (int i = 0; i < options.Length; i++) //Loops trough array with options: yes,no
                    {
                        if (i == selectedIndex)
                        {
                            if (options[i] == "Yes")
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            else if (options[i] == "No")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            Console.Write(" --> ");

                        }
                        else
                        {
                            Console.ResetColor();

                            Console.Write(" ");//Make sure the other option is not selected
                        }


                        Console.WriteLine(options[i]);
                        Console.ResetColor();//Resets color after highlgihted
                    }
                    key = Console.ReadKey(true).Key;//user key declares into variable

                    //If-statements: Controlls which arrow
                    if (key == ConsoleKey.UpArrow)
                    {
                        selectedIndex--; //Moves marker up, which means goes back in array index exempel []: 0, 1
                        if (selectedIndex < 0)
                        {
                            selectedIndex = options.Length - 1; //if user moves up too much, which is out of the array range. It will go back because 2-1 = 1. 1= option 'no'

                        }
                    }
                    else if (key == ConsoleKey.DownArrow)
                    {
                        selectedIndex++; //Moves marker up, basically goes right side of array element --> 0 , 1. Right side is '1'
                        if (selectedIndex >= options.Length) //controlls the users navigation so it doesnt go outside of the array length
                        {
                            selectedIndex = 0;
                        }
                    }

                }
                while (key != ConsoleKey.Enter); //Loops until user press 'Enter'

                Console.WriteLine("You selected " + options[selectedIndex]);

                if (options[selectedIndex] == "No")
                {
                    prgmRun = false;
                }
                else
                {
                    prgmRun = true;
                }
            }//End of while
        }
    }
}
    
