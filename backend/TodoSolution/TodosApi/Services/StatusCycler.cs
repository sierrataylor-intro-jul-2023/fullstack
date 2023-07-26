namespace TodosApi.Services
{
    public class StatusCycler : IProvideStatusCycling
    {
        public TodoListItemResponseModel ProvideNextStatusFrom(TodoListItemResponseModel savedItem)
        {
            var numStatusValues = Enum.GetValues(typeof(TodoItemStatus)).Length;
            TodoListItemResponseModel itemWIthChangedStatus = new TodoListItemResponseModel(savedItem.Id, 
                                                                                            savedItem.Description, 
                                                                                            savedItem.Status == (TodoItemStatus)numStatusValues-1  ? 0 : savedItem.Status + 1);

            return itemWIthChangedStatus;
        }
    }
}
