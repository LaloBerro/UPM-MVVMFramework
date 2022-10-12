using System;
namespace MVVM.Controllers
{
    public interface IController : IDisposable
    {
        void Execute();
    }
}