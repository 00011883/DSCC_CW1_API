using GamesStore_11883_API.DAL;
using GamesStore_11883_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GamesStore_11883_API.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly GameContext _dbContext;
        public GameRepository(GameContext dbContext)
        {
            _dbContext = dbContext;
        }
        // Delete game by ID API
        public void DeleteGame(int gameId)
        {
            var game = FindOne(gameId);
            _dbContext.Games.Remove(game);
            Save();
        }
        // Get game by ID API
        public Game GetGameById(int gameId)
        {
            var game = FindOne(gameId);
            _dbContext.Entry(game).Reference(g => g.Author).Load();
            return game;
        }
        // Get list of games API
        public IEnumerable<Game> GetGames()
        {
            return _dbContext.Games.Include(g => g.Author).ToList();
        }
        /// Add game to games list API
        public void InsertGame(Game game)
        {
            // Connect author to game's author foreign key
            game.Author = _dbContext.Authors.Find(game.Author.ID);
            _dbContext.Add(game);
            Save();
        }
        // Edit existing game by it's ID API
        public void UpdateGame(Game game)
        {
            _dbContext.Entry(game).State = EntityState.Modified;
            Save();
        }
        // Saving changes according to the DRY Principle
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        // Getting game by ID for usage above according to the DRY Principle
        public Game FindOne(int id)
        {
            return _dbContext.Games.Find(id);
        }
    }
}
