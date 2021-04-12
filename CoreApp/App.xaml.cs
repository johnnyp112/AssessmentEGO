using CoreApp.ViewModels;
using CoreApp.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows;

namespace CoreApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            IRegionManager regionManager = Container.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("StatusRegion", typeof(StatusView));

            ViewModelLocationProvider.Register<StatusView, StatusViewModel>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<LeftCenterRightModule.LCRModule>();
        }
    }
}
