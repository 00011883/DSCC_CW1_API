using GamesStore_11883_API.Models;
using System.Collections.Generic;

namespace GamesStore_11883_API.Repository
{
    public interface IGameRepository
    {
        void InsertGame(Game game);
        void UpdateGame(Game game);
        void DeleteGame(int gameid);
        Game GetGameById(int Id);
        IEnumerable<Game> GetGames();
    }
}
