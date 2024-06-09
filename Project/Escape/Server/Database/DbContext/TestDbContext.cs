using Microsoft.EntityFrameworkCore;

public class TestDbContext : DbContext
{
    public DbSet<TestDbSet> Tests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Todo(박용환) : 외부에서 주입할 방법 찾기
        optionsBuilder.UseSqlServer("localhost");
    }
}