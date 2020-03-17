using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ap1_SegundoP_ErissonSilverio.Entidades
{
    public class LlamadaDetalle
    {
        [Key]

        public int Id { get; set; }
        public int LlamdaId { get; set; }
        public string Problema { get; set; }
        public string Solucion { get; set; }


        public LlamadaDetalle()
        {


        }

        public LlamadaDetalle(int id, int llamdaId, string problema, string solucion)
        {
            Id = id;
            LlamdaId = llamdaId;
            Problema = problema;
            Solucion = solucion;
        }
    }
}
