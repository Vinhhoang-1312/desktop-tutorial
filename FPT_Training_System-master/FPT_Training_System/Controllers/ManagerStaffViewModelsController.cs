using FPT_Training_System.Models;
using FPT_Training_System.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPT_Training_System.Controllers
{
    public class ManagerStaffViewModelsController : Controller
    {
        ApplicationDbContext _context;
        public ManagerStaffViewModelsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: ManagerStaffViewModels
        public ActionResult Index()
        {
            var role = (from r in _context.Roles where r.Name.Contains("Trainee") select r).FirstOrDefault();
            var users = _context.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(role.Id)).ToList();

            var userVM = users.Select(user => new ManagerStaffViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
                RoleName = "Trainee",
                UserId = user.Id
            }).ToList();


            var role2 = (from r in _context.Roles where r.Name.Contains("Trainer") select r).FirstOrDefault();
            var admins = _context.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(role2.Id)).ToList();

            var adminVM = admins.Select(user => new ManagerStaffViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
                RoleName = "Trainer",
                UserId = user.Id
            }).ToList();


            var model = new ManagerStaffViewModel { Trainee = userVM, Trainer = adminVM };
            return View(model);
        }


        //[HttpGet]
        //[Authorize(Roles = "TrainingStaff")]
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    var staffView = _context.Users.Find(id);
        //    if (staffView == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(staffView);
        //}

        //[HttpPost]
        //[Authorize(Roles = "TrainingStaff")]
        //public ActionResult Edit(ManagerStaffViewModel managerStaffViewModel)
        //{
        //    var employeeInDb = _context.Users.Find(managerStaffViewModel.Id);

        //    if (employeeInDb == null)
        //    {
        //        return View(managerStaffViewModel);
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        employeeInDb.UserName = managerStaffViewModel.UserName;
        //        //employeeInDb.Age = user.Age;
        //        //employeeInDb.Phone = user.Phone;
        //        employeeInDb.Email = managerStaffViewModel.Email;


        //        _context.Users.AddOrUpdate(employeeInDb);
        //        _context.SaveChanges();

        //        return RedirectToAction("Index");
        //    }
        //    return View(managerStaffViewModel);

        //}

        //[Authorize(Roles = "TrainingStaff")]
        //public ActionResult Delete(ApplicationUser user)
        //{
        //    var employeeInDb = _context.Users.Find(user.Id);

        //    if (employeeInDb == null)
        //    {
        //        return View(user);
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        employeeInDb.UserName = user.UserName;
        //        employeeInDb.Age = user.Age;
        //        employeeInDb.Phone = user.Phone;
        //        employeeInDb.Email = user.Email;

        //        _context.Users.Remove(employeeInDb);
        //        _context.SaveChanges();

        //        return RedirectToAction("Index");
        //    }
        //    return View(user);
        //}
    }
}