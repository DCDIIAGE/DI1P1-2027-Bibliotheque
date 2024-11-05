namespace DI1P2_2027_BibliothequeAPI.Controllers
{
    /*using DI1P2_2027_BibliothequeAPI.Models;
    using DI1P2_2027_BibliothequeAPI.Persistence;
    using DI1P2_2027_BibliothequeAPI.Persistence.Contracts;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/Author")]
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
        [HttpGet("/addAuthor")]
        public IActionResult actionResult(string name, string firstname, string description)
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
    }*/
}
