using fixit_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fixit_API.Interfaces
{
    interface IChamadaRepository
    {
        /// <summary>
        /// Lista todos os tipos de eventos
        /// </summary>
        /// <returns>Uma lista de tipos de eventos</returns>
        List<Chamada> Listar();

        /// <summary>
        /// Busca um tipo de evento através do ID
        /// </summary>
        /// <param name="id">ID do tipo de evento que será buscado</param>
        /// <returns>Um tipo de evento buscado</returns>
        Chamada BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo tipo de evento
        /// </summary>
        /// <param name="novoTipoEvento">Objeto novoTipoEvento que será cadastrado</param>
        void Cadastrar(Chamada novoChamada);

        /// <summary>
        /// Atualiza um tipo de evento existente
        /// </summary>
        /// <param name="tipoEventoAtualizado">Objeto com as novas informações</param>
        void Atualizar(int id, Chamada ChamadaAtualizado);

        /// <summary>
        /// Deleta um tipo de evento existente
        /// </summary>
        /// <param name="id">ID do tipo de evento que será deletado</param>
        void Deletar(int id);
    }
}
