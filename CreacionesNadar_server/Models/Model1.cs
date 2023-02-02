using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CreacionesNadar_server.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<tbl_Users> tbl_Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_Users>()
                .Property(e => e.Nombre)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Users>()
                .Property(e => e.DocumentoId)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Users>()
                .Property(e => e.Domicilio)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Users>()
                .Property(e => e.Telefono)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Users>()
                .Property(e => e.Correo)
                .IsFixedLength();
        }
    }
}
