using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bowlers.Models
{
    public class EFBowlersRepository : IBowlersRepository
    {
        public BowlersDbContext context;
        public EFBowlersRepository (BowlersDbContext temp)
        {
            context = temp;
        }
        public IQueryable<Bowler> Bowlers => context.Bowlers;

        public void Add(Bowler b)
        {
            if (b.BowlerID == 0)
            {
                var max = context.Bowlers.Max(x => x.BowlerID);
                b.BowlerID = max + 1;
                context.Add(b);
                context.SaveChanges();
            }
            else
            {
                context.Add(b);
                context.SaveChanges();
            }
        }

        public void SaveBowler(Bowler b)
        {
            if (b.BowlerID == 0)
            {
                var max = context.Bowlers.Max(x => x.BowlerID);
                b.BowlerID = max + 1;

                context.Update(b);
                context.SaveChanges();
            }
              
            else 
            { 
                context.Update(b);
                context.SaveChanges();
            }
            
        }

        public void DeleteBowler(Bowler bowler)
        {
            context.Remove(bowler);
            context.SaveChanges();
        }
    }
}
