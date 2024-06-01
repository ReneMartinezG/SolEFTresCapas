using DataPersonas;
using DataPersonas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesPersonas
{
    public class BusEstadoCivil
    {
        DatEstadoCivil datosEstadoCivil = new DatEstadoCivil();

        public List<EstadoCivil> Obtener()
        {
            return datosEstadoCivil.ObtenerTodos();
        }
    }
}
