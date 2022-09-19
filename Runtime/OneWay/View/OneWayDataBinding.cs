using System.Reflection;
using MVVM.OneWay.InteraceAdapters;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MVVM.OneWay.View
{
    public class OneWayDataBinding : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private OneWayViewModelSO _viewModel;
        [SerializeField] public Object _target;

        [HideInInspector] public int _reactibeVariableIndex;
        [HideInInspector] public string _targetPropertyName;

        public string TargetPropertyName { get => _targetPropertyName; set => _targetPropertyName = value; }
        public bool HaveError { get; set; }
        public int ReactibeVariableIndex { get => _reactibeVariableIndex; set => _reactibeVariableIndex = value; }
        public OneWayViewModelSO ViewModel { get => _viewModel; set => _viewModel = value; }

        private void Awake()
        {
            SubscribeToViewModel();
        }

        private void SubscribeToViewModel()
        {
            if (HaveError)
                return;

            IReactiveVariable reactiveVariable = _viewModel.ReactiveVariableSOs[_reactibeVariableIndex].GetReactiveVariable();
            reactiveVariable.Subscribe(() =>
            {
                SetTargetComponentProperty(reactiveVariable.Value);
            });
        }

        private void SetTargetComponentProperty(object obj)
        {
            var bindingFlags = BindingFlags.Instance | BindingFlags.Public;
            var property = _target.GetType().GetProperty(_targetPropertyName, bindingFlags);

            property.SetValue(_target, obj);
        }
    }
}