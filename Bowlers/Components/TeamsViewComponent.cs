using Bowlers.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bowlers.Components
{
    public class TeamsViewComponent : ViewComponent
    {
        private ITeamRepository repo { get; set; }
        public TeamsViewComponent(ITeamRepository temp)
        {
            repo = temp;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTeam = RouteData?.Values["team"];

            var t = repo.Teams;

            return View(t);
        }
    }
}
