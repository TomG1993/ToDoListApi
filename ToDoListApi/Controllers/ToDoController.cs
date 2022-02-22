using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Models;

namespace ToDoListApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : Controller
    {
        private static readonly List<ToDoRecord> ToDoList = new List<ToDoRecord>{
        new ToDoRecord()
        {
            Description =  "Call friend",
            Status = 0
        },
                new ToDoRecord()
        {
            Description =  "Pay bills",
            Status = 0
        },
                new ToDoRecord()
        {
            Description =  "Other things",
            Status = 0
        } };

        private readonly ILogger<ToDoController> _logger;

        public ToDoController(ILogger<ToDoController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTodoRecords")]
        public IEnumerable<ToDoRecord> Get()
        {
            return ToDoList;
        }

        [HttpPost("/AddToDoRecord")]
        public async Task<ActionResult<ToDoRecord>> Post([FromBody] ToDoRecord toDoRecord)
        {
            if (toDoRecord == null)
            {
                _logger.Log(LogLevel.Error, "Attempted to add a null ToDo record");
                return BadRequest();
            }

            ToDoList.Add(toDoRecord);

            return Ok(toDoRecord);
        }
    }
}
