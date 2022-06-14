using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI_Implementacion.ObtencionDatos;

namespace PPAI_Implementacion.Clases
{
    class PersonalCientifico
    {
        private int legajo;
        private string nombre;
        private string apellido;
        private int numeroDocumento;
        private string correoElectronicoInstitucional;
        private string correoElectronicoPersonal;
        private string telefonoCelular;
        private Usuario usuario;

        public PersonalCientifico(string email, string telefono, Usuario usu)
        {
            correoElectronicoInstitucional = email;
            telefonoCelular = telefono;
            usuario = usu;
        }

        public string ObtenerMail()
        {
            return correoElectronicoInstitucional;
        }

        public string ObtenerTelefono()
        {
            return telefonoCelular;
        }

        public CentroDeInvestigacion ObtenerCI()
        {
            return CentroInvestigacionDao.Instancia().ObtenerCIDeCientifico(this);
        }
    }
}
