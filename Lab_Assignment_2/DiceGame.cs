using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Lab_Assignment_2
{
    internal class DiceGame
    {
        public int sides = 6;
        public int result = 0;

        public void Description()
        {
            Console.WriteLine("Rolls a six sided dice: ");
            Console.WriteLine("Min Roll");
            Console.WriteLine(1);
            Console.WriteLine("Max Roll");
            Console.WriteLine(sides);
            Console.WriteLine("");

            //Writes how many sides of dice we are rolling and what is the minroll and mallroll of that dice.
        }

        public void RollDice()
        {
            Random rnd = new Random();
            result = rnd.Next(1,sides + 1); //Generating a random number adding 1 to it.
        }
    }
}
