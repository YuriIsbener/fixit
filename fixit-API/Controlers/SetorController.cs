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
    public class SetorController : ControllerBase
    {
        private ISetorRepository _setorRepository { get; set; }

        public SetorController()
        {
            _setorRepository = new SetorRepository();
        }

        [HttpGet]
        public IActionResult GET()
        {
            try
            {
                return Ok(_setorRepository.Listar());
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
                return Ok(_setorRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Post(Setor novoSetor)
        {
            try
            {
                _setorRepository.Cadastrar(novoSetor);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Setor setorAtualizado)
        {
            try
            {
                _setorRepository.Atualizar(id, setorAtualizado);

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
                _setorRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
