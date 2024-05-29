using AdventureWorks.Models;

namespace AdventureWorks.Services
{
    public class Ejercicio01Builder : IProductSpecification, IProductoQuery
    {
        private IProductSpecification especificacion;
        public Ejercicio01Builder()
        {
            IProductSpecification PorColor = new ProductColorSpecification()
            {
                colores = ["RED", "GREEN"]
            };
            IProductSpecification PorDinero = new ListPriceSpecification()
            {
                Price = 1
            };
            especificacion = new AndSpecification()
            {
                Spec1 = PorColor,
                Spec2 = PorDinero
            };
        }

        public IEnumerable<Product> dameProductos(IEnumerable<Product> products)
        {
            return products.Where(x => isValid(x)).OrderBy(x => x.SafetyStockLevel);
        }

        public bool isValid(Product _producto)
        {
            return especificacion.isValid(_producto);
        }
    }
}
