using System;
using System.Collections.Generic;

namespace DevHelper.Data.Models;

public partial class ArquivoSolucao
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Referencia { get; set; } = null!;

    public int? SolucaoId { get; set; }

    public virtual Solucao? Solucao { get; set; }
}
