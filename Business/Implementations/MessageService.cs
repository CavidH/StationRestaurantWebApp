using System.Threading.Tasks;
using Business.Interfaces;
using Business.Utilities.Helpers;
using Business.ViewModels.Message;
using Core;

namespace Business.Implementations
{
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MessageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task SendMessage(MessageVM message)
        {
            var reservs = await _unitOfWork
                .reservationRepository
                .GetAllAsync();
            foreach (var res in reservs)
            {
                EmailHelper.SendEmail(res.Email, message.Msg, message.Subject);
            }
        }
    }
}