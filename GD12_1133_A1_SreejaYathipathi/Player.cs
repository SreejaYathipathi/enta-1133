using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A1_SreejaYathipathi
{
    /// <summary>
    /// Represents a player in the game, responsible for handling player-specific actions such as
    /// asking for the player's name, providing an option to change it, rolling the dice and managing score.
    /// </summary>
    
    internal class Player
    {
        string userName = ""; // Holds the player's name.

        /// <summary>
        /// Prompts the player to enter their name and stores it.
        /// </summary>
        
        internal void PlayerName()
        {
            Console.WriteLine("Can I have your name to write it on my DEATH NOTE?\r\n");
            userName = Console.ReadLine(); // Stores user input for player name.
            Console.WriteLine("");
            Console.WriteLine("What a nice name " + userName + ", Sadly you won't live past if you don't WIN this game.\r\n");
        }

        /// <summary>
        /// Provides the player with an option to change their name.
        /// If the player asks to change the name, the PlayerName() method is called again.
        /// </summary>
        
        internal void ChangeName()
        {
            Console.WriteLine("Do you want me to write a different name in my DEATH NOTE or you want to continue with " + userName + ".\r\n");
            Console.WriteLine("Enter (Yes) or (No)\r\n");
            string Change = Console.ReadLine().ToLower(); // Get the user's decision on changing the name.
            Console.WriteLine("");

            // If player chooses 'Yes', ask for a new name.

            if (Change == "yes" )
            {
                PlayerName(); // Re-ask for the player's name.
            }

            else if (Change == "no" )
            {
                // If the player keeps the same name, proceed with the game.

                return;
            }
        }

        /// <summary>
        /// Returns the player's current name.
        /// </summary>
        
        internal string GetPlayerName()
        {
            return userName; // Return the stored player name.
        }

        private int playerKilled; // Holds player's score.
        private int playerLastKills; // Holds player's lastroll value.
        private List<int> playerAvailableDice; // List of availble dice.
        private int playerEvenRolls; // Counts even roll.
        private int playerOddRolls; // Counts odd roll.
        private int playerChosenDice; // Variable for chosen dice.
        private int playerSelectedDice; // Variable for selected dice to store chosen dice.
        private int playerRoundKills; // Variable to know kills for that round.

        /// <summary>
        /// Sets up initial scores and roll counts.
        /// </summary>

        public void PlayerCount()
        {
            playerKilled = 0;
            playerEvenRolls = 0;
            playerOddRolls = 0;
        }

        /// <summary>
        /// Initializes the available dice for the player.
        /// </summary>

        public void PlayerInitializeDice()
        {
            playerAvailableDice = new List<int> { 8, 16, 24, 32, 40, 48, 56, 64, 72, 80 }; // Store the value of availble dice.
        }

        /// <summary>
        /// Executes the player's turn, allowing them to roll a die and updating their score.
        /// </summary>
        
        public void PlayerTakeTurn()
        {
            Console.WriteLine(userName + ", it's your turn to kill people.\r\n"); // Indicate player's turn
            Console.WriteLine("Available dice:\r\n"); // Display available dice

            // Using a for loop to display available dice.

            for (int i = 0; i < playerAvailableDice.Count; i++) // Use a for loop to iterate through available dice.
            {
                Console.WriteLine("d" + playerAvailableDice[i]); // Print each dice.
                Console.WriteLine("");
            }

            Console.WriteLine("Select a dice to roll to kill random nuber of people."); // Prompt for dice choice.
            Console.WriteLine("");

            // Input validation for dice choice.
            while (!int.TryParse(Console.ReadLine(), out playerChosenDice) || !playerAvailableDice.Contains(playerChosenDice))
            {
                Console.WriteLine("");
                Console.WriteLine("You can't select your own number to kill people. You have to select from the given numbers."); // Error message for invalid choice.
                Console.WriteLine("");
            }

            playerSelectedDice = playerChosenDice;
            // Remove the chosen dice from the available list.

            playerAvailableDice.Remove(playerChosenDice); // Remove the chosen dice from available options.

            playerLastKills = DieRoll.Roll(playerChosenDice); // Roll the chosen dice.

            playerRoundKills = playerLastKills; // Assigns playerLastKills value to playerRoundKills.

            playerKilled += playerLastKills; // Update the player's score.

            string playerEvenOdd; // Declare the variable to hold the even/odd status.

            // Check if the last roll is even or odd.

            if (playerLastKills % 2 == 0) // Check if the roll is even.
            {
                playerEvenOdd = "even"; // Set evenOdd to "even".
                playerEvenRolls++; // Increment even rolls.
            }
            else // The roll is odd
            {
                playerEvenOdd = "odd"; // Set evenOdd to "odd".
                playerOddRolls++; // Increment odd rolls.
            }

            Console.WriteLine("");
            Console.WriteLine("You rolled a d" + playerChosenDice + "\r\n"); // Display the chossen dice.
            Console.WriteLine("Congrats you killed " + playerLastKills + " people.\r\n"); // Display the roll result.
            Console.WriteLine(playerLastKills + " is an " + playerEvenOdd + "number.\r\n"); // Display if it's even ot odd.
        }

        /// <summary>
        /// Gets the last rolled dice of the player.
        /// </summary>
        public int PlayerGetselectedDice()
        {
            return playerSelectedDice;
        }

        /// <summary>
        /// Gets the value of that round.
        /// </summary>
        
        public int PlayerGetRoundKills()
        {
            return playerRoundKills;
        }

        /// <summary>
        /// Gets the last roll value of the player.
        /// </summary>

        public int PlayerGetLastKills()
        {
            return playerLastKills; // Return the last roll value.
        }

        /// <summary>
        /// Gets the total score of the player.
        /// </summary>

        public int PlayerGetKill()
        {
            return playerKilled; // Return the player's score.
        }

        /// <summary>
        /// Displays the player's statistics including total score and counts of even and odd rolls.
        /// </summary>

        public void PlayerKillStats()
        {
            Console.WriteLine(userName + " Killing Stats\r\n");  // Game status of player.
            Console.WriteLine("Total Kills " + playerKilled + " people.\r\n"); // Display total score.
            Console.WriteLine("Even Kills: " + playerEvenRolls + "\r\n"); // Display even rolls count.
            Console.WriteLine("Odd Kills: " + playerOddRolls + "\r\n"); // Display odd rolls count.
        }
    }

}
