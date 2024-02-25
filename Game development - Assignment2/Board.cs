using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_development___Assignment2
{
    public class Board
    {
        public Cell[,] Grid;
        private readonly Random random;

        public Board()
        {
            Grid = new Cell[6, 6];
            random = new Random();
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            // Initialize the empty cell
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Grid[i, j] = new Cell("-");
                }
            }

            PlaceGems();
            PlaceObstacles();
        }
        private void PlaceGems()
        {
            for (int i = 0; i < 10; i++) // Place 10 gems
            {
                int x, y;
                do
                {
                    x = random.Next(6);
                    y = random.Next(6);
                } while (Grid[y, x].Occupant != "-");

                Grid[y, x].Occupant = "G";
            }
        }

        private void PlaceObstacles()
        {
            for (int i = 0; i < 8; i++) // Place 8 obstacles
            {
                int x, y;
                do
                {
                    x = random.Next(6);
                    y = random.Next(6);
                } while (Grid[y, x].Occupant != "-");

                Grid[y, x].Occupant = "O";
            }
        }


        public void Display(Player player1, Player player2)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    bool player1AtPosition = player1.Position.X == j && player1.Position.Y == i;
                    bool player2AtPosition = player2.Position.X == j && player2.Position.Y == i;

                    if (player1AtPosition)
                    {
                        Console.Write("P1 ");
                    }
                    else if (player2AtPosition)
                    {
                        Console.Write("P2 ");
                    }
                    else
                    {
                        Console.Write(Grid[i, j].Occupant + " ");
                    }
                }
                Console.WriteLine();
            }
        }

        public bool IsValidMove(Player player, char direction)
        {
            int newX = player.Position.X;
            int newY = player.Position.Y;

            switch (direction)
            {
                case 'U':
                    newY--;
                    break;
                case 'D':
                    newY++;
                    break;
                case 'L':
                    newX--;
                    break;
                case 'R':
                    newX++;
                    break;
                default:
                    Console.WriteLine("Invalid direction!");
                    return false;
            }

            // Checking the avaialability of the new position
            if (newX >= 0 && newX < 6 && newY >= 0 && newY < 6)
            {
                if (Grid[newY, newX].Occupant == "O")
                {
                    Console.WriteLine("Cannot move through an obstacle");
                    return false;
                }
                else
                {
                    return true;
                }

            }
            Console.WriteLine("Invalid move");
            return false;
        }

        public bool CollectGem(Player player)
        {
            if (Grid[player.Position.Y, player.Position.X].Occupant == "G")
            {
                player.GemCount++;
                Grid[player.Position.Y, player.Position.X].Occupant = "-";
                return true;
            }
            return false;
        }
    }
}
