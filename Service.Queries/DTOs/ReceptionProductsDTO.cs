using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Queries.DTOs
{
    public class ReceptionProductsDTO
    {
        public int Id { get; set; }
        public DateTime FechaHoraRecepcion { get; set; }
        public int ProductoId { get; set; }
        public int ProveedorId { get; set; }
        public int Factura { get; set; }
        public int Cantidad { get; set; }
        public int Lote { get; set; }
        public string RegistroInvima { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }
    }
}
