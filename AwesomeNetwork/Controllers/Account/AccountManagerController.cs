using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AwesomeNetwork.Data.Repository;
using AwesomeNetwork.Data.UoW;
using AwesomeNetwork.Extentions;
using AwesomeNetwork.Models.Users;
using AwesomeNetwork.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeNetwork.Controllers.Account
{
    public class AccountManagerController : Controller
    {
        private IMapper _mapper;

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountManagerController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }


        //[Route("Login")]
        //[HttpGet]
        //public IActionResult Login()
        //{
        //    return View("Home/Login");
        //}

        //[HttpGet]
        //public IActionResult Login(string returnUrl = null)
        //{
        //    return View(new LoginViewModel { ReturnUrl = returnUrl });
        //}

        [Route("Login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                  
                var user = _mapper.Map<User>(model);

                IdentityUser signedUser = _userManager.FindByEmailAsync(model.Email).Result;
                var result = await _signInManager.PasswordSignInAsync(signedUser.UserName, model.Password, model.RememberMe,false);
                //var result = await _signInManager.PasswordSignInAsync(user.Email, model.Password, model.RememberMe, false);

                Console.WriteLine(result);
                if (result.Succeeded)
                {
                    return RedirectToAction("MyPage", "AccountManager");
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
             return //View("Views/Home/Index.cshtml");
                RedirectToAction("Index", "Home");
        }

        [Route("Home/Index")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            Console.WriteLine($"Log out");
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [Route("MyPage")]
        [HttpGet]
        public IActionResult MyPage()
        {
            var user = User;
            var result = _userManager.GetUserAsync(user);

            return View("MyPage", new UserViewModel(result.Result));
        }

        [Authorize]
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update(UserEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                user.Convert(model);

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("MyPage", "AccountManager");
                }
                else
                {
                    return RedirectToAction("Edit", "AccountManager");
                }
            }
            else
            {
                ModelState.AddModelError("", "Некорректные данные");
                return View("Edit", model);
            }
        }
        [HttpGet]
        [Route("UserList")]
        public IActionResult UserList()
        {
            var model = new SearchViewModel
            {
                UserList = _userManager.Users.ToList()
            };
            return View("UserList", model);
        }

        [Route("UserList")]
        [HttpGet]
        public IActionResult UserList(string search)
        {
            var model = new SearchViewModel
            {
                UserList = _userManager.Users.AsEnumerable().Where(x => x.GetFullName().Contains(search)).ToList()
            };
            return View("UserList", model);
        }

    }
}
