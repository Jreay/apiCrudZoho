using ApiPrueba.DLAC;
using ApiPrueba.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiPruebaController : Controller
    {
        [HttpGet("listarClientes")]
        public async Task<IActionResult> GetClientes()
        {
            return Ok(await Task.Run(() => new clienteDLAC().listado()));
        }

        [HttpGet("listarContactos")]
        public async Task<IActionResult> GetContactos()
        {
            return Ok(await Task.Run(() => new contactoDLAC().listado()));
        }

        [HttpGet("listarEmpresa")]
        public async Task<IActionResult> GetEmpresa()
        {
            return Ok(await Task.Run(() => new empresaDLAC().listado()));
        }

        [HttpPost("registrarCliente")]
        public async Task<IActionResult> PostRegistrarCliente(Cliente reg)
        {
            return Ok(await Task.Run(() => new clienteDLAC().insertar(reg)));
        }

        [HttpPost("registrarContacto")]
        public async Task<IActionResult> PostRegistrarContacto(Contacto reg)
        {
            return Ok(await Task.Run(() => new contactoDLAC().insertar(reg)));
        }

        [HttpPost("registrarEmpresa")]
        public async Task<IActionResult> PostRegistrarEmpresa(Empresa reg)
        {
            return Ok(await Task.Run(() => new empresaDLAC().insertar(reg)));
        }

        [HttpPut("actualizarCliente")]
        public async Task<IActionResult> PutActualizarCliente(Cliente reg)
        {
            return Ok(await Task.Run(() => new clienteDLAC().actualizar(reg)));
        }

        [HttpPut("actualizarContacto")]
        public async Task<IActionResult> PutActualizarContacto(Contacto reg)
        {
            return Ok(await Task.Run(() => new contactoDLAC().actualizar(reg)));
        }

        [HttpPut("actualizarEmpresa")]
        public async Task<IActionResult> PutActualizarEmpresa(Empresa reg)
        {
            return Ok(await Task.Run(() => new empresaDLAC().actualizar(reg)));
        }

        [HttpDelete ("eliminarCliente")]
        public async Task<IActionResult> DelEliminarCliente(Cliente reg)
        {
            return Ok(await Task.Run(() => new clienteDLAC().eliminar(reg)));
        }

        [HttpDelete("eliminarContacto")]
        public async Task<IActionResult> DelEliminarContacto(Contacto reg)
        {
            return Ok(await Task.Run(() => new contactoDLAC().eliminar(reg)));
        }

        [HttpDelete("eliminarEmpresa")]
        public async Task<IActionResult> DelEliminarEmpresa(Empresa reg)
        {
            return Ok(await Task.Run(() => new empresaDLAC().eliminar(reg)));
        }


    }
}
