using MVVM.EventBinding.InteraceAdapters;
using UnityEngine;
using UnityEngine.UI;

namespace MVVM.EventBinding.View
{
    public abstract class ButtonView : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] protected Button _button;
        [SerializeField] private EventBindingViewModelSO _eventBindingViewModelSO;

        private void Awake()
        {
            Subscribe();
        }

        public abstract void Subscribe();

        protected void ExecuteCommand()
        {
            _eventBindingViewModelSO.GetViewModel().ReactiveCommand.Execute();
        }

        protected abstract void Dispose();
    }
}