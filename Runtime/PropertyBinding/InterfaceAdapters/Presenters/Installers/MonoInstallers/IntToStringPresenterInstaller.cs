using MVVM.PropertyBinding.InteraceAdapters;

namespace MVVM.Presenters
{
    public class IntToStringPresenterInstaller : PresenterInstaller<int>
    {
        protected override IPresenter<int> GetPresenter(PropertyBindingViewModel propertyBindingViewModel)
        {
            return new IntToStringPresenter(propertyBindingViewModel);
        }
    }
}