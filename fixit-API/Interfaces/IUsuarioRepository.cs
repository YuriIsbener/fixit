using fixit_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fixit_API.Interfaces
{
    interface IUsuarioRepository
    {
        Usuario Login(string email, string senha);
        /// <summary>
        /// Lista todas os Materiais
        /// </summary>
        /// <returns>Uma lista de Materiais</returns>
        List<Usuario> Listar();

        /// <summary>
        /// Busca um Material através do ID
        /// </summary>
        /// <param name="id">ID do Material que será buscado</param>
        /// <returns>O material buscada</returns>
        Usuario BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo Material
        /// </summary>
        /// <param name="novoUsuario">Objeto novoChamada que será cadastrado</param>
        void Cadastrar(Usuario novoUsuario);

        /// <summary>
        /// Atualiza um Material existente
        /// </summary>
        /// <param name="usuarioAtualizado">Objeto com as novas informações</param>
        void Atualizar(int id, Usuario usuarioAtualizado);

        /// <summary>
        /// Deleta um material existente
        /// </summary>
        /// <param name="id">ID da chamada que será deletado</param>
        void Deletar(int id);
    }
}
