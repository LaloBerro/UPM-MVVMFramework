using System;

namespace MVVM.PropertyBinding.InteraceAdapters
{
    public interface IReactiveVariable
    {
        Type VariableType { get; }
        object Value { get; }
        void SetValue(object value);
        void Subscribe(Action action);
    }
}