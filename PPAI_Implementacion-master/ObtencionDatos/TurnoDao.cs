using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI_Implementacion.Clases;

namespace PPAI_Implementacion.ObtencionDatos
{
    class TurnoDao
    {
        private static TurnoDao instancia;
        private List<Turno> listaTurnos;

        public TurnoDao()
        {
            listaTurnos = new List<Turno>();
            for (int i = 0; i < 14; i++)
            {
                //Rec1
                listaTurnos.Add(new Turno(new DateTime(2022, 6, 9 + i, 22, 0, 0), new DateTime(2022, 6, 9 + i, 23, 30, 0), new List<CambioEstadoTurno>() { new CambioEstadoTurno(DateTime.Now.AddDays(-21), EstadoDao.Instancia().GetEstados()[3])}));
                listaTurnos.Add(new Turno(new DateTime(2022, 6, 10 + i, 0, 0, 0), new DateTime(2022, 6, 10 + i, 1, 30, 0), new List<CambioEstadoTurno>() { new CambioEstadoTurno(DateTime.Now.AddDays(-21), EstadoDao.Instancia().GetEstados()[3]) }));
                listaTurnos.Add(new Turno(new DateTime(2022, 6, 10 + i, 2, 0, 0), new DateTime(2022, 6, 10 + i, 3, 30, 0), new List<CambioEstadoTurno>() { new CambioEstadoTurno(DateTime.Now.AddDays(-21), EstadoDao.Instancia().GetEstados()[3]) }));
                //Rec2                                              i                                       i
                listaTurnos.Add(new Turno(new DateTime(2022, 6, 9 + i, 15, 0, 0), new DateTime(2022, 6, 9 + i, 16, 30, 0), new List<CambioEstadoTurno>() { new CambioEstadoTurno(DateTime.Now.AddDays(-21), EstadoDao.Instancia().GetEstados()[4]) }));
                listaTurnos.Add(new Turno(new DateTime(2022, 6, 9 + i, 17, 0, 0), new DateTime(2022, 6, 9 + i, 18, 30, 0), new List<CambioEstadoTurno>() { new CambioEstadoTurno(DateTime.Now.AddDays(-21), EstadoDao.Instancia().GetEstados()[3]) }));
                listaTurnos.Add(new Turno(new DateTime(2022, 6, 9 + i, 19, 0, 0), new DateTime(2022, 6, 9 + i, 20, 30, 0), new List<CambioEstadoTurno>() { new CambioEstadoTurno(DateTime.Now.AddDays(-21), EstadoDao.Instancia().GetEstados()[3]) }));
                //Rec3                                              i                                       i
                listaTurnos.Add(new Turno(new DateTime(2022, 6, 9 + i, 23, 0, 0), new DateTime(2022, 6, 10 + i, 1, 0, 0), new List<CambioEstadoTurno>() { new CambioEstadoTurno(DateTime.Now.AddDays(-21), EstadoDao.Instancia().GetEstados()[3]) }));
                listaTurnos.Add(new Turno(new DateTime(2022, 6, 10 + i, 1, 30, 0), new DateTime(2022, 6, 10 + i, 3, 30, 0), new List<CambioEstadoTurno>() { new CambioEstadoTurno(DateTime.Now.AddDays(-21), EstadoDao.Instancia().GetEstados()[3]) }));
                listaTurnos.Add(new Turno(new DateTime(2022, 6, 10 + i, 4, 0, 0), new DateTime(2022, 6, 10 + i, 6, 0, 0), new List<CambioEstadoTurno>() { new CambioEstadoTurno(DateTime.Now.AddDays(-21), EstadoDao.Instancia().GetEstados()[3]) }));
                //Rec4                                              i                                       i
                listaTurnos.Add(new Turno(new DateTime(2022, 6, 9 + i, 16, 0, 0), new DateTime(2022, 6, 9 + i, 17, 30, 0), new List<CambioEstadoTurno>() { new CambioEstadoTurno(DateTime.Now.AddDays(-21), EstadoDao.Instancia().GetEstados()[3]) }));
                listaTurnos.Add(new Turno(new DateTime(2022, 6, 9 + i, 18, 0, 0), new DateTime(2022, 6, 9 + i, 19, 30, 0), new List<CambioEstadoTurno>() { new CambioEstadoTurno(DateTime.Now.AddDays(-21), EstadoDao.Instancia().GetEstados()[3]) }));
                listaTurnos.Add(new Turno(new DateTime(2022, 6, 9 + i, 20, 0, 0), new DateTime(2022, 6, 9 + i, 21, 30, 0), new List<CambioEstadoTurno>() { new CambioEstadoTurno(DateTime.Now.AddDays(-21), EstadoDao.Instancia().GetEstados()[4]) }));
                //Rec5                                              i                                       i
                listaTurnos.Add(new Turno(new DateTime(2022, 6, 9 + i, 15, 0, 0), new DateTime(2022, 6, 9 + i, 16, 30, 0), new List<CambioEstadoTurno>() { new CambioEstadoTurno(DateTime.Now.AddDays(-21), EstadoDao.Instancia().GetEstados()[3]) }));
                listaTurnos.Add(new Turno(new DateTime(2022, 6, 9 + i, 17, 0, 0), new DateTime(2022, 6, 9 + i, 18, 30, 0), new List<CambioEstadoTurno>() { new CambioEstadoTurno(DateTime.Now.AddDays(-21), EstadoDao.Instancia().GetEstados()[3]) }));
                listaTurnos.Add(new Turno(new DateTime(2022, 6, 9 + i, 19, 0, 0), new DateTime(2022, 6, 9 + i, 20, 30, 0), new List<CambioEstadoTurno>() { new CambioEstadoTurno(DateTime.Now.AddDays(-21), EstadoDao.Instancia().GetEstados()[3]) }));
                //Rec6                                              i                                       i
                listaTurnos.Add(new Turno(new DateTime(2022, 6, 9 + i, 16, 0, 0), new DateTime(2022, 6, 9 + i, 17, 30, 0), new List<CambioEstadoTurno>() { new CambioEstadoTurno(DateTime.Now.AddDays(-21), EstadoDao.Instancia().GetEstados()[3]) }));
                listaTurnos.Add(new Turno(new DateTime(2022, 6, 9 + i, 18, 0, 0), new DateTime(2022, 6, 9 + i, 19, 30, 0), new List<CambioEstadoTurno>() { new CambioEstadoTurno(DateTime.Now.AddDays(-21), EstadoDao.Instancia().GetEstados()[3]) }));
                listaTurnos.Add(new Turno(new DateTime(2022, 6, 9 + i, 20, 0, 0), new DateTime(2022, 6, 9 + i, 21, 30, 0), new List<CambioEstadoTurno>() { new CambioEstadoTurno(DateTime.Now.AddDays(-21), EstadoDao.Instancia().GetEstados()[3]) }));
                //Rec7                                              i                                       i
                listaTurnos.Add(new Turno(new DateTime(2022, 6, 9 + i, 16, 0, 0), new DateTime(2022, 6, 9 + i, 17, 0, 0), new List<CambioEstadoTurno>() { new CambioEstadoTurno(DateTime.Now.AddDays(-21), EstadoDao.Instancia().GetEstados()[3]) }));
                listaTurnos.Add(new Turno(new DateTime(2022, 6, 9 + i, 17, 0, 0), new DateTime(2022, 6, 9 + i, 17, 30, 0), new List<CambioEstadoTurno>() { new CambioEstadoTurno(DateTime.Now.AddDays(-21), EstadoDao.Instancia().GetEstados()[5]) }));
                listaTurnos.Add(new Turno(new DateTime(2022, 6, 9 + i, 18, 0, 0), new DateTime(2022, 6, 9 + i, 19, 0, 0), new List<CambioEstadoTurno>() { new CambioEstadoTurno(DateTime.Now.AddDays(-21), EstadoDao.Instancia().GetEstados()[3]) }));
                //Rec8                                              i                                       i
                listaTurnos.Add(new Turno(new DateTime(2022, 6, 9 + i, 16, 0, 0), new DateTime(2022, 6, 9 + i, 17, 30, 0), new List<CambioEstadoTurno>() { new CambioEstadoTurno(DateTime.Now.AddDays(-21), EstadoDao.Instancia().GetEstados()[3]) }));
                listaTurnos.Add(new Turno(new DateTime(2022, 6, 9 + i, 18, 0, 0), new DateTime(2022, 6, 9 + i, 19, 30, 0), new List<CambioEstadoTurno>() { new CambioEstadoTurno(DateTime.Now.AddDays(-21), EstadoDao.Instancia().GetEstados()[3]) }));
                listaTurnos.Add(new Turno(new DateTime(2022, 6, 9 + i, 20, 0, 0), new DateTime(2022, 6, 9 + i, 21, 30, 0), new List<CambioEstadoTurno>() { new CambioEstadoTurno(DateTime.Now.AddDays(-21), EstadoDao.Instancia().GetEstados()[3]) }));
                //Rec9                                              i                                       i
                listaTurnos.Add(new Turno(new DateTime(2022, 6, 9 + i, 23, 0, 0), new DateTime(2022, 6, 10 + i, 1, 0, 0), new List<CambioEstadoTurno>() { new CambioEstadoTurno(DateTime.Now.AddDays(-21), EstadoDao.Instancia().GetEstados()[3]) }));
                listaTurnos.Add(new Turno(new DateTime(2022, 6, 10 + i, 1, 30, 0), new DateTime(2022, 6, 10 + i, 3, 30, 0), new List<CambioEstadoTurno>() { new CambioEstadoTurno(DateTime.Now.AddDays(-21), EstadoDao.Instancia().GetEstados()[3]) }));
                listaTurnos.Add(new Turno(new DateTime(2022, 6, 10 + i, 4, 0, 0), new DateTime(2022, 6, 10 + i, 6, 0, 0), new List<CambioEstadoTurno>() { new CambioEstadoTurno(DateTime.Now.AddDays(-21), EstadoDao.Instancia().GetEstados()[3]) }));
                //Rec10                                             i                                       i
                listaTurnos.Add(new Turno(new DateTime(2022, 6, 9 + i, 16, 0, 0), new DateTime(2022, 6, 9 + i, 17, 0, 0), new List<CambioEstadoTurno>() { new CambioEstadoTurno(DateTime.Now.AddDays(-21), EstadoDao.Instancia().GetEstados()[3]) }));
                listaTurnos.Add(new Turno(new DateTime(2022, 6, 9 + i, 17, 0, 0), new DateTime(2022, 6, 9 + i, 17, 30, 0), new List<CambioEstadoTurno>() { new CambioEstadoTurno(DateTime.Now.AddDays(-21), EstadoDao.Instancia().GetEstados()[5]) }));
                listaTurnos.Add(new Turno(new DateTime(2022, 6, 9 + i, 18, 0, 0), new DateTime(2022, 6, 9 + i, 19, 0, 0), new List<CambioEstadoTurno>() { new CambioEstadoTurno(DateTime.Now.AddDays(-21), EstadoDao.Instancia().GetEstados()[3]) }));
            }
        }

        public static TurnoDao Instancia()
        {
            if (instancia == null)
                instancia = new TurnoDao();

            return instancia;
        }

        public List<Turno> GetTurnos()
        {
            return listaTurnos;
        }

    }
}
