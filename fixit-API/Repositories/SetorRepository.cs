using fixit_API.Domains;
using fixit_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fixit_API.Repositories
{
    public class SetorRepository : ISetorRepository
    {

        public void Atualizar(int id, Setor setorAtualizado)
        {
            Setor setorBuscado = BuscarPorId(id);

            if (setorAtualizado != null)
            {
                setorBuscado.NomeSetor = setorAtualizado.NomeSetor;
            }
            ctx.Setores.Update(setorAtualizado);

            ctx.SaveChanges();
        }

        public Setor BuscarPorId(int id)
        {
            return ctx.Setores.FirstOrDefault(c => c.IdSetor == id);
        }

        public void Cadastrar(Setor novoSetor)
        {
            ctx.Setores.Add(novoSetor);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Setores.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Setor> Listar()
        {
            return ctx.Setores.ToList();
        }

        fixit_dbContext ctx = new fixit_dbContext();
    
}
}
