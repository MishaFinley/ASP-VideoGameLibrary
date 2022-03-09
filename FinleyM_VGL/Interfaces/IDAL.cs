using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameDataAccessLibrary.Models;

namespace FinleyM_VGL.Interfaces
{
    public interface IDAL
    {
        List<VideoGame> GetGames();

        IEnumerable<VideoGame> SearchForGames(string UserId, string key, string genre, string platform, string esrb);

        VideoGame GetGame(int ID);

        void AddGame(VideoGame game);

        void RemoveGame(VideoGame game);
        void UpdateVideoGame(VideoGame game);
    }
}
