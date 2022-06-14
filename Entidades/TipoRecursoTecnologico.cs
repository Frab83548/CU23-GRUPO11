using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_Implementacion.Clases
{
    class TipoRecursoTecnologico
    {
        private string nombre;
        private string descripcion;

        public TipoRecursoTecnologico(string nom, string desc)
        {
            nombre = nom;
            descripcion = desc;
        }

        public string GetNombre()
        {
            return nombre;
        }

        public string MostrarTipoRT()
        {
            return GetNombre();
        }
    }
}
