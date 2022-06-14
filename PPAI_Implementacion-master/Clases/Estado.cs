using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_Implementacion.Clases
{
    class Estado
    {
        private string nombre;
        private string descripcion;
        private string ambito;
        private bool esReservable;
        private bool esCancelable;

        public Estado(string nom, string desc, string amb, bool reser, bool canc)
        {
            nombre = nom;
            descripcion = desc;
            ambito = amb;
            esReservable = reser;
            esCancelable = canc;
        }

        public string GetNombre()
        {
            return nombre;
        }

        public bool EsReservable()
        {
            return esReservable;
        }

        public string MostrarEstado()
        {
            return GetNombre();
        }

        public bool EsAmbitoTurno()
        {
            return ambito == "Turno";
        }

        public bool EsReservado()
        {
            return nombre == "Reservado";
        }

    }
}
