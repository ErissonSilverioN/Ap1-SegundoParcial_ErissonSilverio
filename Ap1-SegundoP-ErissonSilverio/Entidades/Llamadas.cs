using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ap1_SegundoP_ErissonSilverio.Entidades
{
    public class Llamadas
    {
        [Key]
        public int LlamadaId { get; set; }
        public string Descripcion { get; set; }
        public string Problema { get; set; }
        public string Solucion { get; set; }

        [ForeignKey("LlamadaId")]
        public virtual List<LlamadaDetalle> LlamadasDetalles { get; set; } = new List<LlamadaDetalle>();

        public Llamadas()
        {
            LlamadaId = 0;
            Descripcion = string.Empty;
            Problema = string.Empty;
            Solucion = string.Empty;
        }

    }
}
