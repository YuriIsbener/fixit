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

        public List<Chamada> ListarMinhas(int id)
        {
            return ctx.Chamadas
            .Include(c => c.StatusChamadaFkNavigation)
            .Include(c => c.PrestadorFkNavigation).ThenInclude(c => c.UsuarioFk)
            .Include(c => c.ColaboradorFkNavigation).ThenInclude(c => c.UsuarioFk)
            
            .Select(c => new Chamada()
                {
                    IdChamada = c.IdChamada,
                    DataChamada = c.DataChamada,

                    ColaboradorFkNavigation = new Colaborador
                        {
                            UsuarioFkNavigation = new Usuario
                            {
                                IdUsuario = c.ColaboradorFkNavigation.UsuarioFkNavigation.IdUsuario,
                                Nome = c.ColaboradorFkNavigation.UsuarioFkNavigation.Nome
                            },
                        },

                    PrestadorFkNavigation = new Prestador
                        {
                            UsuarioFkNavigation = new Usuario
                            {
                                IdUsuario = c.PrestadorFkNavigation.UsuarioFkNavigation.IdUsuario,
                                Nome = c.PrestadorFkNavigation.UsuarioFkNavigation.Nome
                            },
                        },

                    StatusChamadaFkNavigation = new Statuschamada
                        {
                            IdStatusChamada = c.StatusChamadaFkNavigation.IdStatusChamada,
                            NomeStatusChamada = c.StatusChamadaFkNavigation.NomeStatusChamada
                        }
                })
            
            .Where(c => c.ColaboradorFkNavigation.UsuarioFk == id || c.PrestadorFkNavigation.UsuarioFk == id)
            .Where(c => c.StatusChamadaFkNavigation.IdStatusChamada != 5)
            .ToList();
        }

        public void AlterarStatus(int id, string status)
        {
            // Busca a primeira presença para o ID informado e armazena no objeto presencaBuscada
            Chamada chamadaBuscada = ctx.Chamadas
                // Adiciona na busca as informações do usuário que participa do evento
                .Include(p => p.PrestadorFkNavigation.UsuarioFkNavigation)
                // Adiciona na busca as informações do evento que o usuário participa
                .Include(p => p.IdChamada)
                .FirstOrDefault(p => p.IdChamada == id);

            // Verifica qual o status foi informado
            switch (status)
            {
                // Se for 1, a situação da presença será "Confirmada"
                case "1":
                    chamadaBuscada.StatusChamadaFkNavigation.NomeStatusChamada = "Em Andamento";
                    break;

                // Se for 0, a situação da presença será "Recusada"
                case "0":
                    chamadaBuscada.StatusChamadaFkNavigation.NomeStatusChamada = "Concluído";
                    break;

                // Se for 2, a situação da presença será "Não confirmada"
                case "2":
                    chamadaBuscada.StatusChamadaFkNavigation.NomeStatusChamada = "Cancelado";
                    break;

                // Se for qualquer valor diferente de 0, 1 e 2, a situação da presença não será alterada
                default:
                    chamadaBuscada.StatusChamadaFkNavigation.NomeStatusChamada = chamadaBuscada.StatusChamadaFkNavigation.NomeStatusChamada;
                    break;
            }

            // Atualiza os dados da presença que foi buscado
            ctx.Chamadas.Update(chamadaBuscada);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        fixit_dbContext ctx = new fixit_dbContext();
    }
}
