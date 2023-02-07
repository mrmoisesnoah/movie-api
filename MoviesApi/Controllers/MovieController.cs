using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Data;
using MoviesApi.Data.Dtos;
using MoviesApi.Models;

namespace MoviesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;

    public MovieController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    /// <summary>
    /// Search list of movies saved in the database
    /// </summary>
    /// <param name="ReadMovieDTO">Response object to return the necessary info required by the user</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Requested successfully</response>
    [HttpGet]
    public IEnumerable<ReadMovieDTO> SearchMovies([FromQuery] int skip, 
        [FromQuery] int take)
    {
        return _mapper.Map<List<ReadMovieDTO>>(_context.Movies.Skip(skip).Take(take));
    }


    /// <summary>
    /// Search movie information by ID
    /// </summary>
    /// <param name="ReadMovieDTO">Response object to return the necessary info required by the user</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Request made successfully</response>
    [HttpGet("{id}")]
    public IActionResult SearchMovieById(int id)
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movie == null) return NotFound();
        var movieDTO = _mapper.Map<ReadMovieDTO>(movie);
        return Ok(movieDTO);
    }


    /// <summary>
    /// Add a new movie to the DataBase
    /// </summary>
    /// <param name="movieDto">Object with the required fields to register a new movie</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Movie saved successfully</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AddMovie([FromBody] CreateMovieDTO movieDto)
    {
        Movie movie = _mapper.Map<Movie>(movieDto);
        _context.Movies.Add(movie);
        _context.SaveChanges();
        return CreatedAtAction(nameof(SearchMovieById), new { id = movie.Id }, 
            movie);
    }

    /// <summary>
    /// Updates all movie information by id
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="200">Update made successfully</response>
    [HttpPut("{id}")]
    public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDTO movieDto)
    {
        var update = _context.Movies.FirstOrDefault(movie => movie.Id == id);
        if (update == null) return NotFound();
        _mapper.Map(movieDto,update);
        _context.SaveChanges();

        return NoContent();
    }


    /// <summary>
    /// Updates partial movie information by id
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="200">Update made successfully</response>
    [HttpPatch("{id}")]
    public IActionResult PartialUpdate(int id, [FromBody] JsonPatchDocument<UpdateMovieDTO> patch)
    {
        var update = _context.Movies.FirstOrDefault(movie => movie.Id == id);
        if (update == null) return NotFound();
        var updatedMovie = _mapper.Map<UpdateMovieDTO>(update);

        patch.ApplyTo(updatedMovie, ModelState);

        if (!TryValidateModel(updatedMovie))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(updatedMovie, update);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Delete movie information from the DataBase
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="204">Delete made successfully</response>
    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id)
    {
        var movie = _context.Movies.FirstOrDefault(
            movie => movie.Id == id);
        if (movie == null) return NotFound();
        _context.Remove(movie);
        _context.SaveChanges();
        return NoContent();
    }
}
