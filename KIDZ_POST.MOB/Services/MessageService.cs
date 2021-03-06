using KIDZ_POST.MOB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using System.Net;
using Newtonsoft.Json;
using KIDZ_POST.Data;
using SQLite;


namespace KIDZ_POST.MOB.Services
{
    public class MessageService : BaseService, IMessageService
    {
        private SQLiteAsyncConnection localDb;

        public MessageService()
        {
            localDb = new SQLiteAsyncConnection("");
        }

        public async Task<IEnumerable<Message>> GetAsync(int creatorId)
        {
            var client = new RestSharp.RestClient(baseUrl);
            var request = new RestSharp.RestRequest($"api/message/?creatorid={creatorId}", Method.GET);
            var response = await client.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var messages = JsonConvert.DeserializeObject<IEnumerable<Message>>(response.Content);
                return messages;
            }
            return default;
        }

        public async Task<Message> GetMessageAsync(int messageId)
        {
            var client = new RestSharp.RestClient(baseUrl);
            var request = new RestSharp.RestRequest($"api/message/{messageId}", Method.GET);
            var response = await client.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var message = JsonConvert.DeserializeObject<Message>(response.Content);
                return message;
            }
            return default;
        }

        public async Task<Message> CreateMessageAsync(Message message)
        {
            var client = new RestSharp.RestClient(baseUrl);
            var request = new RestSharp.RestRequest($"api/message", Method.POST);
            request.AddJsonBody(message);
            var response = await client.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.Created)
            {
                var result = JsonConvert.DeserializeObject<Message>(response.Content);
                return result;
            }
            return default;
        }

        public async Task<IEnumerable<Message>> GetUserMessagesAsync(int userId)
        {
            var client = new RestSharp.RestClient(baseUrl);
            var request = new RestSharp.RestRequest($"api/message/getusermessages/{userId}", Method.GET);
            var response = await client.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var messages = JsonConvert.DeserializeObject<IEnumerable<Message>>(response.Content);
                return messages;
            }
            return default;
        }

        public async Task<bool> CreateUserMessagesAsync(UserMessage userMessage)
        {
            if(userMessage == null)
            {
                return default;
            }

            var userMessages = new List<UserMessage> { userMessage };
            var client = new RestSharp.RestClient(baseUrl);
            var request = new RestSharp.RestRequest($"api/message/saveusermessages", Method.GET);
            request.AddJsonBody(userMessages);
            var response = await client.ExecuteAsync(request);
            var result = (response.StatusCode == HttpStatusCode.OK);
            return result;
        }

        public async Task<IEnumerable<UserMessage>> GetUserMessages(int messageId, int teacherId)
        {
            var client = new RestSharp.RestClient(baseUrl);
            var request = new RestSharp.RestRequest($"api/message/getusermessages/{teacherId}/{messageId}", Method.GET);
            var response = await client.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var usermessages = JsonConvert.DeserializeObject<IEnumerable<UserMessage>>(response.Content);
                return usermessages;
            }

            return default;
        }

        public async Task<bool> DeleteUserMessageAsync(int userMessageId)
        {
            if (userMessageId <= 0)
            {
                return false;
            }

            var client = new RestSharp.RestClient(baseUrl);
            var request = new RestSharp.RestRequest($"api/message/deleteusermessage", Method.DELETE);
            var response = await client.ExecuteAsync(request);
            var result = response.StatusCode == HttpStatusCode.OK;
            return result;
        }

        public async Task<int> CreateMessageLocalAsync(Message message)
        {
            var count = await localDb.InsertAsync(message);
            return count;
        }



    }
}