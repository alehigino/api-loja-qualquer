namespace LojaQualquer.WebApi.Domain.Models.Response
{
    public class ProductResponse
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Category { get; set; }
        public decimal Price { get; set; }
    }
}