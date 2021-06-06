
using System;

namespace DiceRoller
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("How many sides would you like on your dice?");
            int numberSides = GetUserInput();

            int result1 = 0;
            int result2 = 0;

            Console.WriteLine("Would you like to roll the dice?");
            string rollOrNot = Console.ReadLine();
            if( rollOrNot.ToLower().Trim() == "yes" ) 
            {
                result1 = GetUserInput();
                result2 = GetUserInput();
            }

            

        }
        
        public static int GetUserInput()
        {
            string input = "";
            int output = 0;
            
            try
            {
                input = Console.ReadLine();
                output = int.Parse(input);
            }
            catch(FormatException)
            {
                Console.WriteLine("That was not a valid input.");
                
            }

            return output;
        }
    }
}
