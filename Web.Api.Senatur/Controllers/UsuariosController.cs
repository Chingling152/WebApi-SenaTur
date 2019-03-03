using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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

        [Authorize(Roles = "Admin")]
        [HttpGet("ListarTodos")]
        public IActionResult ListarTodos() {
            try {
                return Ok(Usuarios.ListarTodos());
            } catch (Exception exc) {
                return BadRequest(exc.Message);
            }
        }

        [Authorize(Roles = "Admin")]
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

        [HttpPost("Login")]
        public IActionResult Logar(LoginViewModel usuario) {
            try {
                UsuariosDomain user = Usuarios.Logar(usuario.Email,usuario.Senha);
                if(user == null)
                    return NotFound("Email ou senha incorretos");

                var claims = new[] {
                    //new Claim(JwtRegisteredClaimNames.Email,user.Email), como o email não é unico acho que não tem necessidade
                    new Claim(JwtRegisteredClaimNames.Jti,user.ID.ToString()),
                    new Claim(ClaimTypes.Role,user.TipoUsuario.ToString())
                };

                var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Chave-Autenticacao-Senatur"));

                var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "Senatur.WebApi",
                    audience: "Senatur.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credenciais
                );

                return Ok(new {
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            } catch (Exception exc) {
                return BadRequest(exc.Message);
            }
        }

    }
}