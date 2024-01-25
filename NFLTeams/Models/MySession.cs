namespace NFLTeams.Models
{
    public class MySession
    {
        private const string TeamsKey = "teams";
        private ISession session { get; set; }
        public MySession(ISession sess) => session = sess;
        public List<Team> GetTeams() => session.GetObject<List<Team>>(TeamsKey) ?? new List<Team>();
        public void SetTeams(List<Team> teams) => session.SetObject(TeamsKey, teams);
    }
}
