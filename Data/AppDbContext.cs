using app.console.Entity;
using Microsoft.EntityFrameworkCore;

namespace app.console.Data;
internal class AppDbContext:DbContext{
    public AppDbContext()
    {
        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseInMemoryDatabase("TaskDb");
    }
    public DbSet<MyTask>? Tasks { get;set;}
}