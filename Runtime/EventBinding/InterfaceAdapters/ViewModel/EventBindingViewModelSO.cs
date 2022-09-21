using UnityEngine;

namespace MVVM.EventBinding.InteraceAdapters
{
    [CreateAssetMenu(fileName = "EventBindingViewModel", menuName = "ScriptableObjects/MVVM/ViewModel/EventBinding", order = 0)]
    public class EventBindingViewModelSO : ScriptableObject
    {
        private EventBindingViewModel _eventBindingViewModel = null;

        public EventBindingViewModel GetViewModel()
        {
            if (null == _eventBindingViewModel)
                _eventBindingViewModel = new EventBindingViewModel();

            return _eventBindingViewModel;
        }
    }
}