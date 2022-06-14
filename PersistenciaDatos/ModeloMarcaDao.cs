using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI_Implementacion.Clases;

namespace PPAI_Implementacion.ObtencionDatos
{
    class ModeloMarcaDao
    {
        private static ModeloMarcaDao instancia;
        List<Modelo> listaModelos;
        List<Marca> listaMarcas;

        public ModeloMarcaDao()
        {
            listaModelos = new List<Modelo>();
            listaModelos.Add(new Modelo("823RF"));
            listaModelos.Add(new Modelo("CC001"));
            listaModelos.Add(new Modelo("BB008"));
            listaModelos.Add(new Modelo("XXDF5"));
            listaModelos.Add(new Modelo("DFS87"));
            listaModelos.Add(new Modelo("HAADS"));
            listaModelos.Add(new Modelo("TSX8A"));
            listaModelos.Add(new Modelo("LO10A0"));
            listaModelos.Add(new Modelo("AASDF"));
            listaModelos.Add(new Modelo("ALO5A"));
            listaModelos.Add(new Modelo("823TA"));

            listaMarcas = new List<Marca>();
            listaMarcas.Add(new Marca("Toshiba", new List<Modelo>() { listaModelos[0], listaModelos[5], listaModelos[7] }));
            listaMarcas.Add(new Marca("SONY", new List<Modelo>() { listaModelos[8], listaModelos[2], listaModelos[6], listaModelos[9] }));
            listaMarcas.Add(new Marca("LG", new List<Modelo>() { listaModelos[1], listaModelos[3], listaModelos[4] }));
        }

        public static ModeloMarcaDao Instancia()
        {
            if (instancia == null)
                instancia = new ModeloMarcaDao();

            return instancia;
        }

        public Marca ObtenerMarcaDeModelo(Modelo modelo)
        {
            Marca result = null;
            foreach (Marca marca in listaMarcas)
            {
                if (marca.GetModelos().Contains(modelo))
                {
                    result = marca;
                    break;
                }
            }

            return result;
        }

        public List<Modelo> ObtenerListaModelos()
        {
            return listaModelos;
        }
    }
}
