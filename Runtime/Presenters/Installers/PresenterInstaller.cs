using Installers.Core;
using MVVM.PropertyBinding.InteraceAdapters;
using UnityEngine;

namespace MVVM.Presenters
{
    public abstract class PresenterInstaller<DataToFormatType> : MonoInstaller<IPresenter<DataToFormatType>>
    {
        [Header("References")]
        [SerializeField] private PropertyBindingViewModelSO _propertyBindingViewModelSO;

        protected override IPresenter<DataToFormatType> GetData()
        {
            return GetPresenter(_propertyBindingViewModelSO.GetViewModel());
        }

        protected abstract IPresenter<DataToFormatType> GetPresenter(PropertyBindingViewModel propertyBindingViewModel);
    }
}