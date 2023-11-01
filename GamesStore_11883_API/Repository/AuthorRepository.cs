using GamesStore_11883_API.DAL;
using GamesStore_11883_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GamesStore_11883_API.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly GameContext _dbContext;
        public AuthorRepository(GameContext dbContext)
        {
            _dbContext = dbContext;
        }
        // Delete author by ID API
        public void DeleteAuthor(int authorid)
        {
            var author = FindOne(authorid);
            // Removing games where author connected
            var games = _dbContext.Games.Where(g => g.Author.ID == authorid);
            if (games.Any())
            {
                _dbContext.Games.RemoveRange(games);
            }
            _dbContext.Authors.Remove(author);
            Save();
        }
        // Get author by ID API
        public Author GetAuthorById(int id)
        {
            var author = FindOne(id);
            return author;
        }
        // Get list of authors API
        public IEnumerable<Author> GetAuthor()
        {
            return _dbContext.Authors.ToList();
        }
        // Add author to authors API
        public void InsertAuthor(Author author)
        {
            _dbContext.Add(author);
            Save();
        }
        // Edit existing author by it's ID API
        public void UpdateAuthor(Author author)
        {
            _dbContext.Entry(author).State = EntityState.Modified;
            Save();
        }

        // Saving changes according to the DRY Principle
        public void Save()
        {
            _dbContext.SaveChanges();
        }
        // Getting author by ID for usage above according to the DRY Principle
        public Author FindOne(int id)
        {
            return _dbContext.Authors.Find(id);
        }
    }
}
 