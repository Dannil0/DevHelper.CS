using System;
using System.Collections.Generic;

namespace DevHelper.Data.Models;

public partial class SolucaoUsuario
{
    public int UsuarioId { get; set; }

    public int SolucaoId { get; set; }

    public DateTime DataEnvio { get; set; }

    public virtual Solucao Solucao { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
