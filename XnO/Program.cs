using System;
using System.Threading;
using XnO.Model;

namespace XnO
{
    public class Program
    {
        public static XnOGame Game { get; set; }
        public static Player LocalPlayer { get; set; }
        public static void Main(string[] args)
        {
            Game = new XnOGame();
            Console.Title = "XnO";

            Console.WriteLine("Simple Tic-Tac-Toe game!\r\n");
            Game.PrintBoard();
            while (true)
            {
                Console.Write("\r\nPlay as, O or X? ");
                var player = Console.ReadLine().ToLower();
                switch (player)
                {
                    case "x":
                        LocalPlayer = Game.XPlayer;
                        break;

                    case "o":
                        LocalPlayer = Game.OPlayer;
                        break;

                    default:
                        Console.WriteLine("Invalid player");
                        continue;
                }
                break;
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("X's turn!\r\n");
                Game.PrintBoard();
                Console.Write("\r\n>> ");
                var command = Console.ReadLine().ToLower().Split(' ');
                switch (command[0])
                {
                    case "mark":
                        var row = 0;
                        var column = 0;
                        try
                        {
                            row = int.Parse(command[1]);
                            column = int.Parse(command[2]);
                        }
                        catch
                        {
                            // input error
                        }

                        LocalPlayer.Board[row, column] = true;
                        break;
                }
                Thread.Sleep(100);
            }
        }
    }
}
