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
        [SerializeField] private bool _setDirty;

        private IReactiveVariable _reactiveVariable = null;

        public override Type VariableType => typeof(DataType);

        public override IReactiveVariable GetReactiveVariable()
        {
            if (ReferenceEquals(_reactiveVariable, null))
            {
                _reactiveVariable = new ReactiveVariable<DataType>(_defaultValue);
                
#if UNITY_EDITOR
                _testValue = _defaultValue;
                _reactiveVariable.Subscribe(SetValue);
#endif
            }

            return _reactiveVariable;
        }

#if UNITY_EDITOR
        private void SetValue()
        {
            _testValue = (DataType)GetReactiveVariable().Value;
        }
#endif

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (!Application.isPlaying)
                return;
            
            if (!_setDirty)
                return;
            
            GetReactiveVariable().SetValue(_testValue);
        }
    }
#endif
}