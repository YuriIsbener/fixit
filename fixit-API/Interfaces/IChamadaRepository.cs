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
        /// Lista todas as chamadas
        /// </summary>
        /// <returns>Uma lista de chamadas</returns>
        List<Chamada> Listar();

        /// <summary>
        /// Busca uma chamada através do ID
        /// </summary>
        /// <param name="id">ID da chamada que será buscado</param>
        /// <returns>A chamada buscada</returns>
        Chamada BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova chamada
        /// </summary>
        /// <param name="novaChamada">Objeto novoChamada que será cadastrado</param>
        void Cadastrar(Chamada novaChamada);

        /// <summary>
        /// Atualiza uma chamada existente
        /// </summary>
        /// <param name="ChamadaAtualizada">Objeto com as novas informações</param>
        void Atualizar(int id, Chamada ChamadaAtualizada);

        /// <summary>
        /// Deleta uma chamada existente
        /// </summary>
        /// <param name="id">ID da chamada que será deletado</param>
        void Deletar(int id);
    }
}
