using AdventureWorks.Models;

namespace AdventureWorks.Services
{
    public class SubCategoriaSpecificacion : IProductSpecification
    {
        public int[] subcategorias { get; set; }
        public bool isValid(Product _producto)
        {
            return subcategorias.Any(x => x == _producto.ProductSubcategoryId);
        }
    }
}
