using fixit_API.Domains;
using fixit_API.Interfaces;
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
            ctx.Chamada.Update(chamadaBuscada);

            ctx.SaveChanges();
        }

        public Chamada BuscarPorId(int id)
        {
            return ctx.Chamada.FirstOrDefault(c => c.IdChamada == id);
        }

        public void Cadastrar(Chamada novoChamada)
        {
            ctx.Chamada.Add(novoChamada);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Chamada.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Chamada> Listar()
        {
            return ctx.Chamada.ToList();
        }

        fixit_dbContext ctx = new fixit_dbContext();
    }
}
