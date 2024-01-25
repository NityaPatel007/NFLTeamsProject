using Microsoft.EntityFrameworkCore;

namespace NFLTeams.Models
{
    public class TeamContext : DbContext
    {
        public TeamContext(DbContextOptions<TeamContext> options)
            : base(options)
        { }

        public DbSet<Team> Teams { get; set; } = null!;
        public DbSet<Conference> Conferences { get; set; } = null!;
        public DbSet<Division> Divisions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Conference>().HasData(
                new Conference { ConferenceID = "afc", Name = "AFC"},
                new Conference { ConferenceID = "nfc", Name = "NFC" }
            );
            modelBuilder.Entity<Division>().HasData(
                new Division { DivisionID = "north", Name = "North" },
                new Division { DivisionID = "south", Name = "South" },
                new Division { DivisionID = "east", Name = "East" },
                new Division { DivisionID = "west", Name = "West" }
            );
            modelBuilder.Entity<Team>().HasData(
                new { TeamID = "ari", Name = "Arizona Cardinals", ConferenceID = "nfc", DivisionID = "west", LogoImage = "ARI.png" },
                new { TeamID = "atl", Name = "Atlanta Falcons", ConferenceID = "nfc", DivisionID = "south", LogoImage = "ATL.png" },
                new { TeamID = "bal", Name = "Baltimore Ravens", ConferenceID = "afc", DivisionID = "north", LogoImage = "BAL.png" },
                new { TeamID = "buf", Name = "Buffalo Bills", ConferenceID = "afc", DivisionID = "east", LogoImage = "BUF.png" },
                new { TeamID = "car", Name = "Carolina Panthers", ConferenceID = "nfc", DivisionID = "south", LogoImage = "CAR.png" },
                new { TeamID = "chi", Name = "Chicago Bears", ConferenceID = "nfc", DivisionID = "north", LogoImage = "CHI.png" },
                new { TeamID = "cin", Name = "Cincinnati Bengals", ConferenceID = "afc", DivisionID = "north", LogoImage = "CIN.png" },
                new { TeamID = "cle", Name = "Cleveland Browns", ConferenceID = "afc", DivisionID = "north", LogoImage = "CLE.png" },
                new { TeamID = "dal", Name = "Dallas Cowboys", ConferenceID = "nfc", DivisionID = "east", LogoImage = "DAL.png" },
                new { TeamID = "den", Name = "Denver Broncos", ConferenceID = "afc", DivisionID = "west", LogoImage = "DEN.png" },
                new { TeamID = "det", Name = "Detroit Lions", ConferenceID = "nfc", DivisionID = "north", LogoImage = "DET.png" },
                new { TeamID = "gb", Name = "Green Bay Packers", ConferenceID = "nfc", DivisionID = "north", LogoImage = "GB.png" },
                new { TeamID = "hou", Name = "Houston Texans", ConferenceID = "afc", DivisionID = "south", LogoImage = "HOU.png" },
                new { TeamID = "ind", Name = "Indianapolis Colts", ConferenceID = "afc", DivisionID = "south",LogoImage = "IND.png" },
                new { TeamID = "jax", Name = "Jacksonville Jaguars", ConferenceID = "afc", DivisionID = "south", LogoImage = "JAX.png" },
                new { TeamID = "kc", Name = "Kansas City Chiefs", ConferenceID = "afc", DivisionID = "west", LogoImage = "KC.png" },
                new { TeamID = "lac", Name = "Los Angeles Chargers", ConferenceID = "afc", DivisionID = "west", LogoImage = "LAC.png" },
                new { TeamID = "lar", Name = "Los Angeles Rams", ConferenceID = "nfc", DivisionID = "west", LogoImage = "LAR.png" },
                new { TeamID = "lv", Name = "Las Vegas Raiders", ConferenceID = "afc", DivisionID = "west", LogoImage = "LV.png" },
                new { TeamID = "mia", Name = "Miami Dolphins", ConferenceID = "afc", DivisionID = "east", LogoImage = "MIA.png" },
                new { TeamID = "min", Name = "Minnesota Vikings", ConferenceID = "nfc", DivisionID = "north", LogoImage = "MIN.png" },
                new { TeamID = "ne", Name = "New England Patriots", ConferenceID = "afc", DivisionID = "east", LogoImage = "NE.png" },
                new { TeamID = "no", Name = "New Orleans Saints", ConferenceID = "nfc", DivisionID = "south", LogoImage = "NO.png" },
                new { TeamID = "nyg", Name = "New York Giants", ConferenceID = "nfc", DivisionID = "east", LogoImage = "NYG.png" },
                new { TeamID = "nyj", Name = "New York Jets", ConferenceID = "afc", DivisionID = "east", LogoImage = "NYJ.png" },  
                new { TeamID = "phi", Name = "Philadelphia Eagles", ConferenceID = "nfc", DivisionID = "east", LogoImage = "PHI.png" },
                new { TeamID = "pit", Name = "Pittsburgh Steelers", ConferenceID = "afc", DivisionID = "north", LogoImage = "PIT.png" },
                new { TeamID = "sea", Name = "Seattle Seahawks", ConferenceID = "nfc", DivisionID = "west", LogoImage = "SEA.png" },
                new { TeamID = "sf", Name = "San Francisco 49ers", ConferenceID = "nfc", DivisionID = "west", LogoImage = "SF.png" },
                new { TeamID = "tb", Name = "Tampa Bay Buccaneers", ConferenceID = "nfc", DivisionID = "south", LogoImage = "TB.png" },
                new { TeamID = "ten", Name = "Tennessee Titans", ConferenceID = "afc", DivisionID = "south", LogoImage = "TEN.png" },
                new { TeamID = "was", Name = "Washington Commanders", ConferenceID = "nfc", DivisionID = "east", LogoImage = "WAS.png" }
            );
        }
    }
}
