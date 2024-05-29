using AdventureWorks.Models;

namespace AdventureWorks.Services
{
    public interface IProductSpecification
    {
        bool isValid(Product _producto);
    }
}
