using AdventureWorks.Models;
using Microsoft.Build.Logging;

namespace AdventureWorks.Services
{
    public class ProductColorSpecification : IProductSpecification
    {
        public string[] colores { get; set; }
        public bool isValid(Product producto)
        {
            if (producto.Color is not null)
                return colores.Any(producto.Color.ToUpper().Contains);
            else
                return false;
        }
    }
}
