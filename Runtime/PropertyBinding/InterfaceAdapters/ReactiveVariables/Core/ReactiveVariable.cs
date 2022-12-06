using System;
using UniRx;

namespace MVVM.PropertyBinding.InteraceAdapters
{
    public class ReactiveVariable<DataType> : IReactiveVariable
    {
        private readonly Subject<DataType> _subject;
        private DataType _value;

        public Type VariableType => typeof(DataType);
        public object Value => _value;

        public ReactiveVariable(DataType defaultValue = default)
        {
            _subject = new Subject<DataType>();
        }

        public void SetValue(object value)
        {
            _subject.OnNext((DataType)value);
        }

        public IDisposable Subscribe(Action action)
        {
            IDisposable disposable = _subject.Subscribe(value =>
                                                                        {
                                                                            _value = value;
                                                                            action?.Invoke();
                                                                        });

            return disposable;
        }
    }
}