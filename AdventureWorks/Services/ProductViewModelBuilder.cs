using System.Data.Common;
using AdventureWorks.Models;
using AdventureWorks.ViewModels;

namespace AdventureWorks.Services
{
    public class ProductViewModelBuilder : IProductViewModelBuilder
    {
        // Se identitifica el contexto de la consulta
        private AdventureWorks2016Context _context;
        public ProductViewModelBuilder(AdventureWorks2016Context contexto)
        {
            this._context = contexto;
        }

        // Se crea una colección del atributo por el que se va a agrupar la consulta
        public List<ColorViewModel> dameProductViewModel()
        {
            var conJoin = from Sale in _context.SalesOrderDetails
                join Prod in _context.Products
                    on Sale.SalesOrderDetailId equals Prod.ProductId
                where Sale.OrderQty > 2
                select new
                {
                    Id = Prod.ProductId,
                    Nombre = Prod.Name,
                    Color = Prod.Color,
                    Cantidad = Sale.OrderQty
                };

            var agrupado = from linea in conJoin.ToList()
                group linea by linea.Color
                into g
                select g;

            List<ColorViewModel> listado = new();
            foreach (var item in agrupado)
            {
                ColorViewModel viewModel = new ColorViewModel() { ColorProducto = item.Key };
                viewModel.Hijas = new List<ClaseProductoVenta>();
                
                foreach (var ventas in item)
                {
                    ClaseProductoVenta Venta = new ClaseProductoVenta()
                    {
                        CodigoProducto = ventas.Id,
                        Id = ventas.Id,
                        NombreProducto = ventas.Nombre,
                        UnidadesVendidas = ventas.Cantidad
                    };
                    viewModel.Hijas.Add(Venta);
                }
                listado.Add(viewModel);
            }
            return listado;
        }
    }
}
