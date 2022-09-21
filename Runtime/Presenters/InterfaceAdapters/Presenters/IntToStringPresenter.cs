using MVVM.PropertyBinding.InteraceAdapters;

namespace MVVM.Presenters
{
    public class IntToStringPresenter : Presenter<int, string>
    {
        public IntToStringPresenter(PropertyBindingViewModel propertyBindingViewModel) : base(propertyBindingViewModel) { }

        protected override string GetFormatedData(int dataToFormatType)
        {
            return dataToFormatType.ToString();
        }
    }
}