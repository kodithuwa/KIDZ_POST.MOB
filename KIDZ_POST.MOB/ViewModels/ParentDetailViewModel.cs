using KIDZ_POST.MOB.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KIDZ_POST.MOB.ViewModels
{
    [QueryProperty(nameof(ParentId), nameof(ParentId))]
    public class ParentDetailViewModel : BaseViewModel
    {
        private string parentId;
        private string firstName;
        private string lastName;
        private string description;
        public int Id { get; set; }

        public string FirstName
        {
            get => firstName;
            set => SetProperty(ref firstName, value);
        }

        public string LastName
        {
            get => lastName;
            set => SetProperty(ref lastName, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string ParentId
        {
            get
            {
                return parentId;
            }
            set
            {
                parentId = value;
                LoadParentId(value);
            }
        }

        public async void LoadParentId(string parentId)
        {
            try
            {
                var pId = Convert.ToInt32(parentId);
                var item = await this.remoteService.GetParentAsync(pId);
                Id = item.Id;
                FirstName = item.FirstName;
                LastName = item.LastName;
                Description = item.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
