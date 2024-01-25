namespace NFLTeams.Models
{
    public class NFLCookies
    {
        private const string TeamsKey = "myteams";
        private const string Delimiter = "-";
        private IRequestCookieCollection requestCookies { get; set; } =
        null!;
        private IResponseCookies responseCookies { get; set; } = null!;
        public NFLCookies(IRequestCookieCollection cookies)
        {
            requestCookies = cookies;
        }
        public NFLCookies(IResponseCookies cookies)
        {
            responseCookies = cookies;
        }
        public void SetMyTeamIds(List<Team> myteams)
        {
            List<string> ids = myteams.Select(t => t.TeamID).ToList();
            string idsString = String.Join(Delimiter, ids);
            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30)
            };
            RemoveMyTeamIds(); // delete old cookie first
            responseCookies.Append(TeamsKey, idsString, options);
        }
        public string[] GetMyTeamsIds()
        {
            string cookie = requestCookies["myteams"] ?? String.Empty;
            if (string.IsNullOrEmpty(cookie))
                return Array.Empty<string>(); // empty string array
            else
                return cookie.Split(Delimiter);
        }
        public void RemoveMyTeamIds()
        {
            responseCookies.Delete(TeamsKey);
        }
    }
}
