using Commands.Core;
using MVVM.EventBinding.InteraceAdapters;

namespace MVVM.Controllers
{
    public class CommandControllerZinstaller : ControllerZenjectInstaller<ICommand>
    {
        protected override IController GetInitializedController(ICommand command, EventBindingViewModel eventBindingViewModel)
        {
            IController controller = new CommandController(eventBindingViewModel, command);

            return controller;
        }
    }
}