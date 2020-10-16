using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FPT_Training_System.Models;

namespace FPT_Training_System.Controllers
{
    public class TrainersController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Trainers
        public ActionResult Index()
        {
            return View(_context.Trainers.ToList());
        }

        // GET: Trainers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = _context.Trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // GET: Trainers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trainers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                _context.Trainers.Add(trainer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainer);
        }

        //GET: Trainers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var trainer = _context.Users.FirstOrDefault(p => p.Id == id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        //POST: Trainers/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ApplicationUser user)
        {
            var userInDb = _context.Users.Find(user.Id);

            if (userInDb == null)
            {
                return View(user);
            }

            if (ModelState.IsValid)
            {
                //userInDb.UserName = user.UserName;
                //userInDb.Age = user.Age;
                userInDb.Phone = user.Phone;
                userInDb.Email = user.Email;
                userInDb.UserName = user.UserName;


                _context.Users.AddOrUpdate(userInDb);
                _context.SaveChanges();

                return RedirectToAction("Index", "ManagerStaffViewModels");
            }
            return View(user);
        }

        // GET: Trainers/Delete/5

        //[HttpGet]
        //[Authorize(Roles = "Admin")]
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    var appUser = _context.Users.Find(id);
        //    if (appUser == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(appUser);
        //}

        //[HttpPost]
        //[Authorize(Roles = "Admin")]
        //public ActionResult Edit(ApplicationUser user)
        //{
        //    var userInDb = _context.Users.Find(user.Id);

        //    if (userInDb == null)
        //    {
        //        return View(user);
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        userInDb.UserName = user.UserName;
        //        userInDb.Age = user.Age;
        //        userInDb.Phone = user.Phone;
        //        userInDb.Email = user.Email;


        //        _context.Users.AddOrUpdate(userInDb);
        //        _context.SaveChanges();

        //        return RedirectToAction("UsersWithRoles");
        //    }
        //    return View(user);

        // }
        public ActionResult Delete(ApplicationUser user)
        {
            var userInDb = _context.Users.Find(user.Id);

            if (userInDb == null)
            {
                return View(user);
            }

            if (ModelState.IsValid)
            {
                userInDb.UserName = user.UserName;
                userInDb.Age = user.Age;
                userInDb.Phone = user.Phone;
                userInDb.Email = user.Email;

                _context.Users.Remove(userInDb);
                _context.SaveChanges();

                return RedirectToAction("Index", "ManagerStaffViewModels");
            }
            return View(user);
        }
    }
}
