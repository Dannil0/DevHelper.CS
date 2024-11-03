using System;
using System.Collections.Generic;

namespace DevHelper.Data.Model;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public string? Biografia { get; set; }

    public virtual ICollection<Problema> Problemas { get; set; } = new List<Problema>();

    public virtual ICollection<Solucao> Solucaos { get; set; } = new List<Solucao>();
}
