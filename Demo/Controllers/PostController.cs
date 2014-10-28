using Demo.Interfaces.Services;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class PostController : Controller
    {
        //

        // GET: /Post/
        private readonly IPostService pService;

        public PostController(IPostService pService)
        {
            this.pService = pService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View("Index", pService.All());
        }
        
    }
}
