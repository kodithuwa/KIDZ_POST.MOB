using KIDZ_POST.MOB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using System.Net;
using Newtonsoft.Json;

namespace KIDZ_POST.MOB.Services
{
    public class RemoteService : BaseService, IRemoteService
    {
        public async Task<User> LoginAsync(string userName, string password)
        {
            var client = new RestSharp.RestClient(baseUrl);
            var request = new RestSharp.RestRequest($"api/user/login/?username={userName}&password={password}", Method.GET);
            var response = await client.ExecuteAsync(request);

            if (response.StatusCode == HttpStatusCode.OK && !string.IsNullOrWhiteSpace(response.Content))
            {
                var user = JsonConvert.DeserializeObject<User>(response.Content);
                return user;
            }

            return default;
        }


        public async Task<Parent> GetParentAsync(int userId)
        {
            var client = new RestSharp.RestClient(baseUrl);
            var request = new RestSharp.RestRequest($"api/user/{userId}", Method.GET);
            var response = await client.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var user = JsonConvert.DeserializeObject<Parent>(response.Content);
                return user;
            }
            return default;
        }

        public async Task<IEnumerable<Parent>> GetParentsAsync(int teacherId)
        {
            var client = new RestSharp.RestClient(baseUrl);
            var request = new RestSharp.RestRequest($"api/user/getall/{teacherId}", Method.GET);
            var response = await client.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var users = JsonConvert.DeserializeObject<IEnumerable<User>>(response.Content);
                var parents = users.Select(x => new Parent
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Description = x.Description,
                    IsActivated = x.IsActivated,
                    IsTeacher = x.IsTeacher,
                });
                return parents;
            }
            return default;
        }

        public async Task<Parent> CreateParentAsync(Parent parent)
        {
            var client = new RestSharp.RestClient(baseUrl);
            var request = new RestSharp.RestRequest($"api/user/register", Method.POST);
            request.AddJsonBody(parent);
            var response = await client.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.Created)
            {
                var result = JsonConvert.DeserializeObject<Parent>(response.Content);
                return result;
            }
            return default;
        }
    }
}