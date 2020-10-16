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
    public class TrainersController : Controller
    {
		private ApplicationDbContext _context;
		public TrainersController()
		{
			_context = new ApplicationDbContext();
		}
		// GET: Trainer
		[HttpGet]
		public ActionResult Index(string searchString)
		{
			var trainers = _context.Trainers
			.Include(p => p.Major);

			if (!String.IsNullOrEmpty(searchString))
			{
				trainers = trainers.Where(
					s => s.Name.Contains(searchString) ||
					s.Major.Name.Contains(searchString));
			}

			return View(trainers.ToList());
		}

		[HttpGet]
		[Authorize(Roles = "admin")]
		public ActionResult Create()
		{
			var viewModel = new TrainerMajorViewModel
			{
				Majors = _context.Majors.ToList()
			};
			return View(viewModel);
		}

		[HttpPost]
		[Authorize(Roles = "admin")]
		public ActionResult Create(Trainer trainer)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			if (_context.Trainers.Any(p => p.Name.Contains(trainer.Name)))
			{
				ModelState.AddModelError("Name", "Trainer Name Already Exists.");
				return View();
			}

			var newTrainer = new Trainer
			{
				Name = trainer.Name,
				TrainerEmail = trainer.TrainerEmail,
				PassEmail = trainer.PassEmail,
				MajorId = trainer.MajorId
			};

			_context.Trainers.Add(newTrainer);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		[HttpGet]
		[Authorize(Roles = "admin")]

		public ActionResult Delete(int id)
		{
			var trainerInDb = _context.Trainers.SingleOrDefault(p => p.Id == id);

			if (trainerInDb == null)
			{
				return HttpNotFound();
			}

			_context.Trainers.Remove(trainerInDb);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		[HttpGet]
		[Authorize(Roles = "admin")]

		public ActionResult Edit(int id)
		{
			var trainerInDb = _context.Trainers.SingleOrDefault(p => p.Id == id);

			if (trainerInDb == null)
			{
				return HttpNotFound();
			}

			var viewModel = new TrainerMajorViewModel
			{
				Trainer = trainerInDb,
				Majors = _context.Majors.ToList()
			};

			return View(viewModel);
		}

		[HttpPost]
		[Authorize(Roles = "admin")]

		public ActionResult Edit(Trainer trainer)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			var trainerInDb = _context.Trainers.SingleOrDefault(p => p.Id == trainer.Id);

			if (trainerInDb == null)
			{
				return HttpNotFound();
			}

			trainerInDb.Name = trainer.Name;
			trainerInDb.TrainerEmail = trainer.TrainerEmail;
			trainerInDb.PassEmail = trainer.PassEmail;
			trainerInDb.MajorId = trainer.MajorId;
			_context.SaveChanges();

			return RedirectToAction("Index");
		}
	}
}