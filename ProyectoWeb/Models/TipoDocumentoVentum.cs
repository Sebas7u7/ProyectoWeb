﻿using System;
using System.Collections.Generic;

namespace ProyectoWeb.Models;

public partial class TipoDocumentoVentum
{
    public int IdTipoDocumentoVenta { get; set; }

    public string? Descripcion { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
