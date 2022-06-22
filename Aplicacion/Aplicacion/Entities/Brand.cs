using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicacion.Entities
{
    public class Brand
    {
        public Brand()
        {
            this.Products = new HashSet<Products>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Photo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Products> Products { get; set; }
    }
}