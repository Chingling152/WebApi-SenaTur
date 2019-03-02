using System;
using Microsoft.AspNetCore.Mvc;
using Senai.Web.Api.Senatur.Domains;
using Senai.Web.Api.Senatur.Interfaces;
using Senai.Web.Api.Senatur.Repositories;

namespace Senai.Web.Api.Senatur.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public readonly IUsuariosRepository Usuarios;

        public UsuariosController() {
            Usuarios = new UsuariosRepository();
        }

        [HttpGet("ListarTodos")]
        public IActionResult ListarTodos() {
            try {
                return Ok(Usuarios.ListarTodos());
            } catch (Exception exc) {
                return BadRequest(exc.Message);
            }
        }

        [HttpGet("Listar/{ID}")]
        public IActionResult Listar(int ID) {
            try {
                return Ok(Usuarios.ListarPorID(ID));
            } catch (Exception exc) {
                return BadRequest(exc.Message);
            }
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(UsuariosDomain pacote) {
            try {
                Usuarios.Cadastrar(pacote);
                return Ok(Usuarios.ListarTodos());
            } catch (Exception exc) {
                return BadRequest(exc.Message);
            }
        }
    }
}