using Microsoft.EntityFrameworkCore;

public class AccountDbContext : DbContext
{
    public DbSet<AccountDbSet> Accounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Todo(박용환) : 외부에서 주입할 방법 찾기
        optionsBuilder.UseSqlServer("localhost");
    }
}