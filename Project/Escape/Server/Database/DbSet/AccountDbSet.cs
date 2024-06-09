using Microsoft.EntityFrameworkCore;

public class AccountDbSet
{
    // Todo(박용환) : long으로 변경할 것.
    public long Id { get; set; }
    public string Name { get; set; }
}
