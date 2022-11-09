using UnityEngine;
using Zenject;
using ZenjectExtensions.Zinstallers;

namespace MVVM.PropertyBinding.InteraceAdapters
{
    public abstract class PropertyBindingControllerZinstaller<DataType, UseCaseType> : InstanceZinstaller<PropertyBindingController<DataType, UseCaseType>>
    {
        [Header("References")]
        [SerializeField] private ReactiveVariableTypeSO<DataType> _reactiveVariable;

        private UseCaseType _useCase;

        [Inject]
        protected void InjectDependencies(UseCaseType useCase)
        {
            _useCase = useCase;
        }

        protected override PropertyBindingController<DataType, UseCaseType> GetInitializedClass()
        {
            return GetController(_reactiveVariable.GetReactiveVariable(), _useCase);
        }

        protected abstract PropertyBindingController<DataType, UseCaseType> GetController(IReactiveVariable reactiveVariable, UseCaseType useCase);
    }
}