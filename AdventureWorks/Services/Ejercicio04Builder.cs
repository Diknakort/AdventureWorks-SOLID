using AdventureWorks.Models;

namespace AdventureWorks.Services
{
    public class Ejercicio04Builder : IProductSpecification, IProductoQuery
    {
        private IProductSpecification especificacion;

        public Ejercicio04Builder()
        {
            IProductSpecification PorInicio = new NameComienzaSpecification() // En mayusculas al usar ToUpper() en el Servicio.
            {
                letras = ["A","B","C"]
            };
            IProductSpecification PorColor = new ProductColorSpecification() // En mayusculas al usar ToUpper() en el Servicio.
            {
                colores = ["RED", "BLACK", "BLUE"]
            };
            IProductSpecification PorPrecio = new ListPriceSpecification() // En el servicio indica >= Price
            {
                Price = 3
            };

            //    Aumentar el numero de especificaciones: 
            IProductSpecification and01 = new AndSpecification() // Primera unión de Specifications
            {
                Spec1 = PorInicio,
                Spec2 = PorColor,
            }; 
            especificacion = new AndSpecification() // añado otra especificación al " And / or / not :Specifications "
            {
                Spec1 = and01,
                Spec2 = PorPrecio
                //Spec3 = PorPrecio // se podría añadir nuevas specs añadiendo al And / or / not Specifications nuevos " && SpecX "
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
