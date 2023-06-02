using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Model
{
    public class Provider
    {
        [Key]
        public int ProveedorId { get; set; }
        public int NumIdentificacion { get; set; }
        public string TipoIdentificacion { get; set; }
        public string NombreRazonSocial { get; set; }
        public string Direccion { get; set; }
        public string NombreContacto { get; set; }
        public string CelularContacto { get; set; }
        public bool Estado { get; set; }
    }
}
