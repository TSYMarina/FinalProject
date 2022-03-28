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

    }
}
