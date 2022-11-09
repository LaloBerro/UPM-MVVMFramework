using System;

namespace MVVM.PropertyBinding.InteraceAdapters
{
    public abstract class PropertyBindingController<DataType, UseCaseType> : IDisposable
    {
        private readonly IReactiveVariable _reactiveVariable;
        private readonly UseCaseType _useCase;

        private readonly IDisposable _disposable;

        public PropertyBindingController(IReactiveVariable reactiveVariable, UseCaseType useCase)
        {
            _reactiveVariable = reactiveVariable;
            _useCase = useCase;

            _disposable = _reactiveVariable.Subscribe(ReactToVariable);
        }

        private void ReactToVariable()
        {
            if (_reactiveVariable.VariableType != typeof(DataType))
                throw new System.Exception($"The Reactive Variable type ({_reactiveVariable.VariableType}) is different to the expected on the controller ({typeof(DataType)}).");

            DataType data = (DataType)_reactiveVariable.Value;

            Execute(_useCase, data);
        }

        protected abstract void Execute(UseCaseType useCase, DataType data);

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}