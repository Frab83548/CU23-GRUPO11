using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_Implementacion.Clases
{
    class CambioEstadoRT
    {
        private DateTime fechaHoraDesde;
        private DateTime fechaHoraHasta;
        private Estado estado;

        public CambioEstadoRT(DateTime desde, Estado est)
        {
            fechaHoraDesde = desde;
            estado = est;
        }

        public bool EsActual()
        {
            return fechaHoraHasta == DateTime.MinValue;     //Compara con minvalue porque Datetime no permite ser null, se inicializa con valor minvalue
        }

        public void SetFechaHoraHasta(DateTime hora)
        {
            fechaHoraHasta = hora;
        }

        public bool EsReservable()
        {
            return estado.EsReservable();
        }

        public string MostrarEstado()
        {
            return estado.GetNombre();
        }
    }
}
