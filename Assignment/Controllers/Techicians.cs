using Assignment.Models;
using Assignment.TechiciansServices;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    public class Techicians : Controller
    {
        public IActionResult Index()
        {
            TechiciansDAO techicians = new TechiciansDAO();
            return View(techicians.GetallTechicians());
           
        }
        public IActionResult ShowDetails(int id)
        {

            TechiciansDAO techician = new TechiciansDAO();

            TechniciansModel foundtechician = techician.GetTechiciansById(id);
            return View(foundtechician);
        }
        public IActionResult Edit(int id)
        {

            TechiciansDAO technician = new TechiciansDAO();
            TechniciansModel foundtechnicians = technician.GetTechiciansById(id);
            return View("Edit", foundtechnicians);
        }
        public IActionResult ProcessEdit(TechniciansModel technician)
        {

            TechiciansDAO technicians = new TechiciansDAO();
            technicians.Update(technician);
            return View("Index", technicians.GetallTechicians());
        }
        public IActionResult SearchResult(string searchTerm)
        {
            TechiciansDAO techicians = new TechiciansDAO();
            List<TechniciansModel> techiciansList = techicians.SearchTechicians(searchTerm);
            return View("index", techiciansList);
        }
        public IActionResult SearchForm()
        {
            return View();
        }
        public IActionResult Delete(int id)
        {

            TechiciansDAO techicians = new TechiciansDAO();
            TechniciansModel techician = techicians.GetTechiciansById(id);
            techicians.Delete(techician);
            return View("Index", techicians.GetallTechicians());
        }
        public IActionResult InputForm()
        {
            return View("InputForm");
        }
        public IActionResult ProcessCreate(TechniciansModel technician)
        {

            TechiciansDAO technicians = new TechiciansDAO();
            technicians.Insert(technician);
            return View("Index", technicians.GetallTechicians());
        }



    }
}
