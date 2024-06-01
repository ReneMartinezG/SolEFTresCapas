using DataPersonas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPersonas
{
    public class DatEstadoCivil
    {
        Generacion24Entities dataBase = new Generacion24Entities();

        public List<EstadoCivil> ObtenerTodos()
        {
            List<EstadoCivil> lista = dataBase.EstadoCivil.OrderBy(x => x.Nombre).ToList();
            dataBase.Dispose();

            return lista;
        }
    }
}
