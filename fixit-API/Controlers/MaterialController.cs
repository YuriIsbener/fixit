using fixit_API.Domains;
using fixit_API.Interfaces;
using fixit_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fixit_API.Controlers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private IMaterialRepository _materialRepository { get; set; }

        public MaterialController()
        {
            _materialRepository = new MaterialRepository();
        }

            [HttpGet]
            public IActionResult GET()
            {
                try
                {
                    return Ok(_materialRepository.Listar());
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
                    return Ok(_materialRepository.BuscarPorId(id));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }

            [HttpPost]
            public IActionResult Post(Material novoMaterial)
            {
                try
                {
                    _materialRepository.Cadastrar(novoMaterial);

                    return StatusCode(201);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }

            [HttpPut("{id}")]
            public IActionResult Put(int id, Material materialAtualizado)
            {
                try
                {
                    _materialRepository.Atualizar(id, materialAtualizado);

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
                    _materialRepository.Deletar(id);

                    return StatusCode(204);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
        }
        }
}
