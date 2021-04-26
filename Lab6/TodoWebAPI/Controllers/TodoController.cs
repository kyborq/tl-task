using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        TodoRepository repository = new TodoRepository();
        
        // GET: api/<TodoController>
        [HttpGet]
        public List<TodoDTO> Get()
        {
            return repository.GetAll();
        }

        // POST api/<TodoController>
        [HttpPost]
        public int Post([FromBody] TodoDTO todoDTO)
        {
            return repository.Create(todoDTO);
        }

        // PUT api/<TodoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TodoDTO todoDTO)
        {
            repository.Update(id, todoDTO);
        }
    }
}
