using CoreLibrary.Events;
using Prism.Events;
using Prism.Mvvm;

namespace CoreApp.ViewModels
{
    public class StatusViewModel : BindableBase
    {
        private string _message;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public StatusViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<MessageEvent>().Subscribe(OnMessageReceived, ThreadOption.PublisherThread, false,
                message => message.Contains("Status"));
        }

        private void OnMessageReceived(string message)
        {
            Message = message;
        }
    }
}
