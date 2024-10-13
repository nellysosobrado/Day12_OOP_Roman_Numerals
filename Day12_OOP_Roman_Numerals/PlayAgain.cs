using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12_OOP_Roman_Numerals
{
    public class PlayAgain
    {
        public static bool StartAgain()
        {
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
                return false;
            }
            else
            {
                return true;
            }
        }//End of while


    }
}
