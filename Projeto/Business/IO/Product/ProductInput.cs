using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.IO.Product
{
   public class ProductInput
    {
        public string Sku { get; private set; }
        public string Name { get; private set; }
        public bool Status { get; set; }
        public DateTime? DateRegister { get; private set; }
        public string Description { get; private set; }
        [Column(TypeName = "CLOB")]
        public string Image { get; private set; }

    }
}
