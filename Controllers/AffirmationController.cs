using Microsoft.AspNetCore.Mvc;
using FinalProject.Models;

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

        public IActionResult ViewAffirmation(int id)
        {
            var affirmation = repo.GetAffirmation(id);

            return View(affirmation);
        }

        public IActionResult UpdateAffirmationTxt(int id)
        {
            Affirmation affirm = repo.GetAffirmation(id);

            if (affirm == null)
            {
                return View("AffirmationNotFound");
            }

            return View(affirm);
        }

        public IActionResult UpdateAffirmationToDatabase(Affirmation affirmation)
        {
            repo.UpdateAffirmationTxt(affirmation);

            return RedirectToAction("ViewAffirmation", new { id = affirmation.ID });
        }



    }
}
