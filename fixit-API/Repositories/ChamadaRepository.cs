using fixit_API.Domains;
using fixit_API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fixit_API.Repositories
{
    public class ChamadaRepository : IChamadaRepository
    {
        public void Atualizar(int id, Chamada chamadaAtualizada)
        {
            Chamada chamadaBuscada = BuscarPorId(id);

            if (chamadaAtualizada.NomeChamado != null)
            {
                chamadaBuscada.NomeChamado = chamadaAtualizada.NomeChamado;
            }
            ctx.Chamadas.Update(chamadaBuscada);

            ctx.SaveChanges();
        }

        public Chamada BuscarPorId(int id)
        {
            return ctx.Chamadas.FirstOrDefault(c => c.IdChamada == id);
        }

        public void Cadastrar(Chamada novoChamada)
        {
            ctx.Chamadas.Add(novoChamada);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Chamadas.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Chamada> Listar()
        {
            return ctx.Chamadas.ToList();
        }
        fixit_dbContext ctx = new fixit_dbContext();
    }
}
