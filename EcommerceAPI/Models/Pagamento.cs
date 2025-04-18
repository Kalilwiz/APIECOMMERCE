using System;
using System.Collections.Generic;

namespace EcommerceAPI.Models;

public partial class Pagamento
{
    public int IdPagamento { get; set; }

    public int IdPedido { get; set; }

    public string FormaPagamento { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime Data { get; set; }

    public virtual Pedido? IdPedidoNavigation { get; set; }
}
