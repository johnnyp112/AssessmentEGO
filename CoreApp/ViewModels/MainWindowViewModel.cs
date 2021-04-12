using Prism.Mvvm;

namespace CoreApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Left Center Right Simulator";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
