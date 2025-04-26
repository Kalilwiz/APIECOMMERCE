using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EcommerceAPI.Models;

public partial class Produto
{
    public int IdProduto { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descricao { get; set; }

    public decimal Preco { get; set; }

    public int EstoqueDisponivel { get; set; }

    public string Categoria { get; set; } = null!;

    public string? Imagem { get; set; }

    [JsonIgnore]
    public virtual ICollection<ItemDoPedido> ItemDoPedidos { get; set; } = new List<ItemDoPedido>();
}
