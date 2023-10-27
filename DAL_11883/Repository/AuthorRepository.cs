using GamesStore_11883_API.DAL_11883;
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
        public void DeleteAuthor(int authorid)
        {
            var author = FindOne(authorid);
            var games = _dbContext.Games.Where(g => g.Author.ID == authorid);
            if (games.Any())
            {
                _dbContext.Games.RemoveRange(games);
            }
            _dbContext.Authors.Remove(author);
            Save();
        }
        public Author GetAuthorById(int id)
        {
            var author = FindOne(id);
            return author;
        }
        public IEnumerable<Author> GetAuthor()
        {
            return _dbContext.Authors.ToList();
        }
        public void InsertAuthor(Author author)
        {
            _dbContext.Add(author);
            Save();
        }
        public void UpdateAuthor(Author author)
        {
            _dbContext.Entry(author).State = EntityState.Modified;
            Save();
        }

        // DRY Principle
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public Author FindOne(int id)
        {
            return _dbContext.Authors.Find(id);
        }
    }
}
