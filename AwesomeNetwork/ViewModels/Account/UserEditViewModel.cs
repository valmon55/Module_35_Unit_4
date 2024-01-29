using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AwesomeNetwork.ViewModels.Account
{
    public class UserEditViewModel
    {
        public string UserId { get; set; }
        public string Image { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }            
        public DateTime BirthDate { get; set; }
        public string UserName { get; set; }
        public string Status { get; set; }
        public string About { get; set; }
    }
}
