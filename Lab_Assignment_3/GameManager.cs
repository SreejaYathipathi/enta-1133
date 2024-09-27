using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Assignment_3
{
    internal class GameManager
    {
        string username = ""; // Player username
        internal bool playerUsedDice6 = false; // Tracks if 6-sided dice is used
        internal bool playerUsedDice8 = false; // Tracks if 8-sided dice is used
        internal bool playerUsedDice12 = false; // Tracks if 12-sided dice is used
        internal bool playerUsedDice20 = false; // Tracks if 20-sided dice is used
        internal bool cpuUsedDice6 = false; // Tracks if 6-sided dice is used
        internal bool cpuUsedDice8 = false; // Tracks if 8-sided dice is used
        internal bool cpuUsedDice12 = false; // Tracks if 12-sided dice is used
        internal bool cpuUsedDice20 = false; // Tracks if 20-sided dice is used

        DieRoll dice = new DieRoll(); // Instance for DieRoll
        Player gamer = new Player();  // Instance for Player
        Player cpu = new Player();    // Instance for Computer

        internal void Play()
        {
            Intro(); // Introduction message
            PlayerName(); // Get the player's name
            ChangeName(); // Give the player a chance to change the name
            StartGame(); // Begin the game with player turn;
            Outro(); // Ending message
        }

        internal void Intro()
        {
            Console.WriteLine("Hello\r\n");
            Console.WriteLine("Welcome to the ROLL & DIE game.\r\n");
        }

        internal void PlayerName()
        {
            Console.WriteLine("Please enter your name.\r\n");
            username = Console.ReadLine(); // Stores the username
            Console.WriteLine("");
            Console.WriteLine("Your username is " + username);
            Console.WriteLine("");
        }

        internal void ChangeName()
        {
            Console.WriteLine("Do you want to change your username? Type (Yes or No)\r\n");
            string YesOrNo = Console.ReadLine().ToLower(); // Get the answer and convert to lowercase

            if (YesOrNo == "yes")
            {
                PlayerName(); // Change the username if "yes"
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Welcome " + username); // Continue with current name if "no"
                Console.WriteLine("");
            }
            Console.WriteLine("Let's roll the dice\r\n");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("");
        }

        public void StartGame()
        {
            // Player takes the first turn
            PlayerTurn(1);
        }

        // Player's turn to roll a dice
        internal void PlayerTurn(int round)
        {
            Console.WriteLine($"--- Round {round} ---\r\n"); // Display the round number
            Console.WriteLine(username + "'s turn to roll the dice.\r\n");
            Console.WriteLine("Please select a dice (6, 8, 12, 20):\r\n");

            bool validInput = int.TryParse(Console.ReadLine(), out int diceChoice); // Get player's dice selection
            Console.WriteLine("");

            // Check if input is valid
            if (validInput)
            {
                // If player selects a valid dice and it hasn't been used yet
                if (diceChoice == 6 && !playerUsedDice6)
                {
                    int roll = dice.Roll(6); // Roll the 8-sided dice
                    gamer.score += roll; // Adds roll result to player's score
                    playerUsedDice6 = true; // Mark 8-sided dice as used
                    Console.WriteLine(username + " rolled an 6-sided dice and got " + roll);
                    Console.WriteLine("");
                    Console.WriteLine(username + "'s total score is: " + gamer.score + "\n");
                    Console.WriteLine(".....................");
                    Console.WriteLine("");
                    ComputerTurn(round); // Switch to computer's turn
                }
                else if (diceChoice == 8 && !playerUsedDice8)
                {
                    int roll = dice.Roll(8); // Roll the 8-sided dice
                    gamer.score += roll; // Adds roll result to player's score
                    playerUsedDice8 = true; // Mark 8-sided dice as used
                    Console.WriteLine(username + " rolled an 8-sided dice and got " + roll);
                    Console.WriteLine("");
                    Console.WriteLine(username + "'s total score is: " + gamer.score + "\n");
                    Console.WriteLine(".....................");
                    Console.WriteLine("");
                    ComputerTurn(round); // Switch to computer's turn
                }
                else if (diceChoice == 12 && !playerUsedDice12)
                {
                    int roll = dice.Roll(12); // Roll the 12-sided dice
                    gamer.score += roll; // Adds roll result to player's score
                    playerUsedDice12 = true; // Mark 12-sided dice as used
                    Console.WriteLine(username + " rolled a 12-sided dice and got " + roll);
                    Console.WriteLine("");
                    Console.WriteLine(username + "'s total score is: " + gamer.score + "\n");
                    Console.WriteLine(".....................");
                    Console.WriteLine("");
                    ComputerTurn(round); // Switch to computer's turn
                }
                else if (diceChoice == 20 && !playerUsedDice20)
                {
                    int roll = dice.Roll(20); // Roll the 20-sided dice
                    gamer.score += roll; // Adds roll result to player's score
                    playerUsedDice20 = true; // Mark 20-sided dice as used
                    Console.WriteLine(username + " rolled a 20-sided dice and got " + roll);
                    Console.WriteLine("");
                    Console.WriteLine(username + "'s total score is: " + gamer.score + "\n");
                    Console.WriteLine(".....................");
                    Console.WriteLine("");
                    ComputerTurn(round); // Switch to computer's turn
                }
                else
                {
                    // Invalid or already used dice, ask player to choose another
                    Console.WriteLine("Invalid or already used dice. Please select another dice.");
                    PlayerTurn(round); // Recursively call PlayerTurn until a valid dice is selected
                }
            }
            else
            {
                // If input is invalid (not a number)
                Console.WriteLine("Invalid input. Please select a number (6, 8, 12, 20).");
                PlayerTurn(round); // Recursively call PlayerTurn until a valid input is provided
            }
        }

        // Computer's turn to roll a random dice
        internal void ComputerTurn(int round)
        {
            Console.WriteLine("Computer's turn to roll the dice.");
            Console.WriteLine("");
            Random random = new Random(); // Create a random number generator

            // Computer randomly selects a dice, avoiding used ones
            int diceChoice = random.Next(6, 21); // Generate a random number between 6 and 20
            if (diceChoice <= 6 && !cpuUsedDice6)
            {
                int roll = dice.Roll(6); // Roll the 6-sided dice
                cpu.score += roll; // Adds roll result to computer's score
                cpuUsedDice6 = true; // Mark 6-sided dice as used
                Console.WriteLine("Computer rolled a 6-sided dice and got " + roll);
                Console.WriteLine("");
            }
            else if (diceChoice <= 8 && !cpuUsedDice8)
            {
                int roll = dice.Roll(8); // Roll the 8-sided dice
                cpu.score += roll; // Adds roll result to computer's score
                cpuUsedDice8 = true; // Mark 8-sided dice as used
                Console.WriteLine("Computer rolled an 8-sided dice and got " + roll);
                Console.WriteLine("");
            }
            else if (diceChoice <= 12 && !cpuUsedDice12)
            {
                int roll = dice.Roll(12); // Roll the 12-sided dice
                cpu.score += roll; // Adds roll result to computer's score
                cpuUsedDice12 = true; // Mark 12-sided dice as used
                Console.WriteLine("Computer rolled a 12-sided dice and got " + roll);
                Console.WriteLine("");
            }
            else if (diceChoice <= 20 && !cpuUsedDice20)
            {
                int roll = dice.Roll(20); // Roll the 20-sided dice
                cpu.score += roll; // Adds roll result to computer's score
                cpuUsedDice20 = true; // Mark 20-sided dice as used
                Console.WriteLine("Computer rolled a 20-sided dice and got " + roll);
                Console.WriteLine("");
            }
            else
            {
                // If the computer selects an already used dice, try again recursively
                ComputerTurn(round);
                return;
            }

            Console.WriteLine("Computer's total score is: " + cpu.score + "\n");
            Console.WriteLine("");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("");

            if (round < 4)
            {
                PlayerTurn(round + 1); // Proceed to next round
            }
            else
            {
                // Game over, determine and display the winner
                if (gamer.score > cpu.score)
                {
                    Console.WriteLine(username + " scores " + gamer.score);
                    Console.WriteLine("");
                    Console.WriteLine("Computer scores " + cpu.score);
                    Console.WriteLine("");
                    Console.WriteLine(username + " wins with a score of " + gamer.score);
                    Console.WriteLine("");
                }
                else if (cpu.score > gamer.score)
                {
                    Console.WriteLine(username + " scores " + gamer.score);
                    Console.WriteLine("");
                    Console.WriteLine("Computer scores " + cpu.score);
                    Console.WriteLine("");
                    Console.WriteLine("Computer wins with a score of " + cpu.score);
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine(username + " scores " + gamer.score);
                    Console.WriteLine("");
                    Console.WriteLine("Computer scores " + cpu.score);
                    Console.WriteLine("");
                    Console.WriteLine("It's a tie!");
                    Console.WriteLine("");
                }
            }
        }

        internal void Outro()
        {
            Console.WriteLine("Game Over");
            Console.WriteLine("");
            Console.WriteLine("Thank you for playing " + username);
        }
    }
}
