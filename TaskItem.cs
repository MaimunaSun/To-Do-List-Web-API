namespace TaskManagerAPI.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int Priority { get; set; }
        public bool IsCompleted { get; set; }

        public void Update(string title, string description, DateTime dueDate, int priority)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Priority = priority;
        }

        public void MarkAsCompleted()
        {
            IsCompleted = true;
        }
    }
}
