using Microsoft.EntityFrameworkCore;
using Avaliacao.Models;

namespace Avaliacao.Data;

public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
    {
        
    }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<FolhaPagamento> FolhaPagamentos { get; set; }
    // Outros DbSets para suas outras entidades, se necessário.

    // Construtor para configurar a string de conexão
    
}
