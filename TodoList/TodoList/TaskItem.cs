namespace TodoList
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }

        public TaskItem(int id, string name, DateTime dueDate, bool isCompleted)
        {
            Id = id;
            Name = name;
            DueDate = dueDate;
            IsCompleted = isCompleted;
        }
    }
}
