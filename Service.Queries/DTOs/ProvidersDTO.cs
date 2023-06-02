using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Queries.DTOs
{
    public class ProvidersDTO
    {
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
