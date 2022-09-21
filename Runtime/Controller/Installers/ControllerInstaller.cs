using Installers.Core;
using MVVM.EventBinding.InteraceAdapters;
using UnityEngine;

namespace MVVM.Controllers
{
    public abstract class ControllerInstaller : MonoInstaller<IController>
    {
        [Header("References")]
        [SerializeField] private EventBindingViewModelSO _eventBindingViewModelSO;

        protected override IController GetData()
        {
            return GetController(_eventBindingViewModelSO.GetViewModel());
        }

        protected abstract IController GetController(EventBindingViewModel eventBindingViewModel);
    }
}