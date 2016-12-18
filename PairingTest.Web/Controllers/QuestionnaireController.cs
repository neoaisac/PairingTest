using System.Web.Mvc;
using PairingTest.Web.Middleware.Http;
using PairingTest.Web.Models;

namespace PairingTest.Web.Controllers
{
    public class QuestionnaireController : Controller
    {
        private readonly IHttpClientContainer _httpClientContainer;

        public string QuestionnaireServiceUri { get; set; }

        public QuestionnaireController(IHttpClientContainer httpClientContainer)
        {
            _httpClientContainer = httpClientContainer;
        }

        public ViewResult Index()
        {
            var viewModel = new QuestionnaireViewModel();
            viewModel.QuestionnaireTitle = "My expected questions";

            // Setup ViewBag
            ViewBag.Title = viewModel.QuestionnaireTitle;

            return View(viewModel);
        }
    }
}