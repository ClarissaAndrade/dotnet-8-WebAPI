namespace OohGasAPI.DTOs
{
    public class CategoryDTO
    {
        public required string Name { get; set; }
        public int? IdFather { get; set; }
    }
}
