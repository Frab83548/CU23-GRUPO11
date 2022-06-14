using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI_Implementacion.Clases;

namespace PPAI_Implementacion.ObtencionDatos
{
    class TipoRecursoTecnologicoDao
    {
        private static TipoRecursoTecnologicoDao instancia;
        private List<TipoRecursoTecnologico> tiposRecurso;

        public TipoRecursoTecnologicoDao()
        {
            List<TipoRecursoTecnologico> listaTipos = new List<TipoRecursoTecnologico>();
            listaTipos.Add(new TipoRecursoTecnologico("Microscopio", "Ver moleculas"));
            listaTipos.Add(new TipoRecursoTecnologico("Balanza", "Medir peso"));
            listaTipos.Add(new TipoRecursoTecnologico("Telescopio", "Ver espacio exterior"));
            listaTipos.Add(new TipoRecursoTecnologico("Mechero Bunsen", "Calentar"));
            listaTipos.Add(new TipoRecursoTecnologico("Pipetas", "Almacenar liquidos"));

            tiposRecurso = listaTipos;
        }

        public static TipoRecursoTecnologicoDao Instancia()
        {
            if (instancia == null)
                instancia = new TipoRecursoTecnologicoDao();

            return instancia;
        }

        public List<TipoRecursoTecnologico> ObtenerTiposRT()
        {
            return tiposRecurso;
        }
        
        public TipoRecursoTecnologico ObtenerTipoRecurso(string nombre)
        {
            TipoRecursoTecnologico tipoRT = null;
            foreach (TipoRecursoTecnologico tipo in tiposRecurso)
            {
                if(tipo.GetNombre() == nombre)
                {
                    tipoRT = tipo;
                    break;
                }
            }
            return tipoRT;
        }
        
    }
}
