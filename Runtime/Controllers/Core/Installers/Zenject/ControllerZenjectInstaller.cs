using MVVM.EventBinding.InteraceAdapters;
using UnityEngine;
using Zenject;

namespace MVVM.Controllers
{
    public abstract class ControllerZenjectInstaller<UseCaseType> : MonoInstaller
    {
        [Header("References")]
        [SerializeField] private EventBindingViewModelSO _eventBindingViewModelSO;

        private IController _controller;
        private UseCaseType _useCase;

        [Inject]
        public void InjectUseCase(UseCaseType useCase)
        {
            _useCase = useCase;
        }

        public override void InstallBindings()
        {
            _controller = GetInitializedController(_useCase, _eventBindingViewModelSO.GetViewModel());

            Container.Bind<IController>().FromInstance(_controller).AsSingle();
        }

        protected abstract IController GetInitializedController(UseCaseType useCase, EventBindingViewModel eventBindingViewModel);

        private void OnDestroy()
        {
            _controller.Dispose();
        }
    }
}