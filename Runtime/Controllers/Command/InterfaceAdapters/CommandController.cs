using Commands.Core;
using MVVM.EventBinding.InteraceAdapters;

namespace MVVM.Controllers
{
    public class CommandController : Controller
    {
        private readonly ICommand _command;

        public CommandController(EventBindingViewModel eventBindingViewModel, ICommand command) : base(eventBindingViewModel)
        {
            _command = command;
        }

        public override void Execute()
        {
            _command.Execute();
        }
    }
}