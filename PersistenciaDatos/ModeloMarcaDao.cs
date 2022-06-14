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
            listaModelos.Add(new Modelo("A0000"));
            listaModelos.Add(new Modelo("A0001"));
            listaModelos.Add(new Modelo("BB008"));
            listaModelos.Add(new Modelo("BBC25"));
            listaModelos.Add(new Modelo("CGS87"));
            listaModelos.Add(new Modelo("AGHAA"));
            listaModelos.Add(new Modelo("TSX8A"));
            listaModelos.Add(new Modelo("LO97A"));
            listaModelos.Add(new Modelo("AAVHA"));
            listaModelos.Add(new Modelo("ALO5A"));
            listaModelos.Add(new Modelo("823TA"));

            listaMarcas = new List<Marca>();
            listaMarcas.Add(new Marca("Yamaha", new List<Modelo>() { listaModelos[0], listaModelos[5], listaModelos[7] }));
            listaMarcas.Add(new Marca("Berling", new List<Modelo>() { listaModelos[8], listaModelos[2], listaModelos[6], listaModelos[9] }));
            listaMarcas.Add(new Marca("Fourier", new List<Modelo>() { listaModelos[1], listaModelos[3], listaModelos[4] }));
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
