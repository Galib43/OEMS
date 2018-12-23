using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BLL;
using Models;
using Models.ViewModels;

namespace ExamManagementSystem.Controllers
{
    public class AccountController : Controller
    {
      
        UserAccountManager _userAccountManager=new UserAccountManager();
        [HttpGet]
        public ActionResult Index()
        {
            var registers = _userAccountManager.GetAll();
            return View(registers);


        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccountEntryVm model)
        {
            if (ModelState.IsValid)
            {
                var userAccount = Mapper.Map<UserAcount>(model);
                bool usr = _userAccountManager.Add(userAccount);
                if (usr)
                {
                   
                    ModelState.Clear();
                    ViewBag.msc = model.FirstName + " " + model.LastName + " " + "Successfully Registered";
                    //return RedirectToAction("Login");
                }
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccountEntryVm model)
        
       {

           var userAccount = Mapper.Map<UserAcount>(model);
           var usr = _userAccountManager.Login(userAccount);
                if (usr != null)
                {
                    Session["UserId"] = usr.UserId.ToString();
                    Session[" UserName"] = usr.UserName.ToString();
                    return RedirectToAction("LoggedIn");  
                }
                
                else
                {
                    ViewBag.msc = "UserName or Password is wrong";
                          
                }
            
           
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("loggedin", "Account");
        }

        //After login that time show
        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        //Register delete 
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                bool isDelete = _userAccountManager.Delete(id);
                if (isDelete)
                {
                    return RedirectToAction("Index");
                }
               
            }
            return View();
        }
        //Update Database

        public ActionResult Edit(int id)
        {
            var userAccount = new UserAcount();

            if (id > 0)
            {
                userAccount = _userAccountManager.GetById(id);

                var model = Mapper.Map<UserAccountEntryVm>(userAccount);

                return View(model);
            }

            return View();
        }


        //Update Account
        [HttpPost]
        public ActionResult Edit(UserAccountEntryVm model)
        {
            if (ModelState.IsValid)
            {
                var userAccount = Mapper.Map<UserAcount>(model);
                bool isUpdate = _userAccountManager.Update(userAccount);
                if (isUpdate)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }


       
    }
}
