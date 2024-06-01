using BussinesPersonas;
using DataPersonas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEFTresCapas.Controllers
{
    public class HomeController : Controller
    {

        BusPersonas busPersona = new BusPersonas();
        BusEstadoCivil busEstadoCivil = new BusEstadoCivil();
        BusSexo busSexo = new BusSexo();

        // GET: Home
        public ActionResult Index()
        {
            List<Personas> personas = busPersona.ObtenerTodos();
            return View(personas);
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            try
            {
                List<Sexo> listaSexo = busSexo.Obtener();
                List<EstadoCivil>  listaEstadoCivil= busEstadoCivil.Obtener();

                ViewBag.SexoId = new SelectList(listaSexo,"id","Nombre");
                ViewBag.EstadoCivilId = new SelectList(listaEstadoCivil,"Id","Nombre");
                return View();
            }
            catch (Exception ex)
            {
                TempData["error"] = "Ocurrio un error. "+ex.Message;
                return RedirectToAction("Index");
            }

        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult CreatePost(Personas persona)
        {
            try
            {
                
                busPersona.ValidarNombre(persona);

                busPersona.Agregar(persona);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = "Ocurrio un error. " + ex.Message;
                return RedirectToAction("Create");
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Personas persona = busPersona.ObtenerPersona(id);

                List<Sexo> listaSexo = busSexo.Obtener();
                List<EstadoCivil> listaEstadoCivil = busEstadoCivil.Obtener();

                ViewBag.SexoId = new SelectList(listaSexo, "id", "Nombre",persona.SexoId);
                ViewBag.EstadoCivilId = new SelectList(listaEstadoCivil, "Id", "Nombre",persona.EstadoCivilId);
                return View(persona);

            }
            catch (Exception ex)
            {
                TempData["error"] = "Ocurrio un error. " + ex.Message;
                return RedirectToAction("Index");
            }
            
        }

        // POST: Home/Edit/5
        public ActionResult EditPost(Personas persona)
        {
            try
            {
                busPersona.ValidarNombreEditar(persona);
                busPersona.Editar(persona);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = "Ocurrio un error. " + ex.Message;
                //return RedirectToAction("Edit");
                return RedirectToAction("Index");
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(Personas persona)
        {
            try
            {
                busPersona.Eliminar(persona);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = "Ocurrio un error. " + ex.Message;
                return RedirectToAction("Index");
            }
        }


        public ActionResult Buscar(string buscador)
        {
            try
            {
              List<Personas> listaPersonas =  busPersona.Buscar(buscador);

                return View("Index",listaPersonas);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Ocurrio un error. " + ex.Message;
                return RedirectToAction("Index");
            }
        }

    }
}
