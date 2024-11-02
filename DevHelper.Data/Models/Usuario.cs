using System;
using System.Collections.Generic;

namespace DevHelper.Data.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public string? Biografia { get; set; }

    public virtual ICollection<ProblemaUsuario> ProblemaUsuarios { get; set; } = new List<ProblemaUsuario>();

    public virtual ICollection<SolucaoUsuario> SolucaoUsuarios { get; set; } = new List<SolucaoUsuario>();
}
