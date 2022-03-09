using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGameDataAccessLibrary.Models
{
    public class VideoGame
    {
        
        //private static int nextId = 0;
        public int? Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Platform { get; set; }
        public string Genre { get; set; }
        public string ESRB { get; set; }
        public int Year { get; set; }
        public string Image { get; set; }
        public string VideoURL { get; set; }
        public string LoanedTo { get; set; }
        public DateTime? LoanDate { get; set; }

        public void LoanOut(string LoanedTo, DateTime LoanDate)
        {
            this.LoanedTo = LoanedTo;
            this.LoanDate = LoanDate;
        }
        public void Return()
        {
            this.LoanedTo = null;
            this.LoanDate = null;
        }

        public string getTags()
        {
            return $"{Title}, {Platform}, {Genre}, {ESRB}, {Year}";
        }

        public VideoGame()
        {

        }
        public VideoGame(string UserId, string title, string platform, string genre, string esrb, int year,
            string image, string VideoURL, string loanedto, DateTime? loandate)
        {
            this.UserId = UserId;
            this.Title = title;
            this.Platform = platform;
            this.Genre = genre;
            this.ESRB = esrb;
            this.Year = year;
            this.Image = image;
            this.VideoURL = VideoURL;
            this.LoanedTo = loanedto;
            this.LoanDate = loandate;
        }


    }
}
