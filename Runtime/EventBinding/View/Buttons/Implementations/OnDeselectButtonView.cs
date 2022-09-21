using System;
using UniRx.Triggers;
using UnityEngine.EventSystems;

namespace MVVM.EventBinding.View
{
    public class OnDeselectButtonView : ButtonView
    {
        private IObservable<BaseEventData> _onDeslect;

        private IDisposable _disposable;
        private BaseEventObserver _observerOnDeselect;

        public override void Subscribe()
        {
            _observerOnDeselect = new BaseEventObserver();
            _observerOnDeselect.OnComplete += () => { ExecuteCommand(); };

            _onDeslect = _button.OnDeselectAsObservable();
            _disposable = _onDeslect.Subscribe(_observerOnDeselect);
        }

        protected override void Dispose()
        {
            _disposable.Dispose();
            _observerOnDeselect.OnComplete -= () => { ExecuteCommand(); };
        }
    }
}