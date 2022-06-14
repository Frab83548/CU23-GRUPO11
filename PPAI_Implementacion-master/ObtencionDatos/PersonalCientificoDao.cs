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
            listaCientificos.Add(new PersonalCientifico("a@utn.frc.edu.ar", "351836452", UsuarioDao.Instancia().GetUsuarios()[0]));
            listaCientificos.Add(new PersonalCientifico("b@gmail.com", "351584602", UsuarioDao.Instancia().GetUsuarios()[1]));
            listaCientificos.Add(new PersonalCientifico("c@hotmail.com.ar", "3548752452", UsuarioDao.Instancia().GetUsuarios()[2]));
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
