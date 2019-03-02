using System;
using Microsoft.AspNetCore.Mvc;
using Senai.Web.Api.Senatur.Domains;
using Senai.Web.Api.Senatur.Interfaces;
using Senai.Web.Api.Senatur.Repositories;

namespace Senai.Web.Api.Senatur.Controllers {
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PacotesController : ControllerBase
    {
        private readonly IPacotesRepository Pacotes;
        
        public PacotesController() {
            Pacotes = new PacotesRepository();        
        }

        [HttpGet("ListarTodos")]
        public IActionResult ListarTodos() {
            try {
                return Ok(Pacotes.ListarTodos());
            } catch (Exception exc) {
                return BadRequest(exc.Message);
            }
        }

        [HttpGet("Listar/{ID}")]
        public IActionResult Listar(int ID) {
            try {
                return Ok(Pacotes.ListarPorID(ID));
            } catch (Exception exc) {
                return BadRequest(exc.Message);
            }
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(PacotesDomain pacote) {
            try {
                Pacotes.Cadastrar(pacote);
                return Ok(Pacotes.ListarTodos());
            } catch (Exception exc) {
                return BadRequest(exc.Message);
            }
        }

        [HttpPost("Remover/{ID}")]
        public IActionResult Remover(int ID) {
            try {
                Pacotes.Remover(ID);
                return Ok(Pacotes.ListarTodos());
            } catch (Exception exc) {
                return BadRequest(exc.Message);
            }
        }
    }
}