using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI_Implementacion.Clases;

namespace PPAI_Implementacion.ObtencionDatos
{
    class RecursoTecnologicoDao
    {
        private static RecursoTecnologicoDao instancia;
        private List<RecursoTecnologico> todosRecursos;
        public RecursoTecnologicoDao()
        {
            TipoRecursoTecnologicoDao daoTipos = TipoRecursoTecnologicoDao.Instancia();
            List<TipoRecursoTecnologico> listaTipos = daoTipos.ObtenerTiposRT();

            todosRecursos = new List<RecursoTecnologico>();

            //listas para turnos
            List<Turno>[] listasTurnoParaRecursos = new List<Turno>[10];
            for (int i = 0; i < 10; i++)
            {
                listasTurnoParaRecursos[i] = new List<Turno>();
            }

            //asignar turnos a cada lista
            List<Turno> listaTodosTurnos = TurnoDao.Instancia().GetTurnos();
            int turnoNro = 0;
            int recNro = 0;
            for (int i = 0; i < listaTodosTurnos.Count; i++)
            {
                listasTurnoParaRecursos[recNro].Add(listaTodosTurnos[i]);
                
                //Mandar turno a lista de cada recurso
                turnoNro++;
                if(turnoNro == 3)
                {
                    recNro++;
                    turnoNro = 0;
                }

                if (recNro == 10)
                    recNro = 0;
            }

            todosRecursos.Add(new RecursoTecnologico(1, listaTipos[2], ModeloMarcaDao.Instancia().ObtenerListaModelos()[0], ListaEstadoDisponible(), listasTurnoParaRecursos[0]));
            todosRecursos.Add(new RecursoTecnologico(2, listaTipos[1], ModeloMarcaDao.Instancia().ObtenerListaModelos()[4], ListaEstadoInicioMantenimiento(), listasTurnoParaRecursos[1]));
            todosRecursos.Add(new RecursoTecnologico(3, listaTipos[2], ModeloMarcaDao.Instancia().ObtenerListaModelos()[8], ListaEstadoDisponible(), listasTurnoParaRecursos[2]));
            todosRecursos.Add(new RecursoTecnologico(4, listaTipos[3], ModeloMarcaDao.Instancia().ObtenerListaModelos()[7], ListaEstadoDisponible(), listasTurnoParaRecursos[3]));
            todosRecursos.Add(new RecursoTecnologico(5, listaTipos[0], ModeloMarcaDao.Instancia().ObtenerListaModelos()[6], ListaEstadoMantenimiento(), listasTurnoParaRecursos[4]));
            todosRecursos.Add(new RecursoTecnologico(6, listaTipos[0], ModeloMarcaDao.Instancia().ObtenerListaModelos()[1], ListaEstadoDisponible(), listasTurnoParaRecursos[5]));
            todosRecursos.Add(new RecursoTecnologico(7, listaTipos[4], ModeloMarcaDao.Instancia().ObtenerListaModelos()[9], ListaEstadoInicioMantenimiento(), listasTurnoParaRecursos[6]));
            todosRecursos.Add(new RecursoTecnologico(8, listaTipos[1], ModeloMarcaDao.Instancia().ObtenerListaModelos()[2], ListaEstadoMantenimiento(), listasTurnoParaRecursos[7]));
            todosRecursos.Add(new RecursoTecnologico(9, listaTipos[2], ModeloMarcaDao.Instancia().ObtenerListaModelos()[3], ListaEstadoDisponible(), listasTurnoParaRecursos[8]));
            todosRecursos.Add(new RecursoTecnologico(10, listaTipos[0], ModeloMarcaDao.Instancia().ObtenerListaModelos()[5], ListaEstadoDisponible(), listasTurnoParaRecursos[9]));
            
        }

        public List<CambioEstadoRT> ListaEstadoDisponible()
        {
            List<CambioEstadoRT> disponible = new List<CambioEstadoRT>();
            disponible.Add(new CambioEstadoRT(new DateTime(2022, 5, 3), EstadoDao.Instancia().GetEstados()[0]));
            return disponible;
        }
        public List<CambioEstadoRT> ListaEstadoMantenimiento()
        {
            List<CambioEstadoRT> mantenimiento = new List<CambioEstadoRT>();
            mantenimiento.Add(new CambioEstadoRT(new DateTime(2022, 5, 3), EstadoDao.Instancia().GetEstados()[1]));
            return mantenimiento;
        }
        public List<CambioEstadoRT> ListaEstadoInicioMantenimiento()
        {
            List<CambioEstadoRT> inicioMant = new List<CambioEstadoRT>();
            inicioMant.Add(new CambioEstadoRT(new DateTime(2022, 5, 3), EstadoDao.Instancia().GetEstados()[2]));
            return inicioMant;
        }

        public static RecursoTecnologicoDao Instancia()
        {
            if (instancia == null)
                instancia = new RecursoTecnologicoDao();

            return instancia;
        }

        public List<RecursoTecnologico> ObtenerRecursos()
        {
            return todosRecursos;
        }
    }
}
