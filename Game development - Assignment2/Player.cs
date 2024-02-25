using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_development___Assignment2
{
    public class Player
    {
        public string Name { get; }
        public Position Position { get; set; }
        public int GemCount { get; set; }

        public Player(string name, Position position)
        {
            Name = name;
            Position = position;
            GemCount = 0;
        }

        public void Move(char direction, Board board)
        {
            int newX = Position.X;
            int newY = Position.Y;

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
                    return;
            }

            // Check for the valid bounds
            if (newX >= 0 && newX < 6 && newY >= 0 && newY < 6)
            {
                // Check the availability of obstacles
                if (board.Grid[newY, newX].Occupant != "O")
                {
                    Position.X = newX;
                    Position.Y = newY;
                }
                else
                {
                    Console.WriteLine("Cannot move through an obstacle!");
                }
            }
            else
            {
                Console.WriteLine("Cannot move outside the board!");
            }

        }
    }
}
