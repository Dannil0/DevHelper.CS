using System;
using System.Collections.Generic;

namespace DevHelper.Data.Models;

public partial class Problema
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public virtual ICollection<ArquivoProblema> ArquivoProblemas { get; set; } = new List<ArquivoProblema>();

    public virtual ICollection<ProblemaUsuario> ProblemaUsuarios { get; set; } = new List<ProblemaUsuario>();
}
