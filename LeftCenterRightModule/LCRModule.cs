using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;
using LeftCenterRightModule.Views;
using LeftCenterRightModule.ViewModels;
using Prism.Mvvm;

namespace LeftCenterRightModule
{
    public class LCRModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public LCRModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(SimulatorView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register<SimulatorView, SimulatorViewModel>();
        }
    }
}
