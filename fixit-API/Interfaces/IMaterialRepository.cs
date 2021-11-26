using fixit_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fixit_API.Interfaces
{
    interface IMaterialRepository
    {
        /// <summary>
        /// Lista todas os Materiais
        /// </summary>
        /// <returns>Uma lista de Materiais</returns>
        List<Material> Listar();

        /// <summary>
        /// Busca um Material através do ID
        /// </summary>
        /// <param name="id">ID do Material que será buscado</param>
        /// <returns>O material buscada</returns>
        Material BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo Material
        /// </summary>
        /// <param name="novoMaterial">Objeto novoChamada que será cadastrado</param>
        void Cadastrar(Material novoMaterial);

        /// <summary>
        /// Atualiza um Material existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="materialAtualizado">Objeto com as novas informações</param>
        void Atualizar(int id, Material materialAtualizado);

        /// <summary>
        /// Deleta um material existente
        /// </summary>
        /// <param name="id">ID da chamada que será deletado</param>
        void Deletar(int id);
    }
}
