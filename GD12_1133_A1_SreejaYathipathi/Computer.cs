using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A1_SreejaYathipathi
{

    /// <summary>
    /// Represents a computer player in the game, responsible for handling computer-specific actions 
    /// such as rolling dice and managing its score.
    /// </summary>

    internal class Computer
    {
        /// <summary>
        /// Represents a computer player in the game, responsible for handling computer-specific actions 
        /// such as rolling dice and managing its score.
        /// </summary>

        private int cpuKilled; // Computer's score
        private int cpuLastKills; // Last roll value
        private List<int> cpuAvailableDice; // List of available dice
        private int cpuEvenRolls; // Count of even rolls
        private int cpuOddRolls; // Count of odd rolls
        private int cpuSelectedDice; // Variable to store selected dice.
        private int cpuRoundKills; // Varaible to store value of that round.

        /// <summary>
        /// Initializes a new instance of the ComputerPlayer class.
        /// Sets up initial score.
        /// </summary>
        public void CpuCount()
        {
            cpuKilled = 0; // Initialize score to 0
            cpuEvenRolls = 0; // Initialize even rolls count
            cpuOddRolls = 0; // Initialize odd rolls count
        }

        /// <summary>
        /// Initializes the available dice for the computer player.
        /// </summary>
        public void CpuInitializeDice()
        {
            cpuAvailableDice = new List<int> { 8, 16, 24, 32, 40, 48, 56, 64, 72, 80 }; // Populate the available dice
        }

        /// <summary>
        /// Executes the computer's turn, randomly selecting a die to roll and updating its score.
        /// </summary>
        public void CpuTurn()
        {
            Console.WriteLine("Computer's turn to kill."); // Indicate computer's turn
            Console.WriteLine("");

            // Randomly select a dice from available options
            Random cpurnd = new Random(); // Create a random number generator
            int cpuIndex = cpurnd.Next(cpuAvailableDice.Count); // Get a random index
            int cpuChosenDice = cpuAvailableDice[cpuIndex]; // Select a random die
            cpuSelectedDice = cpuChosenDice;
            cpuAvailableDice.Remove(cpuChosenDice); // Remove the chosen dice from available options

            cpuLastKills = DieRoll.Roll(cpuChosenDice); // Roll the chosen dice
            cpuRoundKills = cpuLastKills; // Stores the value of cpuLastKills.
            cpuKilled += cpuLastKills; // Update the computer's score

            // Determine if the roll is even or odd using if statements
            string cpuEvenOdd = "";
            if (cpuLastKills % 2 == 0) // Check if the roll is even
            {
                cpuEvenOdd = "even"; // Set evenOdd to "even"
                cpuEvenRolls++; // Increment even rolls
            }
            else // The roll is odd
            {
                cpuEvenOdd = "odd"; // Set evenOdd to "odd"
                cpuOddRolls++; // Increment odd rolls
            }

            Console.WriteLine("Computer rolled a d" + cpuChosenDice + "\r\n"); // Display the chosen dice.
            Console.WriteLine("Computer killed " + cpuLastKills + " people.\r\n"); // Display the roll result.
            Console.WriteLine(cpuLastKills + " is an " + cpuEvenOdd + "number.\r\n"); // Display the number is even or odd.
        }

        /// <summary>
        /// Gets the last rolled dice of the player.
        /// </summary>
        public int CpuGetselectedDice()
        {
            return cpuSelectedDice;
        }

        /// <summary>
        /// Gets the value of that round.
        /// </summary>

        public int CpuGetRoundKills()
        {
            return cpuRoundKills;
        }

        /// <summary>
        /// Gets the last roll value of the computer.
        /// </summary>
        /// <returns>The value of the last roll.</returns>
        public int CpuGetLastKills()
        {
            return cpuLastKills; // Return the last roll value
        }

        /// <summary>
        /// Gets the total score of the computer.
        /// </summary>
        /// <returns>The computer's total score.</returns>
        public int CpuGetKill()
        {
            return cpuKilled; // Return the computer's score
        }

        /// <summary>
        /// Displays the computer's statistics including total score and counts of even and odd rolls.
        /// </summary>
        public void CpuKillStats()
        {
            Console.WriteLine("Computer's Total Kills: " + cpuKilled + " people.\r\n"); // Display total score
            Console.WriteLine("Even Kills: " + cpuEvenRolls + "\r\n"); // Display even rolls count
            Console.WriteLine("Odd Kills: " + cpuOddRolls + "\r\n"); // Display odd rolls count
        }
    }
}
