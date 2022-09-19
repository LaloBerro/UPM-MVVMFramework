using System;

namespace MVVM.OneWay.InteraceAdapters
{
    public interface IReactiveVariable
    {
        Type VariableType { get; }
        object Value { get; }
        void SetValue(object value);
        void Subscribe(Action action);
    }
}