using AdventureWorks.Models;

namespace AdventureWorks.Services
{
    public class OrSpecification : IProductSpecification
    {
        public IProductSpecification Spec1 { get; set; }
        public IProductSpecification Spec2 { get; set; }

        public bool isValid(Product _producto)
        {
            return Spec1.isValid(_producto) || Spec2.isValid(_producto);
        }
    }
}
