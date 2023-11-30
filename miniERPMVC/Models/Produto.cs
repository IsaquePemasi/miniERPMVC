using System;
using System.Collections.Generic;

namespace miniERPMVC.Models;

public partial class Produto
{
    public int IdProduto { get; set; }

    public string? NomeProduto { get; set; }

    public string? DescricaoProduto { get; set; }

    public decimal? PrecoProduto { get; set; }

    public int? IdFornecedor { get; set; }

    public virtual Fornecedore? IdFornecedorNavigation { get; set; }

    public virtual ICollection<NotasFiscai> NotasFiscais { get; set; } = new List<NotasFiscai>();
}
