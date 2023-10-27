using GamesStore_11883_API.Models;
using System.Collections.Generic;

namespace GamesStore_11883_API.Repository
{
    public interface IAuthorRepository
    {
        void InsertAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(int authorid);
        Author GetAuthorById(int Id);
        IEnumerable<Author> GetAuthor();
    }
}
