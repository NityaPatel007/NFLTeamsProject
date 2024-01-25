using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NFLTeams.Models;

namespace NFLTeams.Controllers
{
    public class FavoritesController : Controller
    {
        private TeamContext context;
        public FavoritesController(TeamContext ctx) => context = ctx;
        [HttpGet]
        public ViewResult Index()
        {
            var session = new NFLSession(HttpContext.Session);
            var model = new TeamsViewModel
            {
                ActiveConf = session.GetActiveConf(),
                ActiveDiv = session.GetActiveDiv(),
                Teams = session.GetMyTeams()
            };
            return View(model);
        }
        [HttpPost]
        public RedirectToActionResult Add(Team team)
        {
            team = context.Teams
            .Include(t => t.Conference).Include(t => t.Division)
            .Where(t => t.TeamID == team.TeamID)
            .FirstOrDefault() ?? new Team();
            var session = new NFLSession(HttpContext.Session);
            var cookies = new NFLCookies(Response.Cookies);
            var teams = session.GetMyTeams();
            teams.Add(team);
            session.SetMyTeams(teams);
            cookies.SetMyTeamIds(teams);
            TempData["message"] = $"{team.Name} added to your favorites";
            return RedirectToAction("Index", "Home",
            new
            {
                ActiveConf = session.GetActiveConf(),
                ActiveDiv = session.GetActiveDiv()
            });
        }

        [HttpPost]
        public RedirectToActionResult Delete()
        {
            var session = new NFLSession(HttpContext.Session);
            var cookies = new NFLCookies(Response.Cookies);
            session.RemoveMyTeams();
            cookies.RemoveMyTeamIds();
            TempData["message"] = "Favorite teams cleared";
            return RedirectToAction("Index", "Home",
            new
            {
                ActiveConf = session.GetActiveConf(),
                ActiveDiv = session.GetActiveDiv()
            }
            );
        }
    }
}