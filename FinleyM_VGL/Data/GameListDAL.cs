using FinleyM_VGL.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameDataAccessLibrary.Data;
using VideoGameDataAccessLibrary.Models;

namespace FinleyM_VGL.Data
{
    public class GameListDAL : IDAL
    {
        private VideoGameContext _db;
        //private static List<VideoGame> vglist = new List<VideoGame>
        //    {
        //        new VideoGame("StreetFighter II", "SNES", "Fighting", "E", 1991, "images/sf.png", null, null),
        //        new VideoGame("CyberPunk 2077", "Playstation", "RPG", "M", 2020, "images/cp.png", null, null),
        //        new VideoGame("Duck Game", "Ouya", "Fighting", "M", 2014, "images/dg.png", null, null),
        //        new VideoGame("Dead by Daylight", "Windows", "Horror", "E", 2016, "images/dbd.png", null, null),
        //        new VideoGame("Rocket League", "Windows", "Sports", "E", 2015, "images/rl.png", null, null)
        //    };

        public GameListDAL(VideoGameContext db)
        {
            this._db = db;
        }

        public List<VideoGame> GetGames()
        {
            return _db.VideoGames.ToList();
        }
        public VideoGame GetGame(int ID)
        {
            
            return _db.VideoGames.Where(mbox => mbox.Id == ID).FirstOrDefault();
        }
        public IEnumerable<VideoGame> SearchForGames(string UserId, string key, string genre, string platform, string esrb)
        {
            IEnumerable<VideoGame> searchResult = GetGames();
            //foreach (var game in GetGames())
            //{
            //    //if (game.Title.ToLower().Contains(key.ToLower()) &&
            //    //    game.Genre.ToLower().Contains(genre.ToLower())
            //    //    //game.
            //    //    )
            //    //{
            //    //    searchResult.Add(game);
            //    //}
            //    //if (!String.IsNullOrEmpty(game.Title))
            //    //{
            //    //    searchResult = 
            //    //}
            //}

            if (!String.IsNullOrEmpty(key))
            {
                searchResult = searchResult.Where(s => s.Title.ToLower().Contains(key.ToLower()));
            }
            if (!String.IsNullOrEmpty(genre))
            {
                searchResult = searchResult.Where(s => s.Genre.ToLower().Contains(genre.ToLower()));
            }
            if (!String.IsNullOrEmpty(platform))
            {
                searchResult = searchResult.Where(s => s.Platform.ToLower().Contains(platform.ToLower()));
            }
            if (!String.IsNullOrEmpty(esrb))
            {
                searchResult = searchResult.Where(s => s.ESRB.ToLower().Contains(esrb.ToLower()));
            }
            return searchResult.Where(s => s.UserId == UserId);
        }
        public void AddGame(VideoGame game)
        {
            _db.VideoGames.Add(game);
            _db.SaveChanges();
        }
        public void RemoveGame(VideoGame game)
        {
            _db.VideoGames.Remove(game);
            _db.SaveChanges();
        }
        public void UpdateVideoGame(VideoGame game)
        {
            _db.Update(game);
            _db.SaveChanges();
        }

    }
}
