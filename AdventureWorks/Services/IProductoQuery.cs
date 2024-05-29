using AdventureWorks.Models;

namespace AdventureWorks.Services
{
    public interface IProductoQuery
    {
        IEnumerable<Product> dameProductos(IEnumerable<Product> products);
    }
}
