﻿using fixit_API.Domains;
using fixit_API.Interfaces;
using fixit_API.Repositories;
using fixit_API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace fixit_API.Controlers
{
 
    /// <summary>
    /// Controller responsável pelos endpoints referentes ao Login
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class LoginController : ControllerBase
        {
            /// <summary>
            /// Cria um objeto _usuarioRepository que irá receber todos os métodos definidos na interface
            /// </summary>
            private IUsuarioRepository _usuarioRepository { get; set; }

            /// <summary>
            /// Instancia este objeto para que haja a referência aos métodos no repositório
            /// </summary>
            public LoginController()
            {
                _usuarioRepository = new UsuarioRepository();
            }

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="login">Objeto login que contém o e-mail e a senha do usuário</param>
        /// <returns>Retorna um token com as informações do usuário</returns>
        /// dominio/api/Login
        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {
            try
            {
                // Busca o usuário pelo e-mail e senha
                Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

                // Caso não encontre nenhum usuário com o e-mail e senha informados
                if (usuarioBuscado == null)
                {
                    // Retorna NotFound com uma mensagem de erro
                    return NotFound("E-mail ou senha inválidos!");
                }

                var claims = new[]
                {
                   // Armazena na Claim o e-mail do usuário autenticado
                   new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),

                   // Armazena na Claim o ID do usuário autenticado
                   new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),

                    // Armazena na Claim o tipo de usuário que foi autenticado (Administrador ou Comum)
                    new Claim(ClaimTypes.Role, usuarioBuscado.TipoUser.ToString())
                };

                // Define a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Fix.It-chave-autenticacao"));

                // Define as credenciais do token - Header
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Gera o token
                var dadostoken = new JwtSecurityToken(
                    issuer: "FixIt.Api",                 // emissor do token
                    audience: "FixIt.Api",               // destinatário do token
                    claims: claims,                        // dados definidos acima
                    expires: DateTime.Now.AddMinutes(30),  // tempo de expiração
                    signingCredentials: creds              // credenciais do token
                );

                // Retorna Ok com o token
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(dadostoken)
                });

                // Caso o usuário seja encontrado, prossegue para a criação do token
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
