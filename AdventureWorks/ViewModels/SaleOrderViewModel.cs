namespace AdventureWorks.ViewModels
{
    public class SaleOrderViewModel
    {
        public int Id { get; set; }
        public List<ClaseHija> Hijas { get; set; }
        public int CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string ColorProducto { get; set; }

    }

    public class ClaseHija
    {
        public int Id { get; set; }
        public int CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string ColorProducto { get; set; }
    }
}
