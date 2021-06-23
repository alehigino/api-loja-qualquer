namespace LojaQualquer.WebApi.Domain.Entities
{
    public enum CategoryEnum
    {
        Food = 0,
        Drink = 1,
        Others = 2
    }

    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public CategoryEnum Category { get; set; }
        public decimal Price { get; set; }
    }
}