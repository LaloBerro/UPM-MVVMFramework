using Commands.Core;
using MVVM.EventBinding.InteraceAdapters;

namespace MVVM.Controllers
{
    public class CommandControllerZinstaller : ControllerZenjectInstaller<ICommand>
    {
        protected override void InitializeController(ICommand command, EventBindingViewModel eventBindingViewModel)
        {
            IController controller = new CommandController(eventBindingViewModel, command);

            Container.Bind<IController>().FromInstance(controller).AsSingle();
        }
    }
}