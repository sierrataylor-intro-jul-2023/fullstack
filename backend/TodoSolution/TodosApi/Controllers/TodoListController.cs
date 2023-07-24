namespace TodosApi.Controllers
{
    public class TodoListController : ControllerBase
    {
        [HttpGet("/todo-list")]
        public async Task<ActionResult> GetTodoList()
        {
            var list = new List<TodoListItemResponseModel>() {
                new TodoListItemResponseModel(Guid.NewGuid(), "New beer", TodoItemStatus.Now),
                new TodoListItemResponseModel(Guid.NewGuid(), "Clean garage", TodoItemStatus.Waiting)

            };
            var response = new CollectionResponse<TodoListItemResponseModel>(list);
            return Ok(response);
        }
    }
}
