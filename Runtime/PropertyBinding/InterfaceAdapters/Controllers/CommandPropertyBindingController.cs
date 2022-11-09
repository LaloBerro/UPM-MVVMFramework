using Commands.Core;

namespace MVVM.PropertyBinding.InteraceAdapters
{
    public class CommandPropertyBindingController<DataType> : PropertyBindingController<DataType, ICommand<DataType>>
    {
        public CommandPropertyBindingController(IReactiveVariable reactiveVariable, ICommand<DataType> command) : base(reactiveVariable, command) { }

        protected override void Execute(ICommand<DataType> command, DataType data)
        {
            command.Execute(data);
        }
    }
}