using Microsoft.AspNetCore.Mvc;
using FinalProject.Models;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace FinalProject.Controllers
{
    public class AffirmationController : Controller
    {

        private readonly IAffirmationRepo repo;

        public AffirmationController(IAffirmationRepo repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var affirmations = repo.GetAllAffirmations();
            return View(affirmations);
        }

        [HttpGet]
        public IActionResult Index(string AffirmSearch)
        {
            ViewData["GetAffirms"] = AffirmSearch;

            var affirmQuery = from a in repo.GetAllAffirmations().ToList() select a;
            if (!String.IsNullOrEmpty(AffirmSearch))
            {
                affirmQuery = affirmQuery.Where(a => a.Category.Contains(AffirmSearch) || a.AffirmationText.Contains(AffirmSearch));
            }
            return View(affirmQuery);
        }

        public IActionResult ViewAffirmation(int id)
        {
            var affirmation = repo.GetAffirmation(id);

            return View(affirmation);
        }

        public IActionResult UpdateAffirmationTxt(int id)
        {
            Affirmations affirm = repo.GetAffirmation(id);

            if (affirm == null)
            {
                return View("AffirmationNotFound");
            }

            return View(affirm);
        }

        public IActionResult UpdateAffirmationToDatabase(Affirmations affirmation)
        {
            repo.UpdateAffirmationTxt(affirmation);

            return RedirectToAction("ViewAffirmation", new { id = affirmation.ID });
        }

        public IActionResult DeleteAffirmation(Affirmations affirmation)
        {
            repo.DeleteAffirmation(affirmation);
            return RedirectToAction("Index");
        }

        public IActionResult InsertAffirmation()
        {
            var affirm = repo.AssignCategory();

            return View(affirm);
        }

        public IActionResult InsertAffirmationToDatabase(Affirmations affirm)
        {
            repo.InsertAffirmation(affirm);

            return RedirectToAction("Index");
        }

    }
}
