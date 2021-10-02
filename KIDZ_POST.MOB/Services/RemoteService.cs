using KIDZ_POST.MOB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using System.Net;

namespace KIDZ_POST.MOB.Services
{
    public class RemoteService : IRemoteService
    {
        string baseUrl = "https://kidzpost.azurewebsites.net/";

        public async Task<bool> Login(string userName, string password)
        {
            var client = new RestSharp.RestClient(baseUrl);
            var request = new RestSharp.RestRequest($"api/user/login/?username={userName}&password={password}", Method.GET);
            var response = await client.ExecuteAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return false;
            }

            return true;
        }
    }
}