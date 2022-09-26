using MVVM.EventBinding.InteraceAdapters;
using UnityEngine;
using Zenject;

namespace MVVM.Controllers
{
    public abstract class ControllerZenjectInstaller<UseCaseType> : MonoInstaller
    {
        [Header("References")]
        [SerializeField] private EventBindingViewModelSO _eventBindingViewModelSO;

        private UseCaseType _useCase;

        [Inject]
        public void InjectUseCase(UseCaseType useCase)
        {
            _useCase = useCase;

        }

        protected abstract void InitializeController(UseCaseType useCase, EventBindingViewModel eventBindingViewModel);

        public override void InstallBindings()
        {
            InitializeController(_useCase, _eventBindingViewModelSO.GetViewModel());
        }
    }
}