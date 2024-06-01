using DataPersonas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPersonas
{
    public class DatSexo
    {
        Generacion24Entities dataBase = new Generacion24Entities();

        public List<Sexo> ObtenerTodos()
        {
            List<Sexo> lista = dataBase.Sexo.OrderBy(x=> x.Nombre).ToList();
            dataBase.Dispose();

            return lista;
        }
    }
}
