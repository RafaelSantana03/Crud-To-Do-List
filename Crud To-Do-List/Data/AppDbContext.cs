using Crud_To_Do_List.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud_To_Do_List.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Tarefa> Tarefas { get; set; }
}
