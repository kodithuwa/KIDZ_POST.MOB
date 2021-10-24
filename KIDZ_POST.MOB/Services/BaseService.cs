using KIDZ_POST.MOB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using System.Net;
using KIDZ_POST.Data;

namespace KIDZ_POST.MOB.Services
{
    public class BaseService
    {
        protected string baseUrl = "https://kidzpost.azurewebsites.net/";
    }
}