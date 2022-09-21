using UnityEngine;

namespace MVVM.PropertyBinding.InteraceAdapters
{
    [CreateAssetMenu(fileName = "PropertyBindingViewModelSO", menuName = "ScriptableObjects/MVVM/ViewModel/PropertyBinding", order = 0)]
    public class PropertyBindingViewModelSO : ScriptableObject
    {
        [Header("References")]
        [SerializeField] private ReactiveVariableSO[] _reactiveVariableSOs;

        private PropertyBindingViewModel _propertyBindingViewModel;

        public ReactiveVariableSO[] ReactiveVariableSOs => _reactiveVariableSOs;

        public PropertyBindingViewModel GetViewModel()
        {
            if (!ReferenceEquals(_propertyBindingViewModel, null))
                return _propertyBindingViewModel;

            int totalreactiveVariables = _reactiveVariableSOs.Length;
            IReactiveVariable[] reactiveVariables = new IReactiveVariable[totalreactiveVariables];

            for (int i = 0; i < totalreactiveVariables; i++)
            {
                reactiveVariables[i] = _reactiveVariableSOs[i].GetReactiveVariable();
            }

            _propertyBindingViewModel = new PropertyBindingViewModel(reactiveVariables);

            return _propertyBindingViewModel;
        }

        public IReactiveVariable GetReactiveVariableByIndex(int index)
        {
            if (index >= _reactiveVariableSOs.Length)
                throw new System.Exception("OneWayViewModelSO error: there isn't a reactive variable with index " + index);

            IReactiveVariable reactiveVariable = _reactiveVariableSOs[index].GetReactiveVariable();

            return reactiveVariable;
        }
    }
}