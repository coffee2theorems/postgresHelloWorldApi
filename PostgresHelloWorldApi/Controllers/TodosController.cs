using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostgresHelloWorldApi.Models;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public TodoController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Todo>> GetTodo()
    {
        _dbContext.Database.EnsureCreated();
        return _dbContext.Todo.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Todo> GetTodoById(int id)
    {
        var todo = _dbContext.Todo.Find(id);
        if (todo == null)
        {
            return NotFound();
        }
        return todo;
    }

    [HttpPost]
    public ActionResult<Todo> CreateTodo([FromBody] Todo todo)
    {
        _dbContext.Todo.Add(todo);
        _dbContext.SaveChanges();
        return CreatedAtAction(nameof(GetTodoById), new { id = todo.Id }, todo);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTodo(int id, [FromBody] Todo updatedTodo)
    {
        var todo = _dbContext.Todo.Find(id);
        if (todo == null)
        {
            return NotFound();
        }

        todo.Title = updatedTodo.Title;
        _dbContext.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTodo(int id)
    {
        var todo = _dbContext.Todo.Find(id);
        if (todo == null)
        {
            return NotFound();
        }

        _dbContext.Todo.Remove(todo);
        _dbContext.SaveChanges();
        return NoContent();
    }
}