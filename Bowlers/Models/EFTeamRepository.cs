using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bowlers.Models
{
    public class EFTeamRepository : ITeamRepository
    {
        private BowlersDbContext context;

        public EFTeamRepository(BowlersDbContext temp)
        {
            context = temp;
        }

        public IQueryable<Team> Teams => (IQueryable<Team>)context.Teams;

        //public void SaveTeam
    }
}
