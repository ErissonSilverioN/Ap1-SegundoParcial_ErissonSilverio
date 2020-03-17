using Ap1_SegundoP_ErissonSilverio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ap1_SegundoP_ErissonSilverio.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Llamadas> llamadas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(@"Data Source = Llamada.db");
        }
    }
}
