using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio.Entities
{
    public class OrdenDetallada
    {

        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string NombreCompleto { get; set; }
        public string Producto { get; set; }
        public DateTime Order_date { get; set; }
        public decimal Order_total { get; set; }

    }
}