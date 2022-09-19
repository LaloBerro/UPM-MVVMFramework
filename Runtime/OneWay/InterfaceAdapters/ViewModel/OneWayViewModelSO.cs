using UnityEngine;

namespace MVVM.OneWay.InteraceAdapters
{
    [CreateAssetMenu(fileName = "OneWayViewModelSO", menuName = "ScriptableObjects/MVVM/ViewModel/OneWayViewModel", order = 0)]
    public class OneWayViewModelSO : ScriptableObject
    {
        [Header("References")]
        [SerializeField] private ReactiveVariableSO[] _reactiveVariableSOs;

        private OneWayViewModel _oneWayViewModel;

        public ReactiveVariableSO[] ReactiveVariableSOs => _reactiveVariableSOs;

        public OneWayViewModel GetOneWayViewModel()
        {
            if (!ReferenceEquals(_oneWayViewModel, null))
                return _oneWayViewModel;

            int totalreactiveVariables = _reactiveVariableSOs.Length;
            IReactiveVariable[] reactiveVariables = new IReactiveVariable[totalreactiveVariables];

            for (int i = 0; i < totalreactiveVariables; i++)
            {
                reactiveVariables[i] = _reactiveVariableSOs[i].GetReactiveVariable();
            }

            _oneWayViewModel = new OneWayViewModel(reactiveVariables);

            return _oneWayViewModel;
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