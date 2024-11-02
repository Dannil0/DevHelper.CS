using System;
using System.Collections.Generic;

namespace DevHelper.Data.Models;

public partial class Solucao
{
    public int Id { get; set; }

    public string Descricao { get; set; } = null!;

    public virtual ICollection<ArquivoSolucao> ArquivoSolucaos { get; set; } = new List<ArquivoSolucao>();

    public virtual ICollection<SolucaoUsuario> SolucaoUsuarios { get; set; } = new List<SolucaoUsuario>();
}
