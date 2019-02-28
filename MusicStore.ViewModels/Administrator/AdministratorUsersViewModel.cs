using System.Collections;
using System.Collections.Generic;
using MusicStore.Models;

namespace MusicStore.ViewModels.Administrator
{
    public class AdministratorUsersViewModel
    {
        public AdministratorUsersViewModel()
        {
            this.Users = new List<MusicStoreUser>();
        }

        public ICollection<MusicStoreUser> Users  { get; set; }
    }
}