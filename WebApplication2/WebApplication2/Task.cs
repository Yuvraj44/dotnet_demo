namespace WebApplication2
{
    public class Task
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }

        public Task(int id, int name, DateTime dueDate, bool isCompleted)
        {
            Id = id;
            Name = name;
            DueDate = dueDate;
            IsCompleted = isCompleted;
        }
    }
}
