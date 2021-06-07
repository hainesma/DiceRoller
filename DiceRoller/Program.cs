
using System;

namespace DiceRoller
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many sides would you like on your dice?");
            int sides = GetInteger();
            int result1 = 0;
            int result2 = 0;             
            string message = "";
            bool goOn = true;
            while (goOn == true)
            {
                Console.WriteLine("Enter 'roll' to roll the dice.");
                string rollOrNot = Console.ReadLine();
                if (rollOrNot.ToLower().Trim() == "roll")
                {
                    result1 = RollOneDie(sides);
                    result2 = RollOneDie(sides);

                    Console.WriteLine($"The first die shows {result1}.");
                    Console.WriteLine($"The second die shows {result2}.");
                    int total = result1 + result2;
                    Console.WriteLine($"The total was {total}.");
                    if (sides == 6)
                    {
                        message = EvaluateSixSided(result1, result2);
                        Console.WriteLine(message);
                    }
                }
                goOn = GetContinue();
            }
        }
        
        public static int GetInteger()
        {
            string input = "";
            int output = 0;
            try
            {
                input = Console.ReadLine();
                output = int.Parse(input);
                if (output < 4)
                {
                    throw new Exception("The dice must have at least 4 sides.");
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("That was not a valid input.");                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return output;
        }

        public static int RollOneDie(int sides)
        {
            
            Random r = new Random();
            int result = r.Next(1, sides + 1);
            return result;
        }

        public static string EvaluateSixSided(int result1, int result2)
        {
            string output = "";
            
            if (result1 + result2 == 2)
            {
                output = "Snake Eyes, Craps";
            } 
            else if(result1 + result2 == 3)
            {
                output = "Ace Deuce, Craps";
            }
            else if(result1 == 6 && result2 == 6)
            {
                output = "Box Cars, Craps";
            }
            else if(result1 + result2 == 7 || result1 + result2 == 11)
            {
                output = "Win";
            }
            else if(result1 + result2 == 12)
            {
                output = "Craps";
            } else
            {
                output = "There is no message for that outcome.";
            }

            return output;
        }

        public static bool GetContinue()
        {
            Console.WriteLine("Would you like to roll again? Y/N");
            string input = Console.ReadLine();
            if (input.ToLower() == "y")
            {
                return true;
            }
            else if (input.ToLower() == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("I don't understand that input. Please try again.");
                return GetContinue();
            }
        }
    }
}
