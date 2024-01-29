﻿using AwesomeNetwork.Models.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AwesomeNetwork.ViewModels.Account
{
    public class SearchViewModel
    {
        [Required]
        public List<User> UserList { get; set; }
    }
}
