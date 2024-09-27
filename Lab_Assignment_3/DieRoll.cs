using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Assignment_3
{
    internal class DieRoll
    {
        // Method to roll a dice based on its sides
        public int Roll(int sides)
        {
            Random rnd = new Random(); // Create a new random number generator
            int rolling = rnd.Next(1, sides + 1); // Generate a random number based on the dice type
            return rolling;
        }
    }
}
