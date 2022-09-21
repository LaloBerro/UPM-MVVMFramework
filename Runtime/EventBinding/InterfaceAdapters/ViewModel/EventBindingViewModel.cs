using UniRx;

namespace MVVM.EventBinding.InteraceAdapters
{
    public class EventBindingViewModel
    {
        private readonly ReactiveCommand _reactiveCommand;
        public ReactiveCommand ReactiveCommand => _reactiveCommand;

        public EventBindingViewModel()
        {
            _reactiveCommand = new ReactiveCommand();
        }
    }
}