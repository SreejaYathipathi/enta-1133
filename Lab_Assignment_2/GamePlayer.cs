using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Assignment_2
{
    internal class GamePlayer
    {
        public int score = 0;

        public void Points(int Value)
        {
            int oldscore = score;
            score += Value;
            int difference = score - oldscore;
            string gained = "You gained " + difference + " points.";
            Console.WriteLine(gained);
            Console.WriteLine("");
            //Gives the score value to oldscore and adds new value to score, subtracts oldscore and newscore and assigns it to difference.
        }

        public void Play()
        {
            Console.WriteLine("Hi, Welcome to Roll and Die game.");
            Console.WriteLine("My name is Sreeja.");
            Console.WriteLine("09-13-2024"); //Writes a welcome message, my name and date.
            Console.WriteLine("");

            DiceGame Roller = new DiceGame(); //creates a instace for DiceGamer and constructs it.

            Console.Write("This is a game with dice ");
            Console.Write(Roller.sides);
            Console.Write(" sides."); //Writes how many sides a dice has by calling roller.
            Console.WriteLine("");
            Console.WriteLine("");

            Roller.Description();
            Roller.RollDice();
            Points(Roller.result);
            Roller.RollDice();
            Points(Roller.result);
            Roller.RollDice();
            Points(Roller.result);
            Roller.RollDice();
            Points(Roller.result);

            score += Roller.result;

            //calls the instance RollDice and writes result from it.
        }

        public void Print()
        {
            Console.WriteLine("your total score is " + score); //Adds the total score and prints them.
            Console.WriteLine("");
            Console.WriteLine("Thank you for reading this.");
            Console.WriteLine("");
            //Explains what the operation does. 
            Console.WriteLine("+ is an operation that adds two numbers.");
            Console.WriteLine("score = oldscore + newscore");
            Console.WriteLine("- is an operation that subtracts two numbers.");
            Console.WriteLine("score = oldscore - newscore");
            Console.WriteLine("* is an operation that multiplies two numbers.");
            Console.WriteLine("score = oldscore * newscore");
            Console.WriteLine("++ is an operation that can be used for adding two numbers and assigning the value to the same string.");
            Console.WriteLine("oldscore ++ newscore");
            Console.WriteLine("-- is an operation that can be used for subtracts two numbers and assigning the value to the same string.");
            Console.WriteLine("oldscore -- newscore");
            Console.WriteLine("/ is an operation that divides two numbers.");
            Console.WriteLine("score = oldscore / newscore");
            Console.WriteLine("% is an operation that returns the reminder of two values.");
            Console.WriteLine();
            Console.WriteLine("Bye bye"); //Ending message.
        }
    }
}
