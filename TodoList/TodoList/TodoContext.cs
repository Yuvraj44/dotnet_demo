using Microsoft.EntityFrameworkCore;

namespace TodoList
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options): base (options)
        {

        }

        public DbSet<TaskItem> Tasks { get; set;  }



    }
}
