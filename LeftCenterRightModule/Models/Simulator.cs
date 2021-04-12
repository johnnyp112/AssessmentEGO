using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CoreLibrary.Events;
using Prism.Events;

namespace LeftCenterRightModule.Models
{
    public class Simulator
    {
        private IEventAggregator _eventAggregator;
        private int _numOfPlayers;
        private int _numOfGames;

        private int _totalNumberOfTurns;
        private List<int> _totalNumOfTurnsCollection;

        public int TotalNumberOfTurns { get { return _totalNumberOfTurns; } }

        public Simulator(int numOfPlayers, int numOfGames, IEventAggregator eventAggregator)
        {
            _numOfPlayers = numOfPlayers;
            _numOfGames = numOfGames;
            _totalNumOfTurnsCollection = new List<int>();
            _eventAggregator = eventAggregator;
        }

        public bool StartSimulator()
        {
            for (int i = 1; i <= _numOfGames; i++)
            {
                var game = new Game(_numOfPlayers);
                game.StartGame();
                _totalNumberOfTurns = game.TotalNumberOfTurns;
                _totalNumOfTurnsCollection.Add(game.TotalNumberOfTurns);
                game = null;
                _eventAggregator.GetEvent<MessageEvent>().Publish(string.Format("Status: Game {0} completed", i));
            }
            
            return true;
        }

        public int GetShortestLengthGame()
        {
            return _totalNumOfTurnsCollection.Min();
        }

        public int GetLongestLengthGame()
        {
            return _totalNumOfTurnsCollection.Max();
        }

        public double GetAverageLengthGame()
        {
            return _totalNumOfTurnsCollection.Average();
        }
    }
}
