using TodosApi.Models;
using TodosApi.Services;

namespace TodosApi.UnitTests
{
    public class StatusCyclerTests
    {
        [Fact]
        public void CanChangeTheStatusFromLaterToNow()
        {
            IProvideStatusCycling cycler = new StatusCycler();
            var beforeItem = new TodoListItemResponseModel(Guid.NewGuid(), "get tacos", TodoItemStatus.Later);
            var expectedAfterItem = beforeItem with { Status = TodoItemStatus.Now };
            var actual = cycler.ProvideNextStatusFrom(beforeItem);
            Assert.Equal(expectedAfterItem, actual);
        }
        [Fact]
        public void CanChangeTheStatusFromNowToWaiting()
        {
            IProvideStatusCycling cycler = new StatusCycler();
            var beforeItem = new TodoListItemResponseModel(Guid.NewGuid(), "get tacos", TodoItemStatus.Now);
            var expectedAfterItem = beforeItem with { Status = TodoItemStatus.Waiting };
            var actual = cycler.ProvideNextStatusFrom(beforeItem);
            Assert.Equal(expectedAfterItem, actual);
        }
        [Fact]
        public void CanChangeTheStatusFromWaitingToCompleted()
        {
            IProvideStatusCycling cycler = new StatusCycler();
            var beforeItem = new TodoListItemResponseModel(Guid.NewGuid(), "get tacos", TodoItemStatus.Waiting);
            var expectedAfterItem = beforeItem with { Status = TodoItemStatus.Completed };
            var actual = cycler.ProvideNextStatusFrom(beforeItem);
            Assert.Equal(expectedAfterItem, actual);
        }
        [Fact]
        public void CanChangeTheStatusFromCompletedToLater()
        {
            IProvideStatusCycling cycler = new StatusCycler();
            var beforeItem = new TodoListItemResponseModel(Guid.NewGuid(), "get tacos", TodoItemStatus.Completed);
            var expectedAfterItem = beforeItem with { Status = TodoItemStatus.Later };
            var actual = cycler.ProvideNextStatusFrom(beforeItem);
            Assert.Equal(expectedAfterItem, actual);
        }

    }
}