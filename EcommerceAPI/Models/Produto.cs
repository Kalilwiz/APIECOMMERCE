using System;
using System.Collections.Generic;

namespace EcommerceAPI.Models;

public partial class Produto
{
    public int IdProduto { get; set; }

    public string? NomeProduto { get; set; }

    public string? Descricao { get; set; }

    public decimal? Preco { get; set; }

    public int? EstoqueDisponivel { get; set; }

    public string? CategoriaProduto { get; set; }

    public string? Imagem { get; set; }

    public virtual ICollection<ItemDoPedido> ItemDoPedidos { get; set; } = new List<ItemDoPedido>();
}
