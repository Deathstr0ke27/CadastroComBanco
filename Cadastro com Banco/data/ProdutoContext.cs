using Cadastro_com_Banco.models;
using Microsoft.EntityFrameworkCore;

namespace Cadastro_com_Banco.data
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options) {

        }

        public DbSet<ProdutoModel> ProdutoItems { get; set; }// = null!;
    }
}