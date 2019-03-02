using System;
using System.Linq;
using System.Collections.Generic;
using Senai.Web.Api.Senatur.Context;
using Senai.Web.Api.Senatur.Domains;
using Senai.Web.Api.Senatur.Interfaces;

namespace Senai.Web.Api.Senatur.Repositories{
    public class PacotesRepository : IPacotesRepository {

        /// <summary>
        /// Altera as informações de um pacote de viagem do banco de dados
        /// </summary>
        /// <param name="pacotes">Pacote com os valores já alterados</param>
        public void Alterar(PacotesDomain pacote) {
            using (SenaturContext ctx = new SenaturContext()) {
                ctx.Pacotes.Update(pacote);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Cadastra um pacote no banco de dados
        /// </summary>
        /// <param name="pacote">Pacote a ser cadastrado no banco de dados</param>
        public void Cadastrar(PacotesDomain pacote) {
            using (SenaturContext ctx = new SenaturContext()) {
                ctx.Pacotes.Add(pacote);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Lista um pacote de viagem especifico do banco de dados
        /// </summary>
        /// <param name="ID">ID do pacote de viagem</param>
        /// <returns>Retorna todas as informações do pacote se ele existir se não , joga uma NullReferenceException</returns>
        public PacotesDomain ListarPorID(int ID) {
            using (SenaturContext ctx = new SenaturContext()) {
                PacotesDomain pacote = ctx.Pacotes.Find(ID);

                if(pacote == null) {
                    throw new NullReferenceException("Não existe pacote no ID selecionado");
                }

                return pacote;
            }
        }

        /// <summary>
        /// Lista todos os pacotes registrados no banco de dados
        /// </summary>
        /// <returns>Uma lista com todos os pacotes do banco de dados</returns>
        public List<PacotesDomain> ListarTodos() {
            using (SenaturContext ctx = new SenaturContext()) {
                return ctx.Pacotes.ToList();
            }
        }

        /// <summary>
        /// Remove um pacote do banco de dados, se ele não existir, joga uma NullReferenceException
        /// </summary>
        /// <param name="ID">ID do pacote que sera removido </param>
        public void Remover(int ID) {
            using (SenaturContext ctx = new SenaturContext()) {
                PacotesDomain pacote = ctx.Pacotes.Find(ID);

                if(pacote == null) {
                    throw new NullReferenceException("Não existe pacote no ID selecionado");
                }

                ctx.Pacotes.Remove(pacote);
                ctx.SaveChanges();
            }
        }
    }
}
