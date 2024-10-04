using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A1_SreejaYathipathi
{
    internal class DieRoll
    {
        /// <summary>
        /// Provides methods for rolling dice.
        /// Rolls a die with the specified number of sides.
        /// </summary>
        
        public static int Roll(int sides)
        {
            Random rnd = new Random(); // // Create a Random object to generate random numbers.
            return rnd.Next(1, sides + 1); // Generate a random number between 1 and the number of sides and return it.
        }
    }
}
