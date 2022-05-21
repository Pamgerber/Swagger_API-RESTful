using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class ProdContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

       // public DbSet<Categoria> Categorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server =192.168.0.104;Database=postgres;User Id=postgres;Password=74269;Persist Security Info=True");

        }

    }
}
