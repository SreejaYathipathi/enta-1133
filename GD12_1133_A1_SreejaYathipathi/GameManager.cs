using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A1_SreejaYathipathi
{
    /// <summary>
    /// The GameManager class is responsible for managing the overall game flow,
    /// including the introduction, rules, and interactions with the player.
    /// </summary>
    
    internal class GameManager
    {
        Player player = new Player(); // Create an instance of the Player class to manage player-specific actions.
        Computer cpu = new Computer(); // Create an instance of the computer class to manage computer-specific actions.
        DieRoll dice = new DieRoll(); // Instantiate the DieRoll class for dice-related functionality.
        private int totalRounds; // Variable to hold the total number of rounds for the game.


        /// <summary>
        /// Starts the game by displaying the introduction and explaining the rules.
        /// </summary>

        internal void Play()
        {
            Intro(); // Display the game introduction.
            Rules(); // Display the game rules and interact with the player.
            Asking(); // Asking the player if they want to play or not.
            StartGame(); // Starting the game.
        }

        /// <summary>
        /// Displays the introduction message for the game, including ASCII art and a welcome message.
        /// </summary>
        
        internal void Intro()
        {
            Console.WriteLine("Hello! Welcome to \r\n");
            Console.WriteLine("\"\"\"\r\n"+
                              "===============================================================================+\r\n|" +
                              "|\r\n| ▓█████▄  ██▓▓█████     ▒█████   ██▀███      ██▀███   ▒█████   ██▓     ██▓     " +
                              "|\r\n| ▒██▀ ██▌▓██▒▓█   ▀    ▒██▒  ██▒▓██ ▒ ██▒   ▓██ ▒ ██▒▒██▒  ██▒▓██▒    ▓██▒     " +
                              "|\r\n| ░██   █▌▒██▒▒███      ▒██░  ██▒▓██ ░▄█ ▒   ▓██ ░▄█ ▒▒██░  ██▒▒██░    ▒██░     " +
                              "|\r\n| ░▓█▄   ▌░██░▒▓█  ▄    ▒██   ██░▒██▀▀█▄     ▒██▀▀█▄  ▒██   ██░▒██░    ▒██░     " +
                              "|\r\n| ░▒████▓ ░██░░▒████▒   ░ ████▓▒░░██▓ ▒██▒   ░██▓ ▒██▒░ ████▓▒░░██████▒░██████▒ " +
                              "|\r\n|  ▒▒▓  ▒ ░▓  ░░ ▒░ ░   ░ ▒░▒░▒░ ░ ▒▓ ░▒▓░   ░ ▒▓ ░▒▓░░ ▒░▒░▒░ ░ ▒░▓  ░░ ▒░▓  ░ " +
                              "|\r\n|  ░ ▒  ▒  ▒ ░ ░ ░  ░     ░ ▒ ▒░   ░▒ ░ ▒░     ░▒ ░ ▒░  ░ ▒ ▒░ ░ ░ ▒  ░░ ░ ▒  ░ " +
                              "|\r\n|  ░ ░  ░  ▒ ░   ░      ░ ░ ░ ▒    ░░   ░      ░░   ░ ░ ░ ░ ▒    ░ ░     ░ ░    " +
                              "|\r\n|    ░     ░     ░  ░       ░ ░     ░           ░         ░ ░      ░  ░    ░  ░ " +
                              "|\r\n|  ░                                                                            " +
                              "|\r\n|                                                                               " +
                              "|\r\n+===============================================================================" +
                              "\r\n\"\"\"");
        }

        /// <summary>
        /// Displays the rules of the game and allows the player to enter their name and change it if desired.
        /// </summary>
        
        internal void Rules()
        {
            player.PlayerName(); // Ask the player for their name.

            player.ChangeName(); // Provide the player with an option to change their name.

            // Display rules of the game.

            WaitForEnter("Press Enter to continue.");
            Console.WriteLine("");

            Console.WriteLine("Then let me explain the rules of the game.\r\n");

            Console.WriteLine("****************************** GAME ROUNDS ******************************\r\n");
            Console.WriteLine("At the start of the game," + player.GetPlayerName() + " will choose how many rounds to play (between 1 and 10).\r\n");
            Console.ReadLine();

            Console.WriteLine("**************************** DICE SELECTION ****************************\r\n");
            Console.WriteLine("There are 10 unique dice to choose from: d8, d16, d24, d32, d40, d48, d56, d64, d72, and d80.\r\n");
            Console.WriteLine("In each round, both computer and " + player.GetPlayerName() + " must select one unused die from the available pool.\r\n");
            Console.WriteLine("Once a die has been used, it cannot be selected again for the rest of the game.\r\n");
            Console.WriteLine("If computer or " + player.GetPlayerName() + " select a previously used die, they need to choose a different one.\r\n");
            Console.ReadLine();

            Console.WriteLine("**************************** ROLLING THE DICE ***************************\r\n");
            Console.WriteLine("Both computer or " + player.GetPlayerName() + " will roll their chosen dice to know how many people they ‘kill’ in that round.\r\n");
            Console.WriteLine("Whoever with the highest kills WINS the round.\r\n");
            Console.WriteLine("In the event of a tie, both computer or " + player.GetPlayerName() + " will reroll the same dice until a winner is determined.\r\n");
            Console.ReadLine();

            Console.WriteLine("****************************** SCORING SYSTEM ***************************\r\n");
            Console.WriteLine("Whoever with the highest total kills after all rounds WINS the game.\r\n");
            Console.WriteLine("If there is a tie at the end of all rounds, both computer or " + player.GetPlayerName() + " will reroll to determine the final winner.\r\n");

        }

        /// <summary>
        /// Asks the player if they want to continue playing or exit the game.
        /// </summary>

        internal void Asking()
        {
            Console.WriteLine("Do you want to Roll and Live? or you want to DIE?\r\n");
            Console.WriteLine("(Enter Yes or no)\r\n");
            string ask = Console.ReadLine().ToLower();
            Console.WriteLine("");

            /*while (ask != "yes" && ask != "no")
            {
                // Notify user of invalid input
                Console.WriteLine("\nYou have to select yes or no.\r");
                ask = Console.ReadLine().ToLower();
            }*/

            if (ask == "no")
            {
                Console.WriteLine(": \" " +
                           "\r\n+===========================================================+" +
                           "\r\n|                                                           |" +
                           "\r\n| ▓██   ██▓ ▒█████   █    ██    ▓█████▄  ██▓▓█████ ▓█████▄  |" +
                           "\r\n|  ▒██  ██▒▒██▒  ██▒ ██  ▓██▒   ▒██▀ ██▌▓██▒▓█   ▀ ▒██▀ ██▌ |" +
                           "\r\n|   ▒██ ██░▒██░  ██▒▓██  ▒██░   ░██   █▌▒██▒▒███   ░██   █▌ |" +
                           "\r\n|   ░ ▐██▓░▒██   ██░▓▓█  ░██░   ░▓█▄   ▌░██░▒▓█  ▄ ░▓█▄   ▌ |" +
                           "\r\n|   ░ ██▒▓░░ ████▓▒░▒▒█████▓    ░▒████▓ ░██░░▒████▒░▒████▓  |" +
                           "\r\n|    ██▒▒▒ ░ ▒░▒░▒░ ░▒▓▒ ▒ ▒     ▒▒▓  ▒ ░▓  ░░ ▒░ ░ ▒▒▓  ▒  |" +
                           "\r\n|  ▓██ ░▒░   ░ ▒ ▒░ ░░▒░ ░ ░     ░ ▒  ▒  ▒ ░ ░ ░  ░ ░ ▒  ▒  |" +
                           "\r\n|  ▒ ▒ ░░  ░ ░ ░ ▒   ░░░ ░ ░     ░ ░  ░  ▒ ░   ░    ░ ░  ░  |" +
                           "\r\n|  ░ ░         ░ ░     ░           ░     ░     ░  ░   ░     |" +
                           "\r\n|  ░ ░                           ░                  ░       |" +
                           "\r\n|                                                           |" +
                           "\r\n+===========================================================+" +
                           "\r\n\"");
                Environment.Exit(0);
            }

            else // If the player chooses to continue, proceed to round selection.
            {
                Console.WriteLine("\nNice choice " + player.GetPlayerName() + ". I see you don't want to die.\r");
                Console.WriteLine("\nLet's begin this DEATH game.\r");
            }
        }

        public void StartGame()
        {
            player.PlayerInitializeDice(); // Initialize the dice for player.
            cpu.CpuInitializeDice(); // Initialize the dice for computer.

            Console.WriteLine("\nHow many rounds would you like to play (1-10)?\r\n"); // Prompt the user for the number of rounds to play.

            // Check the input to ensure it's an integer between 1 and 10.

            while (!int.TryParse(Console.ReadLine(), out totalRounds) || totalRounds < 1 || totalRounds > 10)
            {
                // Notify user of invalid input.

                Console.WriteLine("\nInvalid input. Please enter a number between 1 and 10.\r\n");
            }

            RunGameLoop(); // Start the main game loop.

            EndGame(); // Execute the end game procedure.
        }

        private void RunGameLoop()
        {

            // Loop through the number of rounds specified.

            for (int round = 1; round <= totalRounds; round++)
            {
                Console.WriteLine("\n------------------ Round " + round + " ------------------\r"); // Indicate the start of the current round

                // Ask who should go first in this round
                Console.WriteLine("\nWho should go first for killing spree?\r");
                Console.WriteLine("\nEnter 'p' for player or 'c' for computer.\r");
                Console.WriteLine("");
                string turnChoice = Console.ReadLine().ToLower();
                Console.WriteLine("");

                // Check the user's choice for who goes first.

                while (turnChoice != "p" && turnChoice != "c")
                {
                    // Notify user of invalid input
                    Console.WriteLine("\nYou have to select computer or you for killing spree.\r");
                    turnChoice = Console.ReadLine().ToLower();
                }

                // Determine if the player goes first based on their input.

                bool playerGoesFirst = turnChoice == "p";

                // Execute turns based on the player's choice
                if (playerGoesFirst)
                {
                    // Player takes their turn first

                    player.PlayerTakeTurn();

                    WaitForEnter("Press Enter for the computer to roll.");
                    Console.WriteLine("");
                    Console.WriteLine("");

                    cpu.CpuTurn();
                }
                else
                {
                    // Computer takes its turn first

                    cpu.CpuTurn();

                    WaitForEnter("Press Enter for the player to roll.");
                    Console.WriteLine("");
                    Console.WriteLine("");

                    player.PlayerTakeTurn();
                }

                WaitForEnter("Press Enter to see stats of this round.");
                Console.WriteLine("");

                // Display round results
                Console.WriteLine("\nEnd of round " + round + " killing spree\r\n");

                // Show the player's roll and score.
                Console.WriteLine(player.GetPlayerName() + "'s rolled: " + player.PlayerGetselectedDice() + "\r\n");
                Console.WriteLine("Kills for this round is " + player.PlayerGetRoundKills() + "\r\n");
                Console.WriteLine("Total Kills: " + player.PlayerGetKill() + "\r\n");

                // Show the computer's roll and score.
                Console.WriteLine("Computer's rolled: " + cpu.CpuGetselectedDice() + "\r\n");
                Console.WriteLine("Kills for this round is " + cpu.CpuGetRoundKills() + "\r\n");
                Console.WriteLine("Total Kills: " + cpu.CpuGetKill() + "\r\n");

                // Determine the winner of the round
                if (player.PlayerGetLastKills() > cpu.CpuGetLastKills())
                {
                    // Player wins the round
                    Console.WriteLine("\n" + player.GetPlayerName() + " wins Round " + round + "\r\n");
                }
                else if (player.PlayerGetLastKills() < cpu.CpuGetLastKills())
                {
                    // Computer wins the round
                    Console.WriteLine("\nComputer wins Round" + round + "\r\n");
                }
                else
                {
                    // Round is a tie.
                    Console.WriteLine("\nRound " + round + " is a tie!\r\n");
                }

                WaitForEnter("Press Enter to go to next round.");
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// Reading if the enter is pressed or not.
        /// </summary>

        private void WaitForEnter(string message)
        {
            Console.WriteLine(message);
            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
            {
                // Keep asking until Enter is pressed
            }
        }

        /// <summary>
        /// Evaluates the scores of both players and announces the overall winner.
        /// </summary>

        private void EndGame()
        {
            Console.WriteLine("\n------------------ Game Over ------------------\r\n"); // Indicate the end of the game.

            player.PlayerKillStats(); // Display statistics for the player.
            cpu.CpuKillStats(); // Display statistics for the computer.

            // Final comparison of scores
            if (player.PlayerGetKill() > cpu.CpuGetKill())
            {
                // Player wins the game.

                Console.WriteLine("\r\nToo bad...\r\n");
                Console.WriteLine("You are a \r\n");
                Console.WriteLine(": \"\r\n+===============================================================================+" +
                                      "\r\n|                                                                               |" +
                                      "\r\n|  █████   ███   ████████████████   ███████████   ███████████████ ███████████   |" +
                                      "\r\n| ░░███   ░███  ░░███░░███░░██████ ░░███░░██████ ░░███░░███░░░░░█░░███░░░░░███  |" +
                                      "\r\n|  ░███   ░███   ░███ ░███ ░███░███ ░███ ░███░███ ░███ ░███  █ ░  ░███    ░███  |" +
                                      "\r\n|  ░███   ░███   ░███ ░███ ░███░░███░███ ░███░░███░███ ░██████    ░██████████   |" +
                                      "\r\n|  ░░███  █████  ███  ░███ ░███ ░░██████ ░███ ░░██████ ░███░░█    ░███░░░░░███  |" +
                                      "\r\n|   ░░░█████░█████░   ░███ ░███  ░░█████ ░███  ░░█████ ░███ ░   █ ░███    ░███  |" +
                                      "\r\n|     ░░███ ░░███     ██████████  ░░██████████  ░░███████████████ █████   █████ |" +
                                      "\r\n|      ░░░   ░░░     ░░░░░░░░░░    ░░░░░░░░░░    ░░░░░░░░░░░░░░░ ░░░░░   ░░░░░  |" +
                                      "\r\n|                                                                               |" +
                                      "\r\n+===============================================================================+" +
                                      "\r\n\"");
            }
            else if (player.PlayerGetKill() < cpu.CpuGetKill())
            {
                // Computer wins the game.

                Console.WriteLine("Computer Wins!\r\n");
                Console.WriteLine(": \" " +
                           "\r\n+===========================================================+" +
                           "\r\n|                                                           |" +
                           "\r\n| ▓██   ██▓ ▒█████   █    ██    ▓█████▄  ██▓▓█████ ▓█████▄  |" +
                           "\r\n|  ▒██  ██▒▒██▒  ██▒ ██  ▓██▒   ▒██▀ ██▌▓██▒▓█   ▀ ▒██▀ ██▌ |" +
                           "\r\n|   ▒██ ██░▒██░  ██▒▓██  ▒██░   ░██   █▌▒██▒▒███   ░██   █▌ |" +
                           "\r\n|   ░ ▐██▓░▒██   ██░▓▓█  ░██░   ░▓█▄   ▌░██░▒▓█  ▄ ░▓█▄   ▌ |" +
                           "\r\n|   ░ ██▒▓░░ ████▓▒░▒▒█████▓    ░▒████▓ ░██░░▒████▒░▒████▓  |" +
                           "\r\n|    ██▒▒▒ ░ ▒░▒░▒░ ░▒▓▒ ▒ ▒     ▒▒▓  ▒ ░▓  ░░ ▒░ ░ ▒▒▓  ▒  |" +
                           "\r\n|  ▓██ ░▒░   ░ ▒ ▒░ ░░▒░ ░ ░     ░ ▒  ▒  ▒ ░ ░ ░  ░ ░ ▒  ▒  |" +
                           "\r\n|  ▒ ▒ ░░  ░ ░ ░ ▒   ░░░ ░ ░     ░ ░  ░  ▒ ░   ░    ░ ░  ░  |" +
                           "\r\n|  ░ ░         ░ ░     ░           ░     ░     ░  ░   ░     |" +
                           "\r\n|  ░ ░                           ░                  ░       |" +
                           "\r\n|                                                           |" +
                           "\r\n+===========================================================+" +
                           "\r\n\"");
            }
            else
            {
                // Game ends in a tie.

                Console.WriteLine("It's a Tie!");
            }

            // Ask if the player wants to play again

            Console.WriteLine("Do you want to play again?\r\n");
            Console.WriteLine("Yes or No?\r\n");

            // Check the player's response.

            if (Console.ReadLine().ToLower() == "yes")
            {
                Console.WriteLine("");
                // Start a new game if the player wants to play again.
                StartGame();
            }
            else
            {
                Console.WriteLine("");
                // Thank the player for playing and exit.
                Console.WriteLine("Thanks for playing!");
            }
        }
    }
}
