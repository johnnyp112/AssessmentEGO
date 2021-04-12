using System;
using System.Collections.Generic;
using System.Text;

namespace LeftCenterRightModule.Models
{
    public class Die
    {
        private int _id;
        private int _numberOfSides;

        public Die(int id, int numberOfSides = 6)
        {
            _id = id;
            _numberOfSides = numberOfSides;
        }

        public int Id { get { return _id; } }

        public int Roll()
        {
            Random rand = new Random();
            return rand.Next(1, _numberOfSides + 1);
        }
    }
}
