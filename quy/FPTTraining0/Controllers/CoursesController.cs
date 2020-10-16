using FPTTraining0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPTTraining0.Controllers
{
    public class CoursesController : Controller
    {
		private ApplicationDbContext _context;
		public CoursesController()
		{
			_context = new ApplicationDbContext();
		}
		// GET: Course
		[HttpGet]
		public ActionResult Index()
		{
			var courses = _context.Courses.ToList();
			return View(courses);
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Course course)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			if (_context.Courses.Any(p => p.Name.Contains(course.Name)))
			{
				ModelState.AddModelError("Name", "Course Name Already Exists.");
				return View();
			}

			var newCourse = new Course
			{
				Name = course.Name,

			};

			_context.Courses.Add(newCourse);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			var courseInDb = _context.Courses.SingleOrDefault(p => p.Id == id);

			if (courseInDb == null)
			{
				return HttpNotFound();
			}

			_context.Courses.Remove(courseInDb);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			var courseInDb = _context.Courses.SingleOrDefault(p => p.Id == id);

			if (courseInDb == null)
			{
				return HttpNotFound();
			}

			return View(courseInDb);
		}

		[HttpPost]
		public ActionResult Edit(Course course)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			var courseInDb = _context.Courses.SingleOrDefault(p => p.Id == course.Id);

			if (courseInDb == null)
			{
				return HttpNotFound();
			}

			courseInDb.Name = course.Name;
			_context.SaveChanges();

			return RedirectToAction("Index");
		}
	}
}