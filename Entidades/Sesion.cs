using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_Implementacion.Clases
{
    class Sesion
    {
        private DateTime fechaHoraInicio;
        private DateTime fechaHoraFin;
        private Usuario usuario;

        public Sesion(Usuario usu)
        {
            fechaHoraInicio = DateTime.Now;
            usuario = usu;
        }

        public PersonalCientifico ObtenerCientificoLogueado()
        {
            return usuario.ObtenerCientifico();
        }
    }
}
