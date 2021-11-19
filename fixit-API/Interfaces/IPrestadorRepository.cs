using fixit_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fixit_API.Interfaces
{
    interface IPrestadorRepository
    {
        /// <summary>
        /// Lista todos os eventos que um determinado usuário participa
        /// </summary>
        /// <param name="id">ID do usuário que participa dos eventos listados</param>
        /// <returns>Uma lista de presenças com os dados dos eventos</returns>
        List<Prestador> ListarMinhas(int id);

        /// <summary>
        /// Cria uma nova presença
        /// </summary>
        /// <param name="inscricao">Objeto com as informações da inscrição</param>
        void Inscrever(Prestador inscricao);
    }
}
