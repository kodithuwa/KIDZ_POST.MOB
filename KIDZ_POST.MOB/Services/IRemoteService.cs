using KIDZ_POST.MOB.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KIDZ_POST.MOB.Services
{
    public interface IRemoteService
    {
        Task<User> LoginAsync(string userName, string password);

        Task<Parent> GetParentAsync(int userId);

        Task<IEnumerable<Parent>> GetParentsAsync(int teacherId);

        Task<Parent> CreateParentAsync(Parent parent);
    }
}
