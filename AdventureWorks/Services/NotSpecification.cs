using AdventureWorks.Models;

namespace AdventureWorks.Services
{
    public class NotSpecification : IProductSpecification
    {
        public IProductSpecification especificacion { get; set; }

        public bool isValid(Product _producto)
        {
            return !especificacion.isValid(_producto);
        }
    }
}
