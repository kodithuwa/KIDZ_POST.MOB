using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KIDZ_POST.MOB.Services
{
    public interface IRemoteService
    {
        Task<bool> Login(string userName, string password);
    }
}
