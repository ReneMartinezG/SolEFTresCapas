using DataPersonas;
using DataPersonas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesPersonas
{
    public class BusSexo
    {
        DatSexo datosSexo = new DatSexo();

        public List<Sexo> Obtener()
        {
            return datosSexo.ObtenerTodos();
        }
    }
}
