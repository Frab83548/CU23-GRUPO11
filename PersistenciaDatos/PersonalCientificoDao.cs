using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI_Implementacion.Clases;

namespace PPAI_Implementacion.ObtencionDatos
{
    class PersonalCientificoDao
    {
        private static PersonalCientificoDao instancia;
        private List<PersonalCientifico> listaCientificos;

        public PersonalCientificoDao()
        {
            listaCientificos = new List<PersonalCientifico>();
            listaCientificos.Add(new PersonalCientifico("c@gmail.com", "3888436452", UsuarioDao.Instancia().GetUsuarios()[0]));
            listaCientificos.Add(new PersonalCientifico("s@gmail.com", "387584602", UsuarioDao.Instancia().GetUsuarios()[1]));
            listaCientificos.Add(new PersonalCientifico("d@gmail.com", "351852452", UsuarioDao.Instancia().GetUsuarios()[2]));
        }

        public static PersonalCientificoDao Instancia()
        {
            if (instancia == null)
                instancia = new PersonalCientificoDao();

            return instancia;
        }

        public PersonalCientifico ObtenerCientifico(Usuario usuario)
        {
            return listaCientificos[0];
        }
    }
}
