using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_development___Assignment2
{
    public class Player
    {
        public string Name { get; set; }
        public Position Position { get; set; }
        public int Gemcount { get; set; }
        public Player(String name , Position position)
        {
            this.Name = name;
            this.Position = position;
            Gemcount = 0;
        }


        public void Move(char direction)
        {

            switch (direction)
            {
                case 'U':
                    Position.Y--;
                    break;
                case 'D':
                    Position.Y++;
                    break;
                case 'L':
                    Position.X--;
                    break;
                case 'R':
                    Position.X++;
                    break;
                default:
                    Console.WriteLine("Please use a valid direction to move");
                    break;
            }
        }
    }
}
