using System.Web.Mvc;
using PairingTest.Web.Models;

namespace PairingTest.Web.Controllers
{
    public class QuestionnaireController : Controller
    {
        /* ASYNC ACTION METHOD... IF REQUIRED... */
        // public async Task<ViewResult> Index() { }

        public ViewResult Index()
        {
            var viewModel = new QuestionnaireViewModel();
            viewModel.QuestionnaireTitle = "My expected questions";
            return View(viewModel);
        }
    }
}