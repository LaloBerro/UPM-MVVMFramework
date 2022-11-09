using MVVM.PropertyBinding.InteraceAdapters;
using UnityEngine;
using Zenject;

namespace MVVM.Presenters
{
    public abstract class PresenterZenjectInstaller<DataType> : MonoInstaller
    {
        [Header("References")]
        [SerializeField] private PropertyBindingViewModelSO _propertyBindingViewModelSO;

        public override void InstallBindings()
        {
            IPresenter<DataType> presenter = GetPresenter(_propertyBindingViewModelSO.GetViewModel());
            Container.Bind<IPresenter<DataType>>().FromInstance(presenter).AsSingle();
        }

        protected abstract IPresenter<DataType> GetPresenter(PropertyBindingViewModel propertyBindingViewModel);
    }
}