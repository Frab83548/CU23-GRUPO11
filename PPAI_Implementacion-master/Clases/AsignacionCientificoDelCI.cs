using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_Implementacion.Clases
{
    class AsignacionCientificoDelCI
    {
        private DateTime fechaDesde;
        private DateTime fechaHasta;
        private PersonalCientifico personalCientifico;
        private List<Turno> turnos;

        public AsignacionCientificoDelCI(DateTime desde, PersonalCientifico cientifico)
        {
            fechaDesde = desde;
            personalCientifico = cientifico;
            turnos = new List<Turno>();
        }

        public bool EsCientificoActivo()
        {
            return fechaHasta == null;
        }

        public void SetTurno(Turno turnoNuevo)
        {
            turnos.Add(turnoNuevo);
        }

        public string ObtenerMail()
        {
            return personalCientifico.ObtenerMail();
        }

        public bool EsCientifico(PersonalCientifico cientifico)
        {
            return cientifico == personalCientifico;
        }
    }
}
