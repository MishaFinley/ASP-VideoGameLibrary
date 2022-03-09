using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FinleyM_VGL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VideoGameDataAccessLibrary.Models;

namespace FinleyM_VGL.Areas.Admin.Pages.Roles.PremiumUser
{
    public class IndexModel : PageModel
    {
        IDAL dal;
        public IndexModel(IDAL dataAccessLayer)
        {
            dal = dataAccessLayer;
        }
        public SelectList Games { get; set; }

        [BindProperty]
        [Required]
        public int SelectedGame { get; set; }

        [BindProperty]
        [Required]
        public string VideoUrl { get; set; }


        public IActionResult OnGet()
        {
            SetupGames();
            return Page();
        }
        
        public IActionResult OnPost()

        {
            if (!ModelState.IsValid)
            {
                SetupGames();
                return Page();
            }
            dal.GetGame(SelectedGame).VideoURL = VideoUrl;
            string vurl = dal.GetGame(SelectedGame).VideoURL;
            dal.UpdateVideoGame(dal.GetGame(SelectedGame));


            return Redirect("/Home/Games");

        }
        private void SetupGames()
        {
            Games = new SelectList(dal.GetGames(), "Id", "Title");
            
        }
    }
}
