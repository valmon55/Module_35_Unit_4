using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace AwesomeNetwork.ViewModels.Account
{
    public class UserEditViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "ID", Prompt = "ID пользователя")]
        public string UserId { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Фото", Prompt = "URL фотографии")]
        public string Image { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Фамилия", Prompt = "Укажите свою фамилию")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Отчество", Prompt = "Укажите своё отчество")]
        public string MiddleName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Имя", Prompt = "Укажите своё имя")]
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Email", Prompt = "Укажите свой Email")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Дата рождения", Prompt = "Укажите вашу дату рождения")]
        public DateTime BirthDate { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Nick Name", Prompt = "Укажите имя пользователя")]
        public string UserName => Email;
        [DataType(DataType.Text)]
        [Display(Name = "Статус", Prompt = "Введите свой статус")]
        public string Status { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "О себе", Prompt = "Введите данные о себе")]
        public string About { get; set; }
    }
}
