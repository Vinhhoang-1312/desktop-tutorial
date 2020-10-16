using FPTTraining0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using FPTTraining0.ViewModels;

namespace FPTTraining0.Controllers
{
    public class TraineesController : Controller
    {
		private ApplicationDbContext _context;
		public TraineesController()
		{
			_context = new ApplicationDbContext();
		}
		// GET: Trainee
		[HttpGet]
		public ActionResult Index(string searchString)
		{
			var trainees = _context.Trainees
			.Include(p => p.Course);

			if (!String.IsNullOrEmpty(searchString))
			{
				trainees = trainees.Where(
					s => s.Name.Contains(searchString) ||
					s.Course.Name.Contains(searchString));
			}

			return View(trainees.ToList());
		}

		[HttpGet]
		[Authorize(Roles = "staff")]
		public ActionResult Create()
		{
			var viewModel = new TraineeCourseViewModel
			{
				Courses = _context.Courses.ToList()
			};
			return View(viewModel);
		}

		[HttpPost]
		[Authorize(Roles = "staff")]
		public ActionResult Create(Trainee trainee)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			if (_context.Trainees.Any(p => p.Name.Contains(trainee.Name)))
			{
				ModelState.AddModelError("Name", "Trainee Name Already Exists.");
				return View();
			}

			var newTrainee = new Trainee
			{
				Name = trainee.Name,
				TraineeEmail = trainee.TraineeEmail,
				PassEmail = trainee.PassEmail,
				Birth = trainee.Birth,
				CourseId = trainee.CourseId
			};

			_context.Trainees.Add(newTrainee);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		[HttpGet]
		[Authorize(Roles = "staff")]

		public ActionResult Delete(int id)
		{
			var traineeInDb = _context.Trainees.SingleOrDefault(p => p.Id == id);

			if (traineeInDb == null)
			{
				return HttpNotFound();
			}

			_context.Trainees.Remove(traineeInDb);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		[HttpGet]
		[Authorize(Roles = "staff")]

		public ActionResult Edit(int id)
		{
			var traineeInDb = _context.Trainees.SingleOrDefault(p => p.Id == id);

			if (traineeInDb == null)
			{
				return HttpNotFound();
			}

			var viewModel = new TraineeCourseViewModel
			{
				Trainee = traineeInDb,
				Courses = _context.Courses.ToList()
			};

			return View(viewModel);
		}

		[HttpPost]
		[Authorize(Roles = "staff")]

		public ActionResult Edit(Trainee trainee)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			var traineeInDb = _context.Trainees.SingleOrDefault(p => p.Id == trainee.Id);

			if (traineeInDb == null)
			{
				return HttpNotFound();
			}

			traineeInDb.Name = trainee.Name;
			traineeInDb.TraineeEmail = trainee.TraineeEmail;
			traineeInDb.PassEmail = trainee.PassEmail;
			traineeInDb.Birth = trainee.Birth;
			traineeInDb.CourseId = trainee.CourseId;
			_context.SaveChanges();

			return RedirectToAction("Index");
		}
	}
}