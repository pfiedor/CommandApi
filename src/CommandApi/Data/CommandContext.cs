using Microsoft.EntityFrameworkCore;
using CommandApi.Models;

namespace CommandApi.Data;

public class CommandContext : DbContext
{
    public CommandContext(DbContextOptions options) : base(options)
    {
    }

    protected CommandContext()
    {
    }

    public DbSet<Command> CommandItems { get; set; }
}