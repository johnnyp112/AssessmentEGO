using System;
using System.Collections.Generic;
using System.Text;

namespace LeftCenterRightModule.Models
{
    public class Pot
    {
        private int _numberOfChips;

        public Pot()
        {
            _numberOfChips = 0;
        }

        public int NumberOfChips { get; set; }
    }
}
