namespace AdventureWorks.ViewModels
{
    public class ColorViewModel
    {
        public List<ClaseProductoVenta> Hijas { get; set; }
        public string ColorProducto { get; set; }
    }

    public class ClaseProductoVenta
    {
        public int Id { get; set; }
        public int CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public int UnidadesVendidas { get; set; }
    }
}
