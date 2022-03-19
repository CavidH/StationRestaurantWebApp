using System.Collections.Generic;
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
            List<string> emails = new List<string>();
            foreach (var res in reservs)
            {
                if (!emails.Contains(res.Email))
                {
                    emails.Add(res.Email);
                }
            }

            foreach (var email in emails)
            {
                EmailHelper.SendEmail(email, message.Msg, message.Subject);
            }
        }
    }
}