using Senai.Web.Api.Senatur.Domains;
using System.Collections.Generic;

namespace Senai.Web.Api.Senatur.Interfaces {
    /// <summary>
    /// Interface que lida com dados 
    /// </summary>
    interface IPacotesRepository {

        List<PacotesDomain> ListarTodos();

        PacotesDomain ListarPorID(int ID);

        void Cadastrar(PacotesDomain pacote);

        void Alterar(PacotesDomain pacote);

        void Remover(int ID);
    }
}