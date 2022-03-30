using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bowlers.Models
{
    public interface IBowlersRepository
    {
        public IQueryable<Bowler> Bowlers { get; }

        public void Add(Bowler bowler);
        public void SaveBowler(Bowler bowler);

        public void DeleteBowler(Bowler bowler);
    }

    
}
