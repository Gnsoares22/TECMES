using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TECMES.Models
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {
            //se um objeto ja existe não considera o mesmo na proxima migração
            Database.EnsureCreated();
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Maquina> Maquina { get; set; }
        public DbSet<OrdemProducao> OrdemProducao { get; set; }
        public DbSet<OrdemProducaoSequencia> OrdemProducaoSequencia { get; set; }
        public DbSet<OrdemProducaoStatus> OrdemProducaoStatus { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Cliente> Cliente { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);

        }
    }
}
