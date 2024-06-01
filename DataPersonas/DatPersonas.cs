using DataPersonas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPersonas
{
    public class DatPersonas
    {

        //1. instanciar entity frammework para tener acceso a la info de las tablas de SQL SERVER

        Generacion24Entities dataBase = new Generacion24Entities();

        public List<Personas> ObtenerTodos()
        {
            List<Personas> lista = dataBase.Personas.Include("Sexo").Include("EstadoCivil").ToList();
            dataBase.Dispose();

            return lista;
        }

        public Personas ObtenerPersona(int id)
        {
            Personas persona = dataBase.Personas.Where(x=> x.id == id).FirstOrDefault();

            //Personas personaID = dataBase.Personas.Find(id); //Busquedas con llaves primarias
            dataBase.Dispose();

            return persona;
        }

        public void Agregar (Personas persona)
        {
            persona.FechaRegistro = DateTime.Now;
            dataBase.Personas.Add(persona);
            dataBase.SaveChanges();
            dataBase.Dispose();
        }

        public void AgregarSP(Personas persona)
        {
            dataBase.spAgregarPersona(persona.Nombre, persona.Paterno, persona.Edad, persona.Salario, persona.SexoId, persona.EstadoCivilId);
            dataBase.Dispose();
        }

        public void Editar(Personas persona)
        {
            Personas personaRecuperado = dataBase.Personas.Find(persona.id);
            persona.FechaRegistro = personaRecuperado.FechaRegistro;

            dataBase.Personas.AddOrUpdate(persona);
            dataBase.SaveChanges();
            dataBase.Dispose();
        }

        public void Eliminar(Personas persona)
        {
            Personas personaElimar = dataBase.Personas.Find(persona.id);
           
            dataBase.Personas.Remove(personaElimar);
            dataBase.SaveChanges();
            dataBase.Dispose();
        }



        public List<Personas> Buscar(string texto)
        {
            List<Personas> lista = dataBase.Personas.Include("Sexo").Include("EstadoCivil")
                .Where(x => x.Nombre.Contains(texto) || x.Paterno.Contains(texto) || x.Sexo.Nombre.Contains(texto)).ToList();
            dataBase.Dispose();

            return lista;
        }

        public Personas ValidarNombreRepetido(string nombre)
        {
            Personas persona = dataBase.Personas.Where(x => x.Nombre == nombre).FirstOrDefault();
            dataBase.Dispose();
            return persona;
        }


        public Personas ValidarNombreRepetidoEditar(string nombre,int id)
        {
            Personas persona = dataBase.Personas.Where(x => x.Nombre == nombre && x.id != id).FirstOrDefault();
            dataBase.Dispose();
            return persona;
        }


    }
}
