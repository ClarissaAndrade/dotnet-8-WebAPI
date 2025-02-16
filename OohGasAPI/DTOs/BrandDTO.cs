namespace OohGasAPI.DTOs
{
    public class BrandDTO
    {
        public int Id { get; set; }
        public string NickName { get; set; } = string.Empty;
        public string LegalName { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int Distance { get; set; } = 0;
    }
}
