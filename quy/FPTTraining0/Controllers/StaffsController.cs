using FPTTraining0.Models;
using FPTTraining0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace FPTTraining0.Controllers
{
    public class StaffsController : Controller
    {
		private ApplicationDbContext _context;
		public StaffsController()
		{
			_context = new ApplicationDbContext();
		}
		// GET: Staff
		[HttpGet]
		public ActionResult Index(string searchString)
		{
			var staffs = _context.Staffs
			.Include(p => p.Department);

			if (!String.IsNullOrEmpty(searchString))
			{
				staffs = staffs.Where(
					s => s.Name.Contains(searchString) ||
					s.Department.Name.Contains(searchString));
			}

			return View(staffs.ToList());
		}

		[HttpGet]
		[Authorize(Roles = "admin")]
		public ActionResult Create()
		{
			var viewModel = new StaffDepartmentViewModel
			{
				Departments = _context.Departments.ToList()
			};
			return View(viewModel);
		}

		[HttpPost]
		[Authorize(Roles = "admin")]
		public ActionResult Create(Staff staff)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			if (_context.Staffs.Any(p => p.Name.Contains(staff.Name)))
			{
				ModelState.AddModelError("Name", "Staff Name Already Exists.");
				return View();
			}

			var newStaff = new Staff
			{
				Name = staff.Name,
				StaffEmail = staff.StaffEmail,
				PassEmail = staff.PassEmail,
				DepartmentId = staff.DepartmentId
			};

			_context.Staffs.Add(newStaff);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		[HttpGet]
		[Authorize(Roles = "admin")]

		public ActionResult Delete(int id)
		{
			var staffInDb = _context.Staffs.SingleOrDefault(p => p.Id == id);

			if (staffInDb == null)
			{
				return HttpNotFound();
			}

			_context.Staffs.Remove(staffInDb);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		[HttpGet]
		[Authorize(Roles = "admin")]

		public ActionResult Edit(int id)
		{
			var staffInDb = _context.Staffs.SingleOrDefault(p => p.Id == id);

			if (staffInDb == null)
			{
				return HttpNotFound();
			}

			var viewModel = new StaffDepartmentViewModel
			{
				Staff = staffInDb,
				Departments = _context.Departments.ToList()
			};

			return View(viewModel);
		}

		[HttpPost]
		[Authorize(Roles = "admin")]

		public ActionResult Edit(Staff staff)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			var staffInDb = _context.Staffs.SingleOrDefault(p => p.Id == staff.Id);

			if (staffInDb == null)
			{
				return HttpNotFound();
			}

			staffInDb.Name = staff.Name;
			staffInDb.StaffEmail = staff.StaffEmail;
			staffInDb.PassEmail = staff.PassEmail;
			staffInDb.DepartmentId = staff.DepartmentId;
			_context.SaveChanges();

			return RedirectToAction("Index");
		}
	}
}