using System;
using System.Collections.Generic;

namespace miniERPMVC.Models;

public partial class NotasFiscai
{
    public int IdNota { get; set; }

    public DateTime? DataEmissao { get; set; }

    public int? IdCliente { get; set; }

    public int? IdProduto { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Produto? IdProdutoNavigation { get; set; }
}
