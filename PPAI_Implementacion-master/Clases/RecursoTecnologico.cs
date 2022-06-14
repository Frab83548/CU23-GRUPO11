using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI_Implementacion.ObtencionDatos;

namespace PPAI_Implementacion.Clases
{
    class RecursoTecnologico
    {
        private int numeroRT;
        private DateTime fechaAlta;
        private TipoRecursoTecnologico tipoRecurso;
        private Modelo modeloDelRT;
        private List<HorarioRT> disponibilidad;
        private List<CambioEstadoRT> cambioEstadoRT;
        private List<Turno> turnos;

        public RecursoTecnologico(int nro, TipoRecursoTecnologico tipo, Modelo mod, List<CambioEstadoRT> estados, List<Turno> listaTurnos)
        {
            numeroRT = nro;
            tipoRecurso = tipo;
            modeloDelRT = mod;
            cambioEstadoRT = estados;
            turnos = listaTurnos;
        }

        public bool EsDeTipoRTSeleccionado(TipoRecursoTecnologico tipo)
        {
            if (tipo == null)
                return true;
            else
                return tipo.MostrarTipoRT() == tipoRecurso.MostrarTipoRT();
        }

        public bool EsActivo()
        {
            return UltimoCambioEstado().EsReservable();
        }

        public string[] MostrarDatosRT()
        {
            string[] datos = new string[5];     //0: NroInventario, 1: CentroInvest, 2: Modelo, 3: Marca, 4: Estado
            datos[0] = GetNumeroRT().ToString();
            datos[4] = UltimoCambioEstado().MostrarEstado();
            datos[1] = ObtenerCI().GetNombre();
            string[] marcaModelo = MostrarMarcaYModelo();   //0: Modelo, 1: Marca
            datos[2] = marcaModelo[0];
            datos[3] = marcaModelo[1];

            return datos;
        }

        public int GetNumeroRT()
        {
            return numeroRT;
        }

        public CentroDeInvestigacion ObtenerCI()
        {
            return CentroInvestigacionDao.Instancia().ObtenerCIDeRecurso(this);
        }

        public string[] MostrarMarcaYModelo()
        {
            return modeloDelRT.MostrarModelo();
        }

        public int EsCientificoDelCI(PersonalCientifico cientifico)
        {
            return ObtenerCI().EsCientificoActivo(cientifico);
        }

        public List<Tuple<Turno, string[]>> MostrarTurnos(DateTime fechaActual)
        {
            List<Tuple<Turno, string[]>> listaDatosTurnos = new List<Tuple<Turno, string[]>>();
            foreach (Turno turno in turnos)
            {
                if (turno.EsPosteriorAFechaActual(fechaActual))
                {
                    Tuple<Turno, string[]> tuplaTurno = new Tuple<Turno, string[]>(turno, turno.MostrarTurno());
                    listaDatosTurnos.Add(tuplaTurno);
                }
            }

            return listaDatosTurnos;
        }

        public void RegistrarReservaTurno(Turno turnoSeleccionado, Estado estadoReservado, PersonalCientifico cientificoLogueado)
        {
            turnoSeleccionado.ReservarTurno(estadoReservado);
            ObtenerCI().AsignarTurno(cientificoLogueado, turnoSeleccionado);
        }

        public List<Turno> GetTurnos()
        {
            return turnos;
        }

        public TipoRecursoTecnologico GetTipo()
        {
            return tipoRecurso;
        }

        public CambioEstadoRT UltimoCambioEstado()
        {
            CambioEstadoRT ultimo = null;

            foreach (CambioEstadoRT cambio in cambioEstadoRT)
            {
                if (cambio.EsActual())
                {
                    ultimo = cambio;
                    break;
                }
            }

            return ultimo;
        }
    }
}
