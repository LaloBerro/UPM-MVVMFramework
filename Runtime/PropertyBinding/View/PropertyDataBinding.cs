using System.Reflection;
using MVVM.PropertyBinding.InteraceAdapters;
using UnityEngine;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;

namespace MVVM.PropertyBinding.View
{
    public class PropertyDataBinding : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PropertyBindingViewModelSO _viewModel;
        [SerializeField] public Object _target;

        [HideInInspector] public int reactiveVariableIndex;
        [HideInInspector] public string _targetPropertyName;

        public string TargetPropertyName { get => _targetPropertyName; set => _targetPropertyName = value; }
        public bool HaveError { get; set; }
        public int ReactiveVariableIndex { get => reactiveVariableIndex; set => reactiveVariableIndex = value; }
        public PropertyBindingViewModelSO ViewModel { get => _viewModel; set => _viewModel = value; }

        private void Awake()
        {
            SubscribeToViewModel();
        }

        private void SubscribeToViewModel()
        {
            if (HaveError)
                return;

            IReactiveVariable reactiveVariable = _viewModel.ReactiveVariableSOs[reactiveVariableIndex].GetReactiveVariable();
            reactiveVariable.Subscribe(() =>
            {
                SetTargetComponentProperty(reactiveVariable.Value);
            });
            
            SetTargetComponentProperty(reactiveVariable.Value);
        }

        private void SetTargetComponentProperty(object obj)
        {
            var bindingFlags = BindingFlags.Instance | BindingFlags.Public;
            var property = _target.GetType().GetProperty(_targetPropertyName, bindingFlags);

            property.SetValue(_target, obj);
        }
    }
}