using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI_Implementacion.Clases;

namespace PPAI_Implementacion.ObtencionDatos
{
    class EstadoDao
    {
        private static EstadoDao instancia;
        private List<Estado> listaEstados;

        public EstadoDao()
        {
            listaEstados = new List<Estado>();
            listaEstados.Add(new Estado("Disponible", "Disponible para uso", "RecursoTecnologico", true, false));
            listaEstados.Add(new Estado("En Mantenimiento", "No disponible para uso", "RecursoTecnologico", true, false));
            listaEstados.Add(new Estado("Inicio Mantenimiento Preventivo", "Por iniciar mantenimiento", "RecursoTecnologico", true, false));
            listaEstados.Add(new Estado("Disponible", "Disponible para reservar", "Turno", true, false));
            listaEstados.Add(new Estado("Pendiente Confirmacion", "Pendiente de confirmar reserva", "Turno", false, true));
            listaEstados.Add(new Estado("Reservado", "turno reservado", "Turno", false, true)); 
        }

        public static EstadoDao Instancia()
        {
            if (instancia == null)
                instancia = new EstadoDao();

            return instancia;
        }

        public List<Estado> GetEstados()
        {
            return listaEstados;
        }
    }
}
