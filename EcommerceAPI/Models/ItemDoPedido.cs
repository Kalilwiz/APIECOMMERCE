using System;
using System.Collections.Generic;

namespace EcommerceAPI.Models;

public partial class ItemDoPedido
{
    public int IdItemDoPedido { get; set; }

    public int? IdPedido { get; set; }

    public int? IdProduto { get; set; }

    public int? Quantidade { get; set; }

    public virtual ItemDoPedido? IdPedidoNavigation { get; set; }

    public virtual ItemDoPedido? IdProdutoNavigation { get; set; }
}
