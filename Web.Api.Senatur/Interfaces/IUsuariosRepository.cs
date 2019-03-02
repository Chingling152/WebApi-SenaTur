using Senai.Web.Api.Senatur.Domains;
using System.Collections.Generic;

namespace Senai.Web.Api.Senatur.Interfaces {
    public interface IUsuariosRepository {

        void Cadastrar(UsuariosDomain usuario);

        List<UsuariosDomain> ListarTodos();

        UsuariosDomain ListarPorID(int ID);
    }
}
