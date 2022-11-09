using MVVM.PropertyBinding.InteraceAdapters;

namespace MVVM.Presenters
{
    public abstract class Presenter<DataToFormatType, ReactivePropertyType> : IPresenter<DataToFormatType>
    {
        private readonly PropertyBindingViewModel _propertyBindingViewModel;
        private readonly IReactiveVariable _reactiveVariable;

        public Presenter(PropertyBindingViewModel propertyBindingViewModel)
        {
            _propertyBindingViewModel = propertyBindingViewModel;
            _reactiveVariable = _propertyBindingViewModel.GetReactiveVariableByType(typeof(ReactivePropertyType));

            if (ReferenceEquals(_reactiveVariable, null))
                throw new System.Exception("Presenter Error: there isn't a ReactiveVariable of type " + typeof(ReactivePropertyType));
        }

        public void SetValue(DataToFormatType dataToFormatType)
        {
            ReactivePropertyType reactivePropertyType = GetFormatedData(dataToFormatType);
            _reactiveVariable.SetValue(reactivePropertyType);
        }

        protected abstract ReactivePropertyType GetFormatedData(DataToFormatType dataToFormatType);
    }
}