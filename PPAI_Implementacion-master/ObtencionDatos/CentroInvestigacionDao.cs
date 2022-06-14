using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI_Implementacion.Clases;

namespace PPAI_Implementacion.ObtencionDatos
{
    class CentroInvestigacionDao
    {
        private static CentroInvestigacionDao instancia;
        private List<CentroDeInvestigacion> listaCentros;

        public CentroInvestigacionDao()
        {
            listaCentros = new List<CentroDeInvestigacion>();
            List<RecursoTecnologico> recursos = RecursoTecnologicoDao.Instancia().ObtenerRecursos();

            listaCentros.Add(new CentroDeInvestigacion("UTN-FRC", 8, new List<AsignacionCientificoDelCI>(), new List<RecursoTecnologico>() { recursos[1], recursos[5], recursos[3], recursos[9] }));
            listaCentros.Add(new CentroDeInvestigacion("Observatorio", 24, new List<AsignacionCientificoDelCI>(), new List<RecursoTecnologico>() { recursos[0], recursos[2], recursos[8] }));
            listaCentros.Add(new CentroDeInvestigacion("Ciencias Quimicas", 10, new List<AsignacionCientificoDelCI>(), new List<RecursoTecnologico>() { recursos[4], recursos[6], recursos[7] }));
        }

        public static CentroInvestigacionDao Instancia()
        {
            if (instancia == null)
                instancia = new CentroInvestigacionDao();

            return instancia;
        }

        public CentroDeInvestigacion ObtenerCIDeRecurso(RecursoTecnologico recurso)
        {
            CentroDeInvestigacion result = null;
            foreach (CentroDeInvestigacion centro in listaCentros)
            {
                if (centro.GetRecursos().Contains(recurso))
                {
                    result = centro;
                    break;
                }
            }

            return result;
        }

        public CentroDeInvestigacion ObtenerCIDeCientifico(PersonalCientifico cientifico)
        {
            CentroDeInvestigacion result = null;
            foreach (CentroDeInvestigacion centro in listaCentros)
            {
                foreach (AsignacionCientificoDelCI asignacion in centro.GetCientificos())
                {
                    if(asignacion.EsCientificoActivo() && asignacion.EsCientifico(cientifico))
                    {
                        result = centro;
                        break;
                    }
                }
                if (result != null)
                    break;
            }

            return result;
        }
    }
}
