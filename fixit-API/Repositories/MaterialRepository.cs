using fixit_API.Domains;
using fixit_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fixit_API.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        public void Atualizar(int id, Material materialAtualizado)
        {
            Material materialBuscado = BuscarPorId(id);

            if (materialAtualizado.NomeMaterial != null)
            {
                materialBuscado.NomeMaterial = materialAtualizado.NomeMaterial;
            }
            ctx.Material.Update(materialBuscado);

            ctx.SaveChanges();
        }

        public Material BuscarPorId(int id)
        {
            return ctx.Material.FirstOrDefault(c => c.IdMaterial == id);
        }

        public void Cadastrar(Material novoMaterial)
        {
            ctx.Material.Add(novoMaterial);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Material.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Material> Listar()
        {
            return ctx.Material.ToList();
        }

        fixit_dbContext ctx = new fixit_dbContext();
    }
}
