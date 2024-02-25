using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_development___Assignment2
{
    public class Game
    {
        private readonly Board Board;
        private readonly Player Player1;
        private readonly Player Player2;
        private Player CurrentTurn;
        private int TotalTurns;

        public Game()
        {
            Board = new Board();
            Player1 = new Player("P1", new Position(0, 0));
            Player2 = new Player("P2", new Position(5, 5));
            CurrentTurn = Player1;
            TotalTurns = 0;
        }

        public void Start()
        {
            while (!IsGameOver())
            {
                Console.WriteLine($"Turn {TotalTurns + 1}: {CurrentTurn.Name}'s turn");
                Board.Display(Player1, Player2);

                char direction;
                do
                {
                    Console.Write("Enter direction (U/D/L/R): ");
                    direction = char.ToUpper(Console.ReadKey().KeyChar);
                    Console.WriteLine();
                } while (!Board.IsValidMove(CurrentTurn, direction));

                CurrentTurn.Move(direction, Board);
                if (Board.CollectGem(CurrentTurn))
                {
                    Console.WriteLine($"{CurrentTurn.Name} collected a gem!");
                }

                TotalTurns++;
                SwitchTurn();
            }

            AnnounceWinner();
            Thread.Sleep(6000); // wait before closing the console
        }

        private void SwitchTurn()
        {
            CurrentTurn = (CurrentTurn == Player1) ? Player2 : Player1;
        }

        private bool IsGameOver()
        {
            return TotalTurns >= 30;
        }

        private void AnnounceWinner()
        {
            Console.WriteLine("Game Over!");
            Console.WriteLine($"Player 1 collected {Player1.GemCount} gems");
            Console.WriteLine($"Player 2 collected {Player2.GemCount} gems");

            if (Player1.GemCount > Player2.GemCount)
            {
                Console.WriteLine("Player 1 wins!");
            }
            else if (Player2.GemCount > Player1.GemCount)
            {
                Console.WriteLine("Player 2 wins!");
            }
            else
            {
                //If equal number of gems were collected
                Console.WriteLine("It's a tie!");
            }
        }
    }
}
