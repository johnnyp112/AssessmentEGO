using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using CoreLibrary.Events;
using Prism.Commands;
using LeftCenterRightModule.Models;

namespace LeftCenterRightModule.ViewModels
{
    public class SimulatorViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private int _numberOfPlayers = 3;
        private int _numberOfGames = 1;
        private string _output = "Simulator output";
        private int _shortestLengthGame = 0;
        private int _longestLengthGame = 0;
        private double _averageLengthGame = 0.0;

        private BackgroundWorker _worker = new BackgroundWorker();

        public SimulatorViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            
            _worker.DoWork += DoWork;
            _worker.RunWorkerCompleted += RunWorkerCompleted;

            SimulateCommand = new DelegateCommand(OnSimulate, CanExecute);
        }

        #region Properties
        public int NumberOfPlayers
        {
            get { return _numberOfPlayers; }
            set
            {
                SetProperty(ref _numberOfPlayers, value);
            }
        }

        public int NumberOfGames
        {
            get { return _numberOfGames; }
            set
            {
                SetProperty(ref _numberOfGames, value);
            }
        }

        public string Output
        {
            get { return _output; }
            set
            {
                SetProperty(ref _output, value);
            }
        }

        public int ShortestLengthGame
        {
            get { return _shortestLengthGame; }
            set { SetProperty(ref _shortestLengthGame, value); }
        }

        public int LongestLengthGame
        {
            get { return _longestLengthGame; }
            set { SetProperty(ref _longestLengthGame, value); }
        }

        public double AverageLengthGame
        {
            get { return _averageLengthGame; }
            set { SetProperty(ref _averageLengthGame, value); }
        }

        public DelegateCommand SimulateCommand { get; private set; }
        #endregion

        private bool CanExecute()
        {
            if (NumberOfPlayers >= 3) return true;

            return false;
        }

        private void OnSimulate()
        {
            // TODO: Validate inputs
            ShortestLengthGame = 0;
            LongestLengthGame = 0;
            AverageLengthGame = 0;

            _eventAggregator.GetEvent<MessageEvent>().Publish("Status: Simulation running...");
            _worker.RunWorkerAsync();
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            var sim = new Simulator(NumberOfPlayers, NumberOfGames, _eventAggregator);
            sim.StartSimulator();

            Output = sim.TotalNumberOfTurns.ToString();
            ShortestLengthGame = sim.GetShortestLengthGame();
            LongestLengthGame = sim.GetLongestLengthGame();
            AverageLengthGame = sim.GetAverageLengthGame();
        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _eventAggregator.GetEvent<MessageEvent>().Publish("Status: Process Complete");
        }
    }
}
