using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Queries.DTOs
{
    public class ProductsDTO
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string NombreLaboratorio { get; set; }
        public bool Estado { get; set; }
    }
}
