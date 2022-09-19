using System;
using UnityEngine.EventSystems;

namespace MVVM.TwoWay.View
{
    public class BaseEventObserver : IObserver<BaseEventData>
    {
        public Action OnComplete { get; set; }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(BaseEventData value)
        {
            OnComplete?.Invoke();
        }
    }
}