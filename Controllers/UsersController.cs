using Data;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.EntityFrameworkCore;

namespace csharp_crud_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
  private readonly UserContext _context;

  public UsersController(UserContext context)
  {
    _context = context;
  }

  // GET: api/users
  [HttpGet]
  public async Task<ActionResult<IEnumerable<User>>> GetUsers()
  {
    return await _context.Users.ToListAsync();
  }

  // GET: api/users/5
  [HttpGet("{id}")]
  public async Task<ActionResult<User>> GetUser(int id)
  {
    var user = await _context.Users.FindAsync(id);

    if (user == null)
    {
      return NotFound();
    }

    return user;
  }

  // POST api/users
  [HttpPost]
  public async Task<ActionResult<User>> PostUser(User user)
  {
    _context.Users.Add(user);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
  }

  // PUT api/users/5
  [HttpPut("{id}")]
  public async Task<IActionResult> PutUser(int id, User user)
  {
    if (id != user.Id)
    {
      return BadRequest();
    }

    _context.Entry(user).State = EntityState.Modified;
    await _context.SaveChangesAsync();

    return NoContent();
  }

  // DELETE api/users/5
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteUser(int id)
  {
    var user = await _context.Users.FindAsync(id);

    if (user == null)
    {
      return NotFound();
    }

    _context.Users.Remove(user);
    await _context.SaveChangesAsync();

    return NoContent();
  }

  // dummy endpoint to test the database connection
  [HttpGet("test")]
  public string Test()
  {
    return "Hello World!";
  }
}