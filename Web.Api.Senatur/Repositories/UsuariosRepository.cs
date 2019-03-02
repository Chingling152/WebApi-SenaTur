using System;
using System.Collections.Generic;
using Senai.Web.Api.Senatur.Context;
using Senai.Web.Api.Senatur.Domains;
using Senai.Web.Api.Senatur.Interfaces;

namespace Senai.Web.Api.Senatur.Repositories {
    public class UsuariosRepository : IUsuariosRepository {

        public void Cadastrar(UsuariosDomain usuario) {
            using (SenaturContext ctx = new SenaturContext()) {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public UsuariosDomain ListarPorID(int ID) {
            using (SenaturContext ctx = new SenaturContext()) {
                UsuariosDomain usuario = ctx.Usuarios.Find(ID);

                if (usuario == null) {
                    throw new NullReferenceException("Não existe pacote no ID selecionado");
                }

                return usuario;
            }
        }

        public List<UsuariosDomain> ListarTodos() {
            throw new System.NotImplementedException();
        }
    }
}
