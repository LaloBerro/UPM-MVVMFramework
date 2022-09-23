using MVVM.EventBinding.InteraceAdapters;
using UniRx;

namespace MVVM.Controllers
{
    public abstract class Controller : IController
    {
        private readonly EventBindingViewModel _twoWayViewModel;

        public Controller(EventBindingViewModel twoWayViewModel)
        {
            _twoWayViewModel = twoWayViewModel;

            _twoWayViewModel.ReactiveCommand.Subscribe(OnCommandExecuted);
        }

        private void OnCommandExecuted(Unit _)
        {
            Execute();
        }

        public abstract void Execute();
    }
}