using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NaturalRemediesForAilments;
using NaturalRemediesForAilments.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NaturalRemediesForAilments.Controllers
{
    public class AilmentController : Controller
    {
        private readonly IAilmentRepository repo;

        //Constructor
        public AilmentController(IAilmentRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult DeleteProduct(Ailment ailment)
        {
            repo.DeleteAilment(ailment);
            return RedirectToAction("Index");
        }



        // GET: /<controller>/
        public IActionResult Index()
        {
            var ailments = repo.GetAllAilments();
            return View(ailments);
        }
    


        public IActionResult InsertAilments()
        {
            var ailments = repo;
            return View(ailments);
        }

        public IActionResult InsertAilmentsToDatabase(Ailment ailmentsToInsert)
        {
            repo.InsertAilment(ailmentsToInsert);
            return RedirectToAction("Index");
        }


        public IActionResult ViewAilments(int id)
        {
            var ailments= repo.GetAilment(id);
            return View(ailments);
        }

        public IActionResult UpdateAilments(int id)
        {
            Ailment ailments = repo.GetAilment(id);
            if (ailments == null)
            {
                return View("AilmentsNotFound");
            }
            return View(ailments);
        }

        public IActionResult UpdateAilmentsToDatabase(Ailment ailments)
        {
            repo.UpdateAilment(ailments);

            return RedirectToAction("ViewAilments", new { id = ailments.GetAilments});
        }

    }
}