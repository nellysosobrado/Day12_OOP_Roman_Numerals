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
            RomanNumeralsClass Program= new RomanNumeralsClass();
            Program.GatherRomanInput();
        }
    }
}
    
