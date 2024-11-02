using System;
using System.Collections.Generic;

namespace DevHelper.Data.Models;

public partial class ArquivoProblema
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Referencia { get; set; } = null!;

    public int? ProblemaId { get; set; }

    public virtual Problema? Problema { get; set; }
}
