using System;
using System.Collections.Generic;
using System.Text;

namespace LeftCenterRightModule.Models
{
    public class Player
    {
        private int _id;
        private string _name;
        private int _numberOfChips;
        private int _numberOfTurns;

        public Player(int id)
        {
            _id = id;
            _numberOfChips = 3;
            _numberOfTurns = 0;
        }

        #region Properties
        public int Id { get { return _id; } }
        public string Name { get; set; }
        public int NumberOfChips { get { return _numberOfChips; } }
        public int NumberOfTurns { get { return _numberOfTurns; } }

        public void AddChip()
        {
            _numberOfChips++;
        }

        public void RemoveChip()
        {
            if (_numberOfChips > 0) _numberOfChips--;
        }
        #endregion
    }
}
