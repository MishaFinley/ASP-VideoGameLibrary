using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinleyM_VGL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoGameDataAccessLibrary.Models;

namespace FinleyM_VGL.Areas.Admin.Pages.Roles.PremiumUser
{
    public class Index1Model : PageModel
    {
        IDAL dal;
        public Index1Model(IDAL dataAccessLayer)
        {
            dal = dataAccessLayer;
        }

        public List<VideoGame> Games { get; set; }
        public IActionResult OnGet()
        {
            SetupGames();
            return Page();
        }

        public IActionResult OnPost()
        {
            return Redirect("/Home");
        }

        private void SetupGames()
        {
            Games = new List<VideoGame>(dal.GetGames());

        }
    }
}
