using fixit_API.Domains;
using fixit_API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fixit_API.Repositories
{
    public class PrestadorRepository : IPrestadorRepository
    {
        fixit_dbContext ctx = new fixit_dbContext();

        public void Inscrever(Prestador inscricao)
        {
            throw new NotImplementedException();
        }

        public List<Prestador> ListarMinhas(int id)
        {
            // Retorna uma lista com todas as informações das presenças
            return ctx.Prestadores
                // Adiciona na busca as informações do evento que o usuário participa
                .Include(p => p.idChamadaNavigation)
                // Adiciona na busca as informações do Tipo de Evento (categoria) deste evento
                .Include(p => p.iChamadaNavigation.statusChamadaFkNavigation)
                // Adiciona na busca as informações da Instituição deste evento
                .Include(p => p.IdEventoNavigation.IdInstituicaoNavigation)
                // Estabelece como parâmetro de consulta o ID do usuário recebido
                .Where(p => p.IdUsuario == id)
                .ToList();
        }
    }
}
