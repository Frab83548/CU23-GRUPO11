using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PPAI_Implementacion.Clases;

namespace PPAI_Implementacion.Interfaz
{
    public partial class PantallaRegistrarReservaTurnoRT : Form
    {
        private Gestor.GestorRegistrarReservaTurnoRT gestorTurnos;
        private List<Tuple<DateTime, List<string[]>>> listaTurnosPorDia;

        public PantallaRegistrarReservaTurnoRT()
        {
            InitializeComponent();
            gestorTurnos = new Gestor.GestorRegistrarReservaTurnoRT(this);

            dgvRecursos.AutoGenerateColumns = false;
            dgvHorasTurnos.AutoGenerateColumns = false;
        }

        public void OpcionRegistrarReservarDeRT()
        {
            HabilitarPantalla();
            gestorTurnos.RegistrarReservaTurnoRT();
        }

        public void HabilitarPantalla()
        {
            this.Show();
        }

        public void SolicitarSeleccionTipoRT(List<string> listaTiposRT)
        {
            cbxTipoRecurso.Enabled = true;
            btnTipoRecurso.Enabled = true;

            cbxTipoRecurso.DataSource = listaTiposRT;
        }

        private void TomarSeleccionTipoRT(object sender, EventArgs e)
        {
            gestorTurnos.TomarSeleccionTipoRT((string)cbxTipoRecurso.SelectedItem);
        }

        public void SolicitarSeleccionRT(List<string[]> listaRT)
        {
            dgvRecursos.Enabled = true;
            btnRecurso.Enabled = true;

            dgvRecursos.DataSource = listaRT;
            
            for (int i = 0; i < listaRT.Count; i++)
            {
                dgvRecursos.Rows[i].Cells[0].Value = listaRT[i][0];
                dgvRecursos.Rows[i].Cells[1].Value = listaRT[i][1];
                dgvRecursos.Rows[i].Cells[2].Value = listaRT[i][2];
                dgvRecursos.Rows[i].Cells[3].Value = listaRT[i][3];
                dgvRecursos.Rows[i].Cells[4].Value = listaRT[i][4];

                Color colorEstado = new Color();
                switch (listaRT[i][4])
                {
                    case "Disponible":
                        colorEstado = Color.Blue;
                        break;

                    case "En Mantenimiento":
                        colorEstado = Color.LimeGreen;
                        break;

                    case "Inicio Mantenimiento Preventivo":
                        colorEstado = Color.DarkGray;
                        break;

                    default:
                        colorEstado = Color.White;
                        break;
                }
                dgvRecursos.Rows[i].Cells[4].Style.BackColor = colorEstado;
            }
        }

        private void TomarSeleccionRT(object sender, EventArgs e)
        {
            if(dgvRecursos.CurrentRow == null)
            {
                MensajeNadaSeleccionado("Seleccione un Recurso Tecnologico.");
                return;
            }
            gestorTurnos.TomarSeleccionRT(dgvRecursos.CurrentRow.Index);
        }

        public void SolicitarSeleccionTurno(List<string[]> listaTurno)
        {
            //listaTurnosPorDia = listaTurno;

            cldDiasTurnos.BackColor = Color.White;
            cldDiasTurnos.Enabled = true;
            dgvHorasTurnos.Enabled = true;
            btnTurno.Enabled = true;
        }

        private void TomarSeleccionTurno(object sender, EventArgs e)
        {
            //Mensaje informacion que no eligio nada
            if (dgvHorasTurnos.CurrentRow == null)
            {
                MensajeNadaSeleccionado("Seleccione un Turno.");
                return;
            }
            //Mensaje informacion que el turno elegido no esta disponible para reservar
            if ((string)dgvHorasTurnos.CurrentRow.Cells[1].Value != "Disponible")
            {
                MensajeNadaSeleccionado("El turno seleccionado no esta disponible para ser reservado.");
                return;
            }

            gestorTurnos.TomarSeleccionTurno(dgvHorasTurnos.CurrentRow.Index);
        }

        public void SolicitarConfirmacionReservaRT(string[] datosRecurso, string tipoRecurso, string[] datosTurno)
        {
            txtNroInventario.Text = datosRecurso[0];
            txtTipoRecurso.Text = tipoRecurso;
            txtCentroInvestigacion.Text = datosRecurso[1];
            txtModelo.Text = datosRecurso[2];
            txtMarca.Text = datosRecurso[3];

            txtFechaTurno.Text = datosTurno[0];
            txtHoraTurno.Text = datosTurno[1];

            cbxEmail.Enabled = true;
            cbxEmail.Checked = true;
            cbxWhatsapp.Enabled = true;
            btnConfirmarReserva.Enabled = true;
        }

        private void TomarConfirmacionReservaRT(object sender, EventArgs e)
        {
            //Checkea que al menos un metodo de notificacion este seleccionado
            if(!cbxEmail.Checked && !cbxWhatsapp.Checked)
            {
                MensajeNadaSeleccionado("Seleccione al menos un método de notificacion.");
                return;
            }
            gestorTurnos.TomarConfirmacionReservaRT(cbxEmail.Checked, cbxWhatsapp.Checked);
        }

        private void CancelarReservaTurno(object sender, EventArgs e)
        {
            this.Close();
        }


        private void MostrarTurnosDia(object sender, DateRangeEventArgs e)
        {
            List<string[]> datosTurnos = gestorTurnos.DeterminarDisponibilidadPorFecha(cldDiasTurnos.SelectionStart.Date);
            dgvHorasTurnos.DataSource = datosTurnos;
            for (int i = 0; i < datosTurnos.Count; i++)
            {
                string horario = datosTurnos[i][0] + " - " + datosTurnos[i][1];
                dgvHorasTurnos.Rows[i].Cells[0].Value = horario;
                dgvHorasTurnos.Rows[i].Cells[1].Value = datosTurnos[i][2];

                //Cambio color turno estado
                Color colorEstado = new Color();
                switch (datosTurnos[i][2])
                {
                    case "Disponible":
                        colorEstado = Color.Blue;
                        break;

                    case "Pendiente Confirmacion":
                        colorEstado = Color.DarkGray;
                        break;

                    case "Reservado":
                        colorEstado = Color.Firebrick;
                        break;

                    default:
                        colorEstado = Color.White;
                        break;
                }
                dgvHorasTurnos.Rows[i].Cells[1].Style.BackColor = colorEstado;
            }
        }

        private void MensajeNadaSeleccionado(string mensaje)
        {
            MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void MensajeCUFin()
        {
            MessageBox.Show("Turno registrado con éxito.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
