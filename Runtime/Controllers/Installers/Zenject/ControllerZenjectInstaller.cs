using MVVM.EventBinding.InteraceAdapters;
using UnityEngine;
using Zenject;

namespace MVVM.Controllers
{
    public abstract class ControllerZenjectInstaller<UseCaseType> : MonoInstaller
    {
        [Header("References")]
        [SerializeField] private EventBindingViewModelSO _eventBindingViewModelSO;

        [Inject]
        public void InjectUseCase(UseCaseType useCase)
        {
            InitializeController(useCase, _eventBindingViewModelSO.GetViewModel());
        }

        protected abstract void InitializeController(UseCaseType useCase, EventBindingViewModel eventBindingViewModel);

        public override void InstallBindings()
        {

        }
    }
}