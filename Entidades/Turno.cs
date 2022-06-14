using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_Implementacion.Clases
{
    class Turno
    {
        private DateTime fechaGeneracion;
        private string diaSemana;
        private DateTime fechaHoraInicio;
        private DateTime fechaHoraFin;
        private List<CambioEstadoTurno> cambioEstadoTurno;

        public Turno(DateTime desde, DateTime hasta, List<CambioEstadoTurno> cambiosEstado)
        {
            fechaHoraInicio = desde;
            fechaHoraFin = hasta;
            cambioEstadoTurno = cambiosEstado;
        }

        public bool EsPosteriorAFechaActual(DateTime fechaActual)
        {
            return fechaHoraInicio > fechaActual;
        }

        public string[] MostrarTurno()
        {
            string[] datos = new string[3];
            datos[0] = fechaHoraInicio.ToString();
            datos[1] = fechaHoraFin.ToString();
            datos[2] = UltimoCambioEstado().MostrarEstado();

            return datos;
        }

        public void ReservarTurno(Estado estado)
        {
            UltimoCambioEstado().SetFechaHoraHasta(DateTime.Now);
            CambioEstadoTurno nuevoCambio = new CambioEstadoTurno(DateTime.Now, estado);
            cambioEstadoTurno.Add(nuevoCambio);
        }

        public DateTime GetFechaInicio()
        {
            return fechaHoraInicio;
        }

        public CambioEstadoTurno UltimoCambioEstado()
        {
            CambioEstadoTurno ultimo = null;

            foreach (CambioEstadoTurno cambio in cambioEstadoTurno)
            {
                if (cambio.EsActual())
                {
                    ultimo = cambio;
                    break;
                }
            }

            return ultimo;
        }
    }
}
