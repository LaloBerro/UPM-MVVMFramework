using System;
using UniRx;

namespace MVVM.PropertyBinding.InteraceAdapters
{
    public class ReactiveVariable<DataType> : IReactiveVariable
    {
        private readonly ReactiveProperty<DataType> _reactiveProperty;
        private DataType _value;

        public Type VariableType => typeof(DataType);
        public object Value => _value;

        public ReactiveVariable(DataType defaultValue = default)
        {
            _reactiveProperty = new ReactiveProperty<DataType>(defaultValue);
        }

        public void SetValue(object value)
        {
            _reactiveProperty.Value = (DataType)value;
        }

        public void Subscribe(Action action)
        {
            _reactiveProperty.Subscribe(value =>
            {
                _value = value;
                action?.Invoke();
            });
        }
    }
}