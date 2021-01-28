using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using TodoApiDemo.Models;

namespace TodoApiDemo.Controllers.Api
{
	public class TodosController : ApiController
	{
		private ApplicationDbContext _context;
		public TodosController()
		{
			_context = new ApplicationDbContext();
		}

		[HttpGet]
		public IHttpActionResult GetAllTodos()
		{
			return Ok(_context.Todos.ToList());
		}

		[HttpGet]
		public IHttpActionResult GetTodoById(int id)
		{
			var todoInDb = _context.Todos.SingleOrDefault(t => t.Id == id);

			if (todoInDb == null) return NotFound();

			return Ok(todoInDb);
		}

		[HttpPost]
		public IHttpActionResult Create([FromBody] Todo todo)
		{
			var newTodo = new Todo()
			{
				Name = todo.Name,
				Category = todo.Category
			};

			_context.Todos.Add(newTodo);
			_context.SaveChanges();

			return new StatusCodeResult(HttpStatusCode.Created, this);
		}

		[HttpDelete]
		public IHttpActionResult Delete(int id)
		{
			var todoInDb = _context.Todos.SingleOrDefault(t => t.Id == id);

			if (todoInDb == null) return NotFound();

			_context.Todos.Remove(todoInDb);
			_context.SaveChanges();

			return Ok("Delete Succesfully ...");
		}

		[HttpPut]
		public IHttpActionResult Edit(int id, [FromBody] Todo todo)
		{
			var todoInDb = _context.Todos.SingleOrDefault(t => t.Id == id);

			if (todoInDb == null) return NotFound();

			todoInDb.Name = todo.Name;
			todoInDb.Category = todo.Category;
			_context.SaveChanges();

			return new StatusCodeResult(HttpStatusCode.NoContent, this);

		}

	}
}
