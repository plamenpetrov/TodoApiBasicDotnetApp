using Xunit;
using Moq;
using TodoApi.Models;
using TodoApi.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Testing 
{

    public class ToDoItemsControllerTest
    {
        [Fact]
        public void Get_To_Do_Items_Test()
        {
            TodoItem toDoItem = new TodoItem() { Id=1, Name="Test todo", IsComplete=false};
 
            var mockSet = new Mock<DbSet<TodoItem>>();

            var mockContext = new Mock<TodoContext>();
            mockContext.Setup(m => m.TodoItems).Returns(mockSet.Object);

            var systemUnderTest = new TodoItemsController(mockContext.Object);

            var actual = systemUnderTest.GetTodoItems();

            Assert.Equal(actual.Id, toDoItem.Id);
        }
    }

}