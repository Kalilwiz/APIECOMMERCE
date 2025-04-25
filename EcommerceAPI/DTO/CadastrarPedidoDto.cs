namespace EcommerceAPI.DTO
{
    public class CadastrarPedidoDto
    {
        public int IdCliente { get; set; }

        public DateOnly DataPedido { get; set; }

        public string Status { get; set; } = null!;

        public decimal? ValorTotal { get; set; }
        public List<int> Produto { get; set; }

        public List<int> Quantidades { get; set; }
    }
}
