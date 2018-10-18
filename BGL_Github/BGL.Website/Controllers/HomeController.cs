using BGL.GithubUserManager;
using BGL.PresentationModels;
using BGL.Website.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BGL.Website.Controllers
{
    public class HomeController : Controller
    {
        private IRepoService repoService;
        private IUserService userService;

        public HomeController()
        {
            repoService = new RepoService();
            userService = new UserService();
        }

        public ActionResult Index()
        {
            Search s = new Search();
            return View(s);
        }

        [HttpPost]
        public async Task<ActionResult> Details(Search search)
        {
            try
            {
                var user = await userService.GetByUsernameAsync(search.SearchTerm);
                user.Repos = await repoService.GetTop5ReposByUsernameOrderByStargazerCountAsync(search.SearchTerm);

                return View(user.ToPresentationModel());
            }
            catch (Exception e)
            {
                return View("index");
            }
        }
    }
}