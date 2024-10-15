using System;

namespace Day12_OOP_Roman_Numerals
{
    public class RomanNumeralsClass
    {
        public void GatherRomanInput() //Responbisbility of users input, and give error message
        {
            bool prgmRun = true;

            while (prgmRun)
            {
                //Displaying the color of the title and the text that is written in the command prompt.
                Console.Clear();
                SetConsoleTitle();
                CenterText("Enter 'Roman Number':", ConsoleColor.Magenta);

                //1. GET User Input -------------
                string input = Console.ReadLine() ?? string.Empty;

                //ERROR Manager ----------------------------------------
                ErrorManager errorManager = new ErrorManager();

                // Check the input
                string errorMessage;
                bool isValid = errorManager.CheckUserInput(input, out errorMessage);

                // Check the errrormesage, False = error, True = no error.
                if (!isValid)
                {
                    Console.Clear();
                    CenterText(errorMessage, ConsoleColor.Red);
                    CenterText("Press any key to try again...", ConsoleColor.Yellow);
                    Console.ReadKey();
                    continue;
                }

                // Converting ----------------------------------------
                Converter romantoint = new Converter();
                decimal userConvertedInput = romantoint.RomanToInt(input);

                //DISPLAY
                CenterText($"Roman number: {input}", ConsoleColor.Green);
                CenterText($"Decimal: {userConvertedInput}", ConsoleColor.Cyan);

                CenterText("Press any key to continue...", ConsoleColor.Yellow);
                Console.ReadKey();

                //Play Again ------------------------------------
                PlayAgain playagain = new PlayAgain();
                prgmRun = playagain.StartAgain();
            }
        }

        // CenterText to align the text in the middle of the command prompt
        private void CenterText(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            int screenWidth = Console.WindowWidth;
            int textWidth = text.Length;
            int spaces = (screenWidth / 2) - (textWidth / 2);
            Console.SetCursorPosition(Math.Max(0, spaces), Console.CursorTop);
            Console.WriteLine(text);
            Console.ResetColor();
        }

        // Displaying the title in the middle of the command prompt, in ASCII art
        private void SetConsoleTitle()
        {
            string title = @"
 ____                               _   _                                _ _     
|  _ \ ___  _ __ ___   __ _ _ __   | \ | |_   _ _ __ ___   ___ _ __ __ _| ( )___ 
| |_) / _ \| '_ ` _ \ / _` | '_ \  |  \| | | | | '_ ` _ \ / _ \ '__/ _` | |// __|
|  _ < (_) | | | | | | (_| | | | | | |\  | |_| | | | | | |  __/ | | (_| | | \__ \
|_| \_\___/|_| |_| |_|\__,_|_| |_| |_| \_|\__,_|_| |_| |_|\___|_|  \__,_|_| |___/
";

            string[] titleLines = title.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            int screenHeight = Console.WindowHeight;
            int titleHeight = titleLines.Length;

            // Center vertically
            int verticalPadding = (screenHeight / 2) - (titleHeight / 2);
            Console.SetCursorPosition(0, Math.Max(0, verticalPadding));

            // Center horizontally and write each line
            foreach (string line in titleLines)
            {
                CenterText(line, ConsoleColor.Yellow);
            }
        }
    }
}
