using System;
using System.Linq;
using System.Collections.Generic;
using Senai.Web.Api.Senatur.Context;
using Senai.Web.Api.Senatur.Domains;
using Senai.Web.Api.Senatur.Interfaces;

namespace Senai.Web.Api.Senatur.Repositories {
    public class UsuariosRepository : IUsuariosRepository {

        /// <summary>
        /// Cadastra um novo usuario no banco de dados
        /// </summary>
        /// <param name="usuario">Usuario a ser cadastrado</param>
        public void Cadastrar(UsuariosDomain usuario) {
            using (SenaturContext ctx = new SenaturContext()) {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Procura um usuario no ID selecionado
        /// </summary>
        /// <param name="ID">ID Do usuario a ser procurado</param>
        /// <returns>Retorna um usuario no ID selecionado , se ele não existir retorna uma exceção</returns>
        public UsuariosDomain ListarPorID(int ID) {
            using (SenaturContext ctx = new SenaturContext()) {
                UsuariosDomain usuario = ctx.Usuarios.Find(ID);

                if (usuario == null) {
                    throw new NullReferenceException("Não existe pacote no ID selecionado");
                }

                return usuario;
            }
        }

        /// <summary>
        /// Retorna todos os usuarios do banco de dados
        /// </summary>
        /// <returns>Uma lista com todos os usuarios cadastrados no banco de dados</returns>
        public List<UsuariosDomain> ListarTodos() => new SenaturContext().Usuarios.ToList();

        /// <summary>
        /// Procura um usuario no banco de dados com o Email e Senha inseridos 
        /// </summary>
        /// <param name="Email">Email do Usuario a ser procurado</param>
        /// <param name="Senha">Senha do Usuario a ser procurado</param>
        /// <returns>Retorna um usuario se ele conter o Email e Senha inseridos , se não existir , retorna null</returns>
        public UsuariosDomain Logar(string Email, string Senha) => new SenaturContext().Usuarios.ToList().Find(X => X.Email == Email && X.Senha == Senha);
    }
}
