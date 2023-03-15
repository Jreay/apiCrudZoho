using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using ApiMVC.Models;

namespace ApiMVC.Controllers
{
    public class EmpresaController : Controller
    {
        String api = "https://localhost:7052/api/ApiNegocios/";
        // GET: PlataformaController

        async Task<List<Empresa>> actividades()
        {
            List<Empresa> auxiliar = new List<Empresa>();
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(api);
                HttpResponseMessage mensaje = await cliente.GetAsync("actividades");
                if (mensaje.IsSuccessStatusCode)
                {
                    string respuesta = await mensaje.Content.ReadAsStringAsync();
                    auxiliar = JsonConvert.DeserializeObject<List<Empresa>>(respuesta);
                }
            }
            return auxiliar;
        }

        async Task<List<Empresa>> solicitudes()
        {
            List<Empresa> auxiliar = new List<Empresa>();
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(api);
                HttpResponseMessage mensaje = await cliente.GetAsync("solicitudes");
                if (mensaje.IsSuccessStatusCode)
                {
                    string respuesta = await mensaje.Content.ReadAsStringAsync();
                    auxiliar = JsonConvert.DeserializeObject<List<Empresa>>(respuesta);
                }
            }
            return auxiliar;
        }


        public async Task<IActionResult> Index()
        {
            ViewBag.solicitudes = await solicitudes();
            ViewBag.titulo = "Agregar";
            ViewBag.actividades = new SelectList(await actividades(), "idEmpresa", "nombre");
            //envio un nuevo Seller, GET
            return View(await Task.Run(() => new Empresa()));
        }
        public async Task<IActionResult> Edit(string id)
        {
            ViewBag.solicitudes = await solicitudes();
            ViewBag.actividades = new SelectList(await actividades(), "idEmpresa", "nombre");
            ViewBag.titulo = "Actualizar";
            Empresa reg = new Empresa();
            foreach (Empresa bean in ViewBag.solicitudes)
            {
                if ((bean.idEmpresa + "") == id)
                {
                    reg = bean;
                    break;
                }
            }
            return View("Index", await Task.Run(() => reg));
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(Empresa reg)
        {
            string mensaje = "";
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(api);
                //convierto a reg en un cadena json de formato utf-8 y media: applicacion/json
                StringContent contenido = new StringContent(
                JsonConvert.SerializeObject(reg), System.Text.Encoding.UTF8, "application/json");
                //ejecutar el Put
                HttpResponseMessage respuesta = await cliente.PostAsync("registrar", contenido);
                if (respuesta.IsSuccessStatusCode)
                {
                    mensaje = await respuesta.Content.ReadAsStringAsync();
                }
            }
            //al finalizar refrescar la pagina
            ViewBag.mensaje = mensaje;
            ViewBag.solicitudes = await solicitudes();
            ViewBag.actividades = new SelectList(await actividades(), "idEmpresa", "nombre");
            ViewBag.titulo = "Agregar";
            //envio un nuevo Seller, GET
            return View("Index", await Task.Run(() => new Empresa()));
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar(Empresa reg)
        {
            string mensaje = "";
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(api);
                //convierto a reg en un cadena json de formato utf-8 y media: applicacion/json
                StringContent contenido = new StringContent(
                JsonConvert.SerializeObject(reg), System.Text.Encoding.UTF8, "application/json");
                //ejecutar el Put
                HttpResponseMessage respuesta = await cliente.PutAsync("actualizarEmpresa", contenido);
                if (respuesta.IsSuccessStatusCode)
                {
                    mensaje = await respuesta.Content.ReadAsStringAsync();
                }
            }
            //al finalizar refrescar la pagina
            ViewBag.mensaje = mensaje;
            ViewBag.solicitudes = await solicitudes();
            ViewBag.actividades = new SelectList(await actividades(), "idEmpresa", "nombre");
            ViewBag.titulo = "Agregar";
            //envio un nuevo Seller, GET
            return View("Index", await Task.Run(() => new Empresa()));
        }
    }
}
