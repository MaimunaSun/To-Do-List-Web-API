using TaskManagerAPI.Models;
using TaskManagerAPI.Interfaces;

namespace TaskManagerAPI.Services
{
    public class TaskManager : ITaskManager
    {
        private readonly List<TaskItem> _tasks = new();
        private int _nextId = 1;

        public void AddTask(TaskItem task)
        {
            task.Id = _nextId++;
            _tasks.Add(task);
        }

        public void UpdateTask(TaskItem updatedTask)
        {
            var task = FindTaskById(updatedTask.Id);
            task.Update(updatedTask.Title, updatedTask.Description, updatedTask.DueDate, updatedTask.Priority);
        }

        public void RemoveTask(int id)
        {
            var task = FindTaskById(id);
            _tasks.Remove(task);
        }

        public void MarkTaskCompleted(int id)
        {
            var task = FindTaskById(id);
            task.MarkAsCompleted();
        }

        public IEnumerable<TaskItem> GetTasks(bool includeCompleted = true)
        {
            return includeCompleted ? _tasks : _tasks.Where(t => !t.IsCompleted);
        }

        public TaskItem FindTaskById(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                throw new KeyNotFoundException($"Task with ID {id} not found.");
            }
            return task;
        }
    }
}
