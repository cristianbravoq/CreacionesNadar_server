namespace CreacionesNadar_server.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    /// <summary>
    /// Declaramos una clase para modelar la tabla elaborada en la base de datos
    /// Es importante que los nombres coincidan con los nombres asignados en la base de datos
    /// para que esta reconozca los valores que se consultan
    /// </summary>
    public partial class tbl_Users
    {
        [Key]
        public int id_DataUser { get; set; }

        [StringLength(30)]
        public string Nombre { get; set; }

        [StringLength(10)]
        public string DocumentoId { get; set; }

        public int? Edad { get; set; }

        [StringLength(30)]
        public string Domicilio { get; set; }

        [StringLength(15)]
        public string Telefono { get; set; }

        [StringLength(30)]
        public string Correo { get; set; }
    }
}
