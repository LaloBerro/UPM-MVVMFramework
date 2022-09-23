using MVVM.Presenters;
using Zenject;

namespace MVVM.Domains
{
    public abstract class UsecaseWithPresenterZenjectInstaller<PresenterType, UseCaseType> : MonoInstaller
    {
        private UseCaseType _useCase;

        [Inject]
        private void InjectPresenter(IPresenter<PresenterType> presenter)
        {
            _useCase = GetUseCase(presenter);
        }

        protected abstract UseCaseType GetUseCase(IPresenter<PresenterType> presenter);

        public override void InstallBindings()
        {
            Container.Bind<UseCaseType>().FromInstance(_useCase).AsSingle();
        }
    }
}