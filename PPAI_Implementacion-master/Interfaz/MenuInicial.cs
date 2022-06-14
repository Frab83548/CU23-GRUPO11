using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PPAI_Implementacion.ObtencionDatos;

namespace PPAI_Implementacion.Interfaz
{
    public partial class MenuInicial : Form
    {
        public MenuInicial()
        {
            InitializeComponent();
            UsuarioDao.Instancia().SetSesionActual(new Clases.Sesion(UsuarioDao.Instancia().GetUsuarios()[0]));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PantallaRegistrarReservaTurnoRT pantallaReservaTurno = new PantallaRegistrarReservaTurnoRT();
            pantallaReservaTurno.OpcionRegistrarReservarDeRT();
        }
    }
}
