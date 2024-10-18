using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A2_SreejaYathipathi
{
    internal class AsciiArt
    {
        // Welcome art.
        public void Welcome()
        {
            Console.WriteLine("Welcom to \r\n");
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════╗\r\n" +
                              "║                                                                                      ║\r\n" +
                              "║  ▓█████▄ ▓█████ ▄▄▄     ▄▄▄█████▓ ██░ ██         ▄████  ▄▄▄       ███▄ ▄███▓▓█████   ║\r\n" +
                              "║  ▒██▀ ██▌▓█   ▀▒████▄   ▓  ██▒ ▓▒▓██░ ██▒       ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀   ║\r\n" +
                              "║  ░██   █▌▒███  ▒██  ▀█▄ ▒ ▓██░ ▒░▒██▀▀██░      ▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███     ║\r\n" +
                              "║  ░▓█▄   ▌▒▓█  ▄░██▄▄▄▄██░ ▓██▓ ░ ░▓█ ░██       ░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄   ║\r\n" +
                              "║  ░▒████▓ ░▒████▒▓█   ▓██▒ ▒██▒ ░ ░▓█▒░██▓      ░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒  ║\r\n" +
                              "║   ▒▒▓  ▒ ░░ ▒░ ░▒▒   ▓▒█░ ▒ ░░    ▒ ░░▒░▒       ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░  ║\r\n" +
                              "║   ░ ▒  ▒  ░ ░  ░ ▒   ▒▒ ░   ░     ▒ ░▒░ ░        ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░  ║\r\n" +
                              "║   ░ ░  ░    ░    ░   ▒    ░       ░  ░░ ░      ░ ░   ░   ░   ▒   ░      ░      ░     ║\r\n" +
                              "║     ░       ░  ░     ░  ░         ░  ░  ░            ░       ░  ░       ░      ░  ░  ║\r\n" +
                              "║   ░                                                                                  ║\r\n" +
                              "║                                                                                      ║\r\n" +
                              "╚══════════════════════════════════════════════════════════════════════════════════════╝");
        }

        // Rules
        public void About()
        {
            Console.WriteLine("\nThese are the rules of the game.");
            Console.WriteLine("\nPress enter to continue the rules");
            Console.WriteLine("\nPlayer can select how many rooms they want to play from 6, 8, 10");
            Console.WriteLine("\nThere are total three type of rooms.");
            Console.WriteLine("\n1 - Treasure Room");
            Console.WriteLine("\n2 - Normal Room");
            Console.WriteLine("\n3 - Combat Room");
            Console.WriteLine("\nIn Tresure Room, you can search for tresure chest.");
            Console.WriteLine("\nTreasure Chest consists of 2 to 4 items, which can be Long Sword, Dagger, Polearm, Small Healing Potion, Medium Healing Potion, Large Healing Potion.");
            Console.WriteLine("\nYou can either pick it or leave it.");
            Console.WriteLine("\nIn Normal Room, you can find any of one or two items if you search for it.");
            Console.WriteLine("\nIn Combat Room, you can't exit unless you have defeated the boss.");
            Console.WriteLine("\nYou can choose a weapon from your inventory. Each weapon have different type of damage");
            Console.WriteLine("\nLong sword - High damage");
            Console.WriteLine("\nPolearm - medium damage");
            Console.WriteLine("\nDagger - medium-low damage");
            Console.WriteLine("\nYou can press keys aor attacking.");
            Console.WriteLine("\nZ - High damage");
            Console.WriteLine("\nX - Medium damage");
            Console.WriteLine("\nC - Low damage");
            Console.WriteLine("\nSmall healing potion restores 25% health.");
            Console.WriteLine("\nMedium healing potion restores 50% health.");
            Console.WriteLine("\nLarge healing potion restores 100% health.");
            Console.WriteLine("\nIf you died, you are out of the game. You can select if you want to play again or not.");
        }

        // Died art
        public void Died()
        {
            Console.WriteLine("╔═════════════════════════════════════════════════════════════╗\r\n" +
                                      "║                                                             ║\r\n" +
                                      "║  ▓██   ██▓ ▒█████   █    ██    ▓█████▄  ██▓▓█████ ▓█████▄   ║\r\n" +
                                      "║   ▒██  ██▒▒██▒  ██▒ ██  ▓██▒   ▒██▀ ██▌▓██▒▓█   ▀ ▒██▀ ██▌  ║\r\n" +
                                      "║    ▒██ ██░▒██░  ██▒▓██  ▒██░   ░██   █▌▒██▒▒███   ░██   █▌  ║\r\n" +
                                      "║    ░ ▐██▓░▒██   ██░▓▓█  ░██░   ░▓█▄   ▌░██░▒▓█  ▄ ░▓█▄   ▌  ║\r\n" +
                                      "║    ░ ██▒▓░░ ████▓▒░▒▒█████▓    ░▒████▓ ░██░░▒████▒░▒████▓   ║\r\n" +
                                      "║     ██▒▒▒ ░ ▒░▒░▒░ ░▒▓▒ ▒ ▒     ▒▒▓  ▒ ░▓  ░░ ▒░ ░ ▒▒▓  ▒   ║\r\n" +
                                      "║   ▓██ ░▒░   ░ ▒ ▒░ ░░▒░ ░ ░     ░ ▒  ▒  ▒ ░ ░ ░  ░ ░ ▒  ▒   ║\r\n" +
                                      "║   ▒ ▒ ░░  ░ ░ ░ ▒   ░░░ ░ ░     ░ ░  ░  ▒ ░   ░    ░ ░  ░   ║\r\n" +
                                      "║   ░ ░         ░ ░     ░           ░     ░     ░  ░   ░      ║\r\n" +
                                      "║   ░ ░                           ░                  ░        ║\r\n" +
                                      "║                                                             ║\r\n" +
                                      "╚═════════════════════════════════════════════════════════════╝");
        }

        // Gameover art
        public void GameOver()
        {
            Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════════╗\r\n" +
                                      "║                                                                             ║\r\n" +
                                      "║    ▄████  ▄▄▄       ███▄ ▄███▓▓█████     ▒█████   ██▒   █▓▓█████  ██▀███    ║\r\n" +
                                      "║   ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀    ▒██▒  ██▒▓██░   █▒▓█   ▀ ▓██ ▒ ██▒  ║\r\n" +
                                      "║  ▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███      ▒██░  ██▒ ▓██  █▒░▒███   ▓██ ░▄█ ▒  ║\r\n" +
                                      "║  ░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄    ▒██   ██░  ▒██ █░░▒▓█  ▄ ▒██▀▀█▄    ║\r\n" +
                                      "║  ░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒   ░ ████▓▒░   ▒▀█░  ░▒████▒░██▓ ▒██▒  ║\r\n" +
                                      "║   ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░   ░ ▒░▒░▒░    ░ ▐░  ░░ ▒░ ░░ ▒▓ ░▒▓░  ║\r\n" +
                                      "║    ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░     ░ ▒ ▒░    ░ ░░   ░ ░  ░  ░▒ ░ ▒░  ║\r\n" +
                                      "║  ░ ░   ░   ░   ▒   ░      ░      ░      ░ ░ ░ ▒       ░░     ░     ░░   ░   ║\r\n" +
                                      "║        ░       ░  ░       ░      ░  ░       ░ ░        ░     ░  ░   ░       ║\r\n" +
                                      "║                                                       ░                     ║\r\n" +
                                      "║                                                                             ║\r\n" +
                                      "╚═════════════════════════════════════════════════════════════════════════════╝");
        }
    }
}
