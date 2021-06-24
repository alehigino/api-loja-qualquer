namespace LojaQualquer.WebApi.Domain.Models.Request
{
    public class ProductFilterRequest
    {
        public string Name { get; set; }
        public int? Category { get; set; }
    }
}