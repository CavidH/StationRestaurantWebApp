using System.Threading.Tasks;
using Business.ViewModels.Message;

namespace Business.Interfaces
{
    public interface IMessageService
    {
        Task SendMessage(MessageVM messageVm);
    }
}