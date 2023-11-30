using System;
using System.Collections.Generic;

namespace miniERPMVC.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? NomeCliente { get; set; }

    public string? EnderecoCliente { get; set; }

    public string? TelefoneCliente { get; set; }

    public virtual ICollection<NotasFiscai> NotasFiscais { get; set; } = new List<NotasFiscai>();
}
