using System;
using System.Collections.Generic;

namespace EcommerceAPI.Models;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public DateOnly? DataPedido { get; set; }

    public string? Status { get; set; }

    public decimal? ValorTotal { get; set; }

    public int? IdCliente { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual ICollection<ItemDoPedido> ItemDoPedidos { get; set; } = new List<ItemDoPedido>();

    public virtual ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();
}
