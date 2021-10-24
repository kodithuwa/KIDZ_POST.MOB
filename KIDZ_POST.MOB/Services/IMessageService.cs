using KIDZ_POST.MOB.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KIDZ_POST.MOB.Services
{
    public interface IMessageService
    {
        Task<IEnumerable<Message>> GetAsync(int creatorId );

        Task<IEnumerable<Message>> GetUserMessagesAsync(int userId);

        Task<Message> GetMessageAsync(int messageId);

        Task<Message> CreateMessageAsync(Message message);

        Task<IEnumerable<UserMessage>> GetUserMessages(int messageId, int teacherId);

        Task<bool> CreateUserMessagesAsync(UserMessage userMessage);

        Task<bool> DeleteUserMessageAsync(int userMessageId);

        Task<int> CreateMessageLocalAsync(Message message);
    }
}
