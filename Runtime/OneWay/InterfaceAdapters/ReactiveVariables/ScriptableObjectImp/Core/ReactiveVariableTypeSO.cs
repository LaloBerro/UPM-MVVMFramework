using System;
using UnityEngine;

namespace MVVM.OneWay.InteraceAdapters
{
    public class ReactiveVariableTypeSO<DataType> : ReactiveVariableSO
    {
        [Header("References")]
        [SerializeField] private DataType _defaultValue;

        private IReactiveVariable _reactiveVariable = null;

        public override Type VariableType => typeof(DataType);

        public override IReactiveVariable GetReactiveVariable()
        {
            if (ReferenceEquals(_reactiveVariable, null))
                _reactiveVariable = new ReactiveVariable<DataType>(_defaultValue);

            return _reactiveVariable;
        }
    }
}