using AdventureWorks.Models;

namespace AdventureWorks.Services
{
    public class NameComienzaSpecification : IProductSpecification
    {
        public string[] letras { set; get; }

        public bool isValid(Product _producto)
        {
            return letras.Any(x => _producto.Name.ToUpper().StartsWith(x));
        }
    }
}
