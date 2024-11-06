namespace DI1P2_2027_BibliothequeAPI.Controllers
{
    using DI1P2_2027_BibliothequeAPI.Models;
    using DI1P2_2027_BibliothequeAPI.Persistence;
    using DI1P2_2027_BibliothequeAPI.Persistence.Contracts;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController(IAuthorRepository authorRepository) : Controller
    {
        /// <summary>
        /// Return a list of authors
        /// </summary>
        /// <returns>Collection of authors</returns>
        
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(authorRepository.GetAllAuthors());
        }
        [HttpPost("addAuthor")]
        public IActionResult addAuthor(string name, string firstname, string description)
        {
            Author author = new Author
            {
                name = name,
                firstname = firstname,
                description = description,
            };
            authorRepository.AddAuthor(author);
            return Ok();
        }
        [HttpPatch("setAuthor")]
        public IActionResult setAuthor(string name, string firstname, string description, uint id)
        {
            Author author = new Author
            {
                name = name,
                firstname = firstname,
                description = description,
                id = id,
            };

            authorRepository.SetAuthor(author);
            return Ok();
        }
        [HttpGet("byName")]
        public IActionResult getAuthorByName(string name)
        {
            return Ok(authorRepository.GetAllAuthorsByName(name));
        }
        [HttpGet("byFirstname")]
        public IActionResult getAuthorByFirstame(string firstname)
        {
            return Ok(authorRepository.GetAllAuthorsByFirstname(firstname));
        }
        [HttpGet("byId")]
        public IActionResult getAuthorById(uint id)
        {
            return Ok(authorRepository.GetAuthorById(id));
        }
    }
}
