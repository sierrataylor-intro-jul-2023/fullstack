using Marten;

namespace TodosApi.Controllers
{
    [ApiController]
    public class TodoListController : ControllerBase
    {
        private readonly IDocumentSession _documentSession;
        public TodoListController(IDocumentSession documentSession)
        {
            _documentSession = documentSession;
        }

        [HttpPost("/todo-list")]
        public async Task<ActionResult> AddTodoItem([FromBody] TodoListCreateModel request)
        {
            var newItem = new TodoListItemResponseModel(Guid.NewGuid(), request.Description, TodoItemStatus.Later); //create new item with desc
            _documentSession.Store(newItem); 
            await _documentSession.SaveChangesAsync(); //store the new item and save changes in the database
            return Ok(newItem); //send teh new item back
        }

        [HttpGet("/todo-list")]
        public async Task<ActionResult> GetTodoList()
        {
            var list = await _documentSession.Query<TodoListItemResponseModel>().ToListAsync();
            //var response = new CollectionResponse<TodoListItemResponseModel>(list);
            return Ok(list);
        }
    }
}
