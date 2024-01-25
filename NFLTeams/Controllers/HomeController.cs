using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NFLTeams.Models;
using System.Text.Json;

namespace NFLTeams.Controllers
{
    public class HomeController : Controller
    {
        private TeamContext context;

        public HomeController(TeamContext ctx)
        {
            context = ctx;
        }

        public ViewResult Index(TeamsViewModel model)
        {
            //Team team = new Team { TeamID = "sea", Name = "Seattle Seahawks"};
            //string json = JsonSerializer.Serialize(team);
            //HttpContext.Session.SetString("team", json);

            //var team = HttpContext.Session.GetObject<Team>("team") ?? new Team();
            //team.Name = "Seattle Seahawks";
            //HttpContext.Session.SetObject("team", team);

            //var teams = HttpContext.Session.GetObject<List<Team>>("teams") ?? new List<Team>();
            //teams.Add(new Team
            //{
            //    TeamID = "gb",
            //    Name = "Green Bay Packers"
            //});
            //HttpContext.Session.SetObject("teams", teams);

            //var session = new MySession(HttpContext.Session);
            //var teams = session.GetTeams();
            //teams.Add(new Team
            //{
            //    TeamID = "gb",
            //    Name = "Green Bay Packers"
            //});
            //teams.Add(new Team
            //{
            //    TeamID = "ab",
            //    Name = "Alan Bay"
            //});
            //session.SetTeams(teams);

            // store selected conference and division in session
            var session = new NFLSession(HttpContext.Session);
            session.SetActiveConf(model.ActiveConf);
            session.SetActiveDiv(model.ActiveDiv);

            // get conferences and divisions from database 
            model.Conferences = context.Conferences.ToList();
            model.Divisions = context.Divisions.ToList();

            // if no count in session, get cookie and restore fave teams
            int? count = session.GetMyTeamCount();
            if (!count.HasValue)
            {
                var cookies = new NFLCookies(Request.Cookies);
                string[] ids = cookies.GetMyTeamsIds();
                if (ids.Length > 0)
                {
                    var myteams = context.Teams.Include(t => t.Conference)
                    .Include(t => t.Division)
                    .Where(t => ids.Contains(t.TeamID)).ToList();
                    session.SetMyTeams(myteams);
                }
            }

            // get teams from database - filter by conference and division
            IQueryable<Team> query = context.Teams.OrderBy(t => t.Name);
            if (model.ActiveConf != "all")
                query = query.Where(
                    t => t.Conference.ConferenceID.ToLower() == model.ActiveConf.ToLower());
            if (model.ActiveDiv != "all")
                query = query.Where(
                    t => t.Division.DivisionID.ToLower() == model.ActiveDiv.ToLower());
            model.Teams = query.ToList();

            // pass view model to view
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            // get selected conference and division from session
            // and pass them to the view in the view model
            var session = new NFLSession(HttpContext.Session);
            var model = new TeamsViewModel
            {
                Team = context.Teams
            .Include(t => t.Conference)
            .Include(t => t.Division)
            .FirstOrDefault(t => t.TeamID == id) ?? new Team(),
                ActiveConf = session.GetActiveConf(),
                ActiveDiv = session.GetActiveDiv()
            };
            return View(model);
        }
    }
}