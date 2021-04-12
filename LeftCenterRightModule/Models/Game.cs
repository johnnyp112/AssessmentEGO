using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeftCenterRightModule.Models
{
    public class Game
    {
        private int _totalNumberOfTurns = 0;
        private List<Player> _playerCollection;
        private List<Die> _listOfDie;
        private int _numberOfChipsInPot = 0;

        private enum DieResult
        {
            NoAction, Left, Center, Right
        }

        public Game(int numberOfPlayers)
        {
            _playerCollection = new List<Player>();

            for (int i = 0; i < numberOfPlayers; i++)
            {
                var player = new Player(i);
                _playerCollection.Add(player);
            }

            _listOfDie = new List<Die>();

            for (int i = 0; i < 3; i++)
            {
                var die = new Die(i);
                _listOfDie.Add(die);
            }
        }

        public int TotalNumberOfTurns { get { return _totalNumberOfTurns; } }

        public void StartGame()
        {
            int currentPlayerIndex;
            int numOfDie;

            while (!IsGameDone())
            {
                foreach (var p in _playerCollection)
                {
                    currentPlayerIndex = _playerCollection.IndexOf(p);

                    numOfDie = GetNumberOfDie(p.NumberOfChips);

                    if (numOfDie > 0)
                    {
                        for (int i = 0; i <= (numOfDie - 1); i++)
                        {
                            switch (GetDieResult(_listOfDie[i].Roll()))
                            {
                                case DieResult.Left:
                                    if (currentPlayerIndex == (_playerCollection.Count - 1))
                                    {
                                        // current player is last, get first player index
                                        _playerCollection[0].AddChip();
                                    }
                                    else
                                        _playerCollection.ElementAt(currentPlayerIndex + 1).AddChip();

                                    p.RemoveChip();
                                    break;

                                case DieResult.Center:
                                    _numberOfChipsInPot++;
                                    p.RemoveChip();
                                    break;

                                case DieResult.Right:
                                    if (currentPlayerIndex == 0)
                                    {
                                        // current player is first, get last player index
                                        _playerCollection.ElementAt(_playerCollection.Count - 1).AddChip();
                                    }
                                    else
                                        _playerCollection.ElementAt(currentPlayerIndex - 1).AddChip();

                                    p.RemoveChip();
                                    break;
                            }
                        }
                    }
                }

                _totalNumberOfTurns++;
            }
        }

        public bool IsGameDone()
        {
            int numOfPlayersWithChips = 0;
            int numOfPlayersWithNoChips = 0;

            foreach (var p in _playerCollection)
            {
                if (p.NumberOfChips > 0) numOfPlayersWithChips++;
                else numOfPlayersWithNoChips++;
            }

            if (numOfPlayersWithChips <= 1) return true;
            else return false;
        }

        private int GetNumberOfDie(int numOfChips)
        {
            if (numOfChips <= 0) return 0;
            else if (numOfChips > 3) return 3;
            else return numOfChips;
        }

        private DieResult GetDieResult(int value)
        {
            if (value == 4) return DieResult.Left;

            if (value == 5) return DieResult.Center;

            if (value == 6) return DieResult.Right;

            return DieResult.NoAction;
        }
    }
}
