namespace ToDoListApp.Test
{
    public class TaskManagerTests
    {
        [Fact]
        public void AddTask_ShouldAddNewTask()
        {
            // Arrange
            var taskManager = new TaskManager();

            // Act
            taskManager.AddTask("Test Task", "This is a test", DateTime.Now.AddDays(1), 1);

            // Assert
            var tasks = taskManager.GetTasks().ToList();
            Assert.Single(tasks);
            Assert.Equal("Test Task", tasks[0].Title);
        }

        [Fact]
        public void MarkTaskCompleted_ShouldSetIsCompletedToTrue()
        {
            // Arrange
            var taskManager = new TaskManager();
            var dueDate = DateTime.Now.AddDays(1);
            taskManager.AddTask("Test Task", "This is a test", dueDate, 1);
            var task = taskManager.GetTasks().First();

            // Act
            taskManager.MarkTaskCompleted(task.Id);

            // Assert
            var updatedTask = taskManager.GetTasks().FirstOrDefault(t => t.Id == task.Id);
            Assert.NotNull(updatedTask);
            Assert.True(updatedTask!.IsCompleted);
        }


        [Fact]
        public void RemoveTask_ShouldRemoveTask()
        {
            // Arrange
            var taskManager = new TaskManager();
            taskManager.AddTask("Test Task", "This is a test", DateTime.Now.AddDays(1), 1);
            var task = taskManager.GetTasks().First();  // 🛠️ Get the real ID

            // Act
            taskManager.RemoveTask(task.Id);

            // Assert
            var tasks = taskManager.GetTasks();
            Assert.Empty(tasks);
        }

        [Fact]
        public void UpdateTask_ShouldModifyTaskDetails()
        {
            // Arrange
            var taskManager = new TaskManager();
            taskManager.AddTask("Old Title", "Old Description", DateTime.Now.AddDays(1), 1);
            var task = taskManager.GetTasks().First();  // 🛠️ Get the real ID

            // Act
            taskManager.UpdateTask(task.Id, "New Title", "New Description", DateTime.Now.AddDays(2), 2);

            // Assert
            var updatedTask = taskManager.GetTasks().First(t => t.Id == task.Id);
            Assert.Equal("New Title", updatedTask.Title);
            Assert.Equal("New Description", updatedTask.Description);
            Assert.Equal(2, updatedTask.Priority);
        }
    }
}
