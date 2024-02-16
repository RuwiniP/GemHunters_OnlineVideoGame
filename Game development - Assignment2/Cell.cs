using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_development___Assignment2
{
    public class Cell
    {
        public String Occupant { get; set;}

        public Cell(string occupant)
        {
            this.Occupant = occupant;
        }
    }
}
