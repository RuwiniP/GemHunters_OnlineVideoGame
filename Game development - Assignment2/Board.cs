using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_development___Assignment2
{
    public class Board
    {
        private Cell[,] grid;

        public Board()
        {

            grid = new Cell[6, 6];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    grid[i, j] = new Cell("-");
                }
            }
        }
    }
}
