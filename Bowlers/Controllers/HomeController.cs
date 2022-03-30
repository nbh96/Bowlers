using Bowlers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bowlers.Controllers
{
    
    public class HomeController : Controller
    {
        private IBowlersRepository bowlerrepo;
        private ITeamRepository repo;
        public int BowlerID { get; set; }

        public HomeController(IBowlersRepository temp, ITeamRepository temp2)
        {
            bowlerrepo = temp;
            repo = temp2;
        }

        [HttpGet]
        public IActionResult Index(int team)
        {
            var bowlers = bowlerrepo.Bowlers
                .Where(b => b.TeamID == team || team == 0)
                .ToList();
            if (team == 0)
            {
                ViewBag.Header = "All Teams";
            }
            else
            {
                ViewBag.Header = repo.Teams.Single(x => x.TeamID == team).TeamName;
            }

            return View(bowlers);
        }


        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Cat = repo.Teams.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Bowler b)
        {

            bowlerrepo.Add(b);

            bowlerrepo.SaveBowler(b);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var bowl = bowlerrepo.Bowlers.Single(x => x.BowlerID == id);
            return View("Add", bowl);
        }

        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            bowlerrepo.SaveBowler(b);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var bowl = bowlerrepo.Bowlers.Single(x => x.BowlerID == id);
            bowlerrepo.DeleteBowler(bowl);
            return RedirectToAction("Index");
        }

    }
}
