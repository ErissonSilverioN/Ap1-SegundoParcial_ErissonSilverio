using Ap1_SegundoP_ErissonSilverio.DAL;
using Ap1_SegundoP_ErissonSilverio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ap1_SegundoP_ErissonSilverio.BLL
{
    public class LlamadasBLL
    {

        public static bool Guardar(Llamadas llamadas)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.llamadas.Add(llamadas) != null)
                    paso = db.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }


        public static bool Modificar(Llamadas llamadas)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {

                db.Database.ExecuteSqlRaw($"Delete From LLamadaDetalle Where LlamadaId = {llamadas.LlamadaId}");

                foreach (var item in llamadas.LlamadasDetalles)
                {
                    db.Entry(item).State = EntityState.Added;
                }

                db.Entry(llamadas).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }


        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = db.llamadas.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static Llamadas Buscar(int id)
        {
            Llamadas llamadas = new Llamadas();
            Contexto db = new Contexto();

            try
            {
                llamadas = db.llamadas.Include(o => o.LlamadasDetalles).Where(o => o.LlamadaId == id).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return llamadas;
        }

    }

}

