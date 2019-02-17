namespace StudentRegistrationSystem.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Models;
	using System.Linq;

	[Route("student")]
	public class StudentController : Controller
	{
		private DataContext db = new DataContext();
		[Route("")]
		[Route("index")]
		[Route("~/")]
		public IActionResult Index()
		{
			ViewBag.students = db.Student.ToList();
			return View();
		}

		[HttpGet]
		[Route("Add")]
		public IActionResult Add()
		{
			return View("Add", new StudentViewModel());
		}


		[HttpPost]
		[Route("Add")]
		public IActionResult Add(StudentViewModel student)
		{
			db.Student.Add(student);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		[Route("delete/{id}")]
		public IActionResult Delete(string id)
		{
			db.Remove(db.Student.Find(id));
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		[Route("Edit/{id}")]
		public IActionResult Edit(string id)
		{
			return View("Edit", db.Student.Find(id));
		}

		[HttpPost]
		[Route("Edit/{id?}")]
		public IActionResult Edit(StudentViewModel student)
		{
			db.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}