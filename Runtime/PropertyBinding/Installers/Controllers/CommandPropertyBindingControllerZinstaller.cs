using Commands.Core;

namespace MVVM.PropertyBinding.InteraceAdapters
{
    public class CommandPropertyBindingControllerZinstaller<DataType> : PropertyBindingControllerZinstaller<DataType, ICommand<DataType>>
    {
        protected override PropertyBindingController<DataType, ICommand<DataType>> GetController(IReactiveVariable reactiveVariable, ICommand<DataType> useCase)
        {
            return new CommandPropertyBindingController<DataType>(reactiveVariable, useCase);
        }
    }
}