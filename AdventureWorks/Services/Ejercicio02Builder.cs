using AdventureWorks.Models;

namespace AdventureWorks.Services
{
    public class Ejercicio02Builder : IProductSpecification, IProductoQuery
    {
        private IProductSpecification especificacion;

        public Ejercicio02Builder()
        {
            IProductSpecification PorColor = new ProductColorSpecification()
            {
                colores = ["RED"]
            };
            IProductSpecification PorTerminacion = new NameTerminaSpecification()
            {
                letras = ["A", "E", "I", "O", "U", "X"]
            };
            IProductSpecification NoPorTerminacion = new NotSpecification()
            {
                especificacion = PorTerminacion
            };
            IProductSpecification PorSubCategoria = new SubCategoriaSpecificacion()
            {
                subcategorias = [2]
            };
            IProductSpecification NotPorSubCategoria = new NotSpecification()
            {
                especificacion = PorSubCategoria
            };
            IProductSpecification And01 = new AndSpecification()
            {
                Spec1 = PorColor,
                Spec2 = NoPorTerminacion
            };
            this.especificacion = new AndSpecification()
            {
                Spec1 = And01,
                Spec2 = NotPorSubCategoria
        };
    }

    public IEnumerable<Product> dameProductos(IEnumerable<Product> products)
    {
        return products.Where(x => especificacion.isValid(x)).OrderBy(x => x.Name);
    }
    public bool isValid(Product _producto)
    {
        return especificacion.isValid(_producto);
    }
}
}

