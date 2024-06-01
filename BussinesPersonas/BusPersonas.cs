using DataPersonas;
using DataPersonas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesPersonas
{
    public class BusPersonas
    {
        DatPersonas datosPersona = new DatPersonas();

        public List<Personas> ObtenerTodos()
        {
            return datosPersona.ObtenerTodos();
        }

        public void ValidarNombre(Personas persona)
        {
            Personas PersonaRepetido = datosPersona.ValidarNombreRepetido(persona.Nombre);

            if (PersonaRepetido != null)
            {
                throw new Exception($"La persona {persona.Nombre} ya existe");
            }
        }

        public void ValidarNombreEditar(Personas persona)
        {
            Personas PersonaRepetido = datosPersona.ValidarNombreRepetidoEditar(persona.Nombre,persona.id);

            if (PersonaRepetido != null)
            {
                throw new Exception($"La persona {persona.Nombre} ya existe");
            }
        }

        public void Agregar(Personas perosna)
        {
            datosPersona.Agregar(perosna);
        }

        public Personas ObtenerPersona(int id)
        {
            return datosPersona.ObtenerPersona(id);
        }

        public void Editar(Personas persona) 
        { 
             datosPersona.Editar(persona);
        }

        public void Eliminar(Personas persona)
        {
            datosPersona.Eliminar(persona);
        }

        public List<Personas> Buscar(string texto)
        {
            return datosPersona.Buscar(texto);
        }


    }
}
