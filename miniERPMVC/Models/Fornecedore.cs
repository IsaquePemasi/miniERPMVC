using System;
using System.Collections.Generic;

namespace miniERPMVC.Models;

public partial class Fornecedore
{
    public int IdFornecedor { get; set; }

    public string? NomeFornecedor { get; set; }

    public string? EnderecoFornecedor { get; set; }

    public string? TelefoneFornecedor { get; set; }

    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
