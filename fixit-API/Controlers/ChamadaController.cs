using fixit_API.Domains;
using fixit_API.Interfaces;
using fixit_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public IActionResult Post(Chamada novoChamada)
        {
            try
            {
                _chamadaRepository.Cadastrar(novoChamada);

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

    }
}
