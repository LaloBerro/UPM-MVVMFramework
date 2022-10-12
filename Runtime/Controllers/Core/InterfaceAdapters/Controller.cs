using System;
using MVVM.EventBinding.InteraceAdapters;
using UniRx;

namespace MVVM.Controllers
{
    public abstract class Controller : IController
    {
        private readonly EventBindingViewModel _eventBindingViewModel;

        private readonly IDisposable _disposable;

        public Controller(EventBindingViewModel eventBindingViewModel)
        {
            _eventBindingViewModel = eventBindingViewModel;

            _disposable = _eventBindingViewModel.ReactiveCommand.Subscribe(OnCommandExecuted);
        }

        private void OnCommandExecuted(Unit _)
        {
            Execute();
        }

        public abstract void Execute();

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}