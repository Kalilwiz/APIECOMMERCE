using System;
using System.Collections.Generic;

namespace EcommerceAPI.Models;

public partial class Pagamento
{
    public int IdPagamento { get; set; }

    public string? FormaPagamento { get; set; }

    public string? Status { get; set; }

    public DateOnly? Data { get; set; }

    public int? IdPedido { get; set; }

    public virtual Pedido? IdPedidoNavigation { get; set; }
}
