using fixit_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fixit_API.Interfaces
{
    interface ISetorRepository
    {
        /// <summary>
        /// Lista todas as chamadas
        /// </summary>
        /// <returns>Uma lista de chamadas</returns>
        List<Setor> Listar();

        /// <summary>
        /// Busca uma chamada através do ID
        /// </summary>
        /// <param name="id">ID da chamada que será buscado</param>
        /// <returns>A chamada buscada</returns>
        Setor BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova chamada
        /// </summary>
        /// <param name="novoSetor">Objeto novoChamada que será cadastrado</param>
        void Cadastrar(Setor novoSetor);

        /// <summary>
        /// Atualiza uma chamada existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="SetorAtualizado">Objeto com as novas informações</param>
        void Atualizar(int id, Setor SetorAtualizado);

        /// <summary>
        /// Deleta uma chamada existente
        /// </summary>
        /// <param name="id">ID da chamada que será deletado</param>
        void Deletar(int id);
    }
}
