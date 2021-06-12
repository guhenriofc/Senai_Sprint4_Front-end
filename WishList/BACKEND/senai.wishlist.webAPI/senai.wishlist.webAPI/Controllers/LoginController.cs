using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.wishlist.webAPI.Domains;
using senai.wishlist.webAPI.Interfaces;
using senai.wishlist.webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.wishlist.webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// _usuarioRepository recebe os métodos da interface
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(Usuario Login)
        {
            try
            {
                //procura o usuario
                Usuario usuarioBuscado = _usuarioRepository.Login(Login.Email, Login.Senha);

                //se o usuário não for encontrado 
                if (usuarioBuscado == null)
                {
                    //retorna not found e uma mensagem 
                    return NotFound("Email ou usuários inválidos");
                }
                //se for encontrado, cria o token

                //criação de claims - payload

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),

                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString())
                };

                //chave do token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("wishlist-chave-autenticacao"));

                //credencias de assinatura e criptografia
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //gerar token
                var token = new JwtSecurityToken
                (
                    issuer: "wishList.webApi",                 // emissor do token
                    audience: "wishList.webApi",               // destinatário do token
                    claims: claims,                        // dados definidos acima
                    expires: DateTime.Now.AddMinutes(30),  // tempo de expiração
                    signingCredentials: creds              // credenciais do token
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
