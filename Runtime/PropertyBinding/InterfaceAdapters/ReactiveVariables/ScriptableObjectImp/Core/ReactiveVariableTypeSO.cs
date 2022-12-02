using System;
using UnityEngine;

namespace MVVM.PropertyBinding.InteraceAdapters
{
    public class ReactiveVariableTypeSO<DataType> : ReactiveVariableSO
    {
        [Header("References")]
        [SerializeField] private DataType _defaultValue;

        [Header("Test (only works in play mode)")]
        [SerializeField] private DataType _testValue;

        private IReactiveVariable _reactiveVariable = null;

        public override Type VariableType => typeof(DataType);

        public override IReactiveVariable GetReactiveVariable()
        {
            if (ReferenceEquals(_reactiveVariable, null))
                _reactiveVariable = new ReactiveVariable<DataType>(_defaultValue);

            return _reactiveVariable;
        }

        private void OnValidate()
        {
            if (!Application.isPlaying)
                return;

            GetReactiveVariable().SetValue(_testValue);
        }
    }
}