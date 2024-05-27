using AlmoxarifadoDomain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data
{
    public  class ContextSQL : DbContext 
    {

        public ContextSQL(DbContextOptions<ContextSQL> options) : base(options)
        {   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NotaFiscal>().HasKey(n => n.ID_NOTA);
            modelBuilder.Entity<ItensNota>().HasKey(i => i.ITEM_NUM);
            modelBuilder.Entity<Requisicao>().HasKey(r => r.ID_REQ);
            modelBuilder.Entity<ItensRequisicao>().HasKey(i => i.NUM_ITEM);
        }

        public DbSet<NotaFiscal> Nota_Fiscal { get; set; }
        public DbSet<ItensNota> Itens_Nota { get; set; }
        public DbSet<Requisicao> Requisicao { get; set; }
        public DbSet<ItensRequisicao> Itens_Req { get; set; }
    }
}
