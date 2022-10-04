using MVVM.EventBinding.InteraceAdapters;
using UniRx;

namespace MVVM.Controllers
{
    public abstract class Controller : IController
    {
        private readonly EventBindingViewModel _eventBindingViewModel;

        public Controller(EventBindingViewModel eventBindingViewModel)
        {
            _eventBindingViewModel = eventBindingViewModel;

            _eventBindingViewModel.ReactiveCommand.Subscribe(OnCommandExecuted);
        }

        private void OnCommandExecuted(Unit _)
        {
            Execute();
        }

        public abstract void Execute();
    }
}