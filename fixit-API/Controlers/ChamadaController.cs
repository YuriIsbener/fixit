using fixit_API.Domains;
using fixit_API.Interfaces;
using fixit_API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace fixit_API.Controlers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class ChamadaController : ControllerBase
    {
        private IChamadaRepository _chamadaRepository { get; set; }

        public ChamadaController()
        {
            _chamadaRepository = new ChamadaRepository();
        }

        [HttpGet]
        public IActionResult GET()
        {
            try
            {
                return Ok(_chamadaRepository.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_chamadaRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Post(Chamada novaChamada)
        {
            try
            {
                _chamadaRepository.Cadastrar(novaChamada);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Chamada chamadaAtualizada)
        {
            try
            {
                _chamadaRepository.Atualizar(id, chamadaAtualizada);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _chamadaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("minhas")]
        public IActionResult GetMy()
        {
            try
            {
                // Cria uma variável idUsuario que recebe o valor do ID do usuário que está logado
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                // Retora a resposta da requisição 200 - OK fazendo a chamada para o método e trazendo a lista
                return Ok(_chamadaRepository.ListarMinhas(idUsuario));
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar as chamadas se o usuário não estiver logado!",
                    error
                });
            }
        }

        //[HttpPut("{id}")]
        //public IActionResult Put(int id, Chamada status)
        //{
            //try
            //{
                // Faz a chamada para o método
               // _chamadaRepository.AlterarStatus(id, status.StatusChamadaFkNavigation.NomeStatusChamada);

                // Retora a resposta da requisição 204 - No Content
                //return StatusCode(204);
           // }
           // catch (Exception error)
           // {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
               // return BadRequest(error);
           // }
       // }
    }
}
