namespace EcommerceAPI.DTO
{
    public class ListarClientesDto
    {
        public int IdCliente { get; set; }

        public string NomeCompleto { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Telefone { get; set; }

        public string? Endereco { get; set; }
        public DateOnly? DataCadastro { get; set; }
    }
}
