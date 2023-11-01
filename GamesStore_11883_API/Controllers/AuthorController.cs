using GamesStore_11883_API.Models;
using GamesStore_11883_API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace GamesStore_11883_API.Controllers
{
    [Route("api/Author")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        // GET: api/Author
        [HttpGet]
        public IActionResult Get()
        {
            // Make request to the AuthorRepository
            var author = _authorRepository.GetAuthor();
            return new OkObjectResult(author);
        }
        // GET: api/Author/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // Make request to the AuthorRepository
            var author = _authorRepository.GetAuthorById(id);
            if (author != null)
            {
                return new OkObjectResult(author);
            }
            return new OkObjectResult(new { message = "No record with such ID", status = 204 });
        }
        // POST: api/Author
        [HttpPost]
        public IActionResult Post([FromBody] Author author)
        {
            using (var scope = new TransactionScope())
            {
                // Make request to the AuthorRepository
                _authorRepository.InsertAuthor(author);
                CompleteScope(scope);
                return CreatedAtAction(nameof(Get), new { id = author.ID }, author);
            }
        }
        // PUT: api/Author/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Author author)
        {
            if (author != null)
            {
                using (var scope = new TransactionScope())
                {
                    // Make request to the AuthorRepository
                    _authorRepository.UpdateAuthor(author);
                    CompleteScope(scope);
                    return new OkObjectResult(new { message = "Successfuly Updated", status = 202 });
                }
            }
            return new NoContentResult();
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Make request to the AuthorRepository
            _authorRepository.DeleteAuthor(id);
            return new OkObjectResult(new { message = "Successfuly Deteled", status = 204 });
        }

        // DRY Principle to complete used scope
        public void CompleteScope(TransactionScope scope)
        {
            scope.Complete();
        }
    }
}
