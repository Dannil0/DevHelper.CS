using System;
using System.Collections.Generic;

namespace DevHelper.Data.Models;

public partial class ProblemaUsuario
{
    public int UsuarioId { get; set; }

    public int ProblemaId { get; set; }

    public DateTime DataEnvio { get; set; }

    public virtual Problema Problema { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
