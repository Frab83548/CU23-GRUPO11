using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI_Implementacion.ObtencionDatos;
using PPAI_Implementacion.Clases;
using PPAI_Implementacion.Interfaz;

namespace PPAI_Implementacion.Gestor
{
    class GestorRegistrarReservaTurnoRT
    {
        private PantallaRegistrarReservaTurnoRT pantallaReserva;
        private TipoRecursoTecnologico tipoRTSeleccionado;
        private List<RecursoTecnologico> listaRecursos;
        private RecursoTecnologico rtSeleccionado;
        private List<Tuple<Turno, string[]>> listaTurnosPosibles;
        private List<Tuple<Turno, string[]>> listaTurnosFecha;
        private List<Turno> listaTurnos;
        private Turno turnoSeleccionado;
        private PersonalCientifico cientificoLogueado;
        private string mail;
        private DateTime fechaHoraActual;
        private bool confirmacionReserva;

        private TipoRecursoTecnologicoDao tipoRecursoTecnologicoDao;
        private RecursoTecnologicoDao recursoTecnologicoDao;
        private EstadoDao estadoDao;

        public GestorRegistrarReservaTurnoRT(PantallaRegistrarReservaTurnoRT pantalla)
        {
            pantallaReserva = pantalla;
            tipoRecursoTecnologicoDao = TipoRecursoTecnologicoDao.Instancia();
            recursoTecnologicoDao = RecursoTecnologicoDao.Instancia();
            estadoDao = EstadoDao.Instancia();
        }

        public void RegistrarReservaTurnoRT()
        {
            //Obtiene Lista con los tipos de recurso
            List<string> listaTiposRT = BuscarTiposRT();
            //Añade la opcion de TODOS al inicio
            listaTiposRT.Insert(0, "TODOS");
            pantallaReserva.SolicitarSeleccionTipoRT(listaTiposRT);
        }

        public List<string> BuscarTiposRT()
        {
            List<TipoRecursoTecnologico> listaTipos = tipoRecursoTecnologicoDao.ObtenerTiposRT();
            List<string> listaNombres = new List<string>();
            foreach (TipoRecursoTecnologico tipo in listaTipos)
            {
                listaNombres.Add(tipo.MostrarTipoRT());
            }

            return listaNombres;
        }

        public void TomarSeleccionTipoRT(string seleccionado)
        {
            tipoRTSeleccionado = TipoRecursoTecnologicoDao.Instancia().ObtenerTipoRecurso(seleccionado);
            ObtenerRTActivoYDelTipo();
        }

        public void ObtenerRTActivoYDelTipo()
        {
            //Obtener todos los recursos
            List<RecursoTecnologico> listaTodosRecursos = recursoTecnologicoDao.ObtenerRecursos();
            listaRecursos = new List<RecursoTecnologico>();
            List<string[]> listaRT = new List<string[]>();

            //Filtrar todos los recursos para obtener los activos y del tipo seleccionado
            foreach (RecursoTecnologico recurso in listaTodosRecursos)
            {
                if(recurso.EsDeTipoRTSeleccionado(tipoRTSeleccionado) && recurso.EsActivo())
                {
                    listaRecursos.Add(recurso);
                    listaRT.Add(recurso.MostrarDatosRT());
                }
            }

            OrdenarYAgruparRTPorCI(listaRT);
            pantallaReserva.SolicitarSeleccionRT(listaRT);
        }

        public void OrdenarYAgruparRTPorCI(List<string[]> listaDatos)
        {
            listaDatos.Sort((x, y) => x[1].CompareTo(y[1]));
            listaRecursos.Sort((x, y) => x.ObtenerCI().GetNombre().CompareTo(y.ObtenerCI().GetNombre()));
        }

        public void TomarSeleccionRT(int indexSeleccionado)
        {
            rtSeleccionado = listaRecursos[indexSeleccionado];
            ObtenerTurnosReservablesRTSeleccionado();
        }

        public void ObtenerTurnosReservablesRTSeleccionado()
        {
            List<Turno> listaTodosTurnos = rtSeleccionado.GetTurnos();
            cientificoLogueado = ObtenerCientificoLogueado();
            int hrsAntelacion = ValidarPertenenciaCI(cientificoLogueado);
            ObtenerFechaHoraActual();
            //Mostrar turnos primero
            listaTurnosPosibles = rtSeleccionado.MostrarTurnos(fechaHoraActual.AddHours(hrsAntelacion));
            
            AgruparYOrdenarTurnos();

            List<string[]> listaTurnosPorDia = DeterminarDisponibilidadPorFecha(fechaHoraActual);
            pantallaReserva.SolicitarSeleccionTurno(listaTurnosPorDia);
        }

        public PersonalCientifico ObtenerCientificoLogueado()
        {
            return UsuarioDao.Instancia().GetSesionActual().ObtenerCientificoLogueado();
        }

        public int ValidarPertenenciaCI(PersonalCientifico cientifico)
        {
            return rtSeleccionado.EsCientificoDelCI(cientifico);
        }

        public void ObtenerFechaHoraActual()
        {
            fechaHoraActual = DateTime.Now;
        }

        public void AgruparYOrdenarTurnos()
        {
            listaTurnosPosibles.Sort((x, y) => x.Item1.GetFechaInicio().CompareTo(y.Item1.GetFechaInicio()));
        }

        
        public List<string[]> DeterminarDisponibilidadPorFecha(DateTime fecha)
        {
            listaTurnosFecha = listaTurnosPosibles.FindAll(turno => turno.Item1.GetFechaInicio().Date == fecha.Date);
            List<string[]> datosTurnos = new List<string[]>();
            foreach (Tuple<Turno, string[]> turno in listaTurnosFecha)
            {
                datosTurnos.Add(turno.Item2);
            }

            return datosTurnos;
        }
        

        public void TomarSeleccionTurno(int indexSeleccionado)
        {
            turnoSeleccionado = listaTurnosFecha[indexSeleccionado].Item1;
            pantallaReserva.SolicitarConfirmacionReservaRT(rtSeleccionado.MostrarDatosRT(), rtSeleccionado.GetTipo().GetNombre(), turnoSeleccionado.MostrarTurno());
        }

        public void TomarConfirmacionReservaRT(bool mail, bool wsp)
        {
            GenerarReservaRTSeleccionado(mail, wsp);
        }

        public void GenerarReservaRTSeleccionado(bool boolMail, bool wsp)
        {
            //Poner turno en reservado
            Estado estadoReservado = ObtenerEstadoReservado();
            rtSeleccionado.RegistrarReservaTurno(turnoSeleccionado, estadoReservado, cientificoLogueado);

            //Notificar a cientifico
            mail = ObtenerMailCientifico();
            if(boolMail)
                GenerarMail(mail);

            if (wsp)
                GenerarWhatsapp(cientificoLogueado.ObtenerTelefono());

            FinCU();
        }

        public void GenerarMail(string email)
        {
            new InterfazMailReserva().EnviarNotificacionMail(email);
        }

        public void GenerarWhatsapp(string telefono)
        {
            new InterfazWhatsappReserva().EnviarNotificacionWhatsapp(telefono);
        }

        public Estado ObtenerEstadoReservado()
        {
            List<Estado> estados = estadoDao.GetEstados();
            List<Estado> estadosAmbitoTurno = new List<Estado>();
            Estado reservado = null;
            foreach (Estado estado in estados)
            {
                if (estado.EsAmbitoTurno())
                    estadosAmbitoTurno.Add(estado);
            }

            foreach (Estado estado in estadosAmbitoTurno)
            {
                if(estado.EsReservado())
                {
                    reservado = estado;
                    break;
                }
            }
            return reservado;
        }

        public string ObtenerMailCientifico()
        {
            return cientificoLogueado.ObtenerMail();
        }

        public void FinCU()
        {
            pantallaReserva.MensajeCUFin();
        }
    }
}
