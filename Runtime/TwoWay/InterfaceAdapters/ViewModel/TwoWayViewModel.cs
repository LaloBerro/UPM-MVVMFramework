using UniRx;

namespace MVVM.TwoWay.InteraceAdapters
{
    public class TwoWayViewModel
    {
        private readonly ReactiveCommand _reactiveCommand;
        public ReactiveCommand ReactiveCommand => _reactiveCommand;

        public TwoWayViewModel()
        {
            _reactiveCommand = new ReactiveCommand();
        }
    }
}