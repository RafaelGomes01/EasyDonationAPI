using EasyDonation.Comum.Commands;
using EasyDonation.Dominio.Commands.Usuario;
using EasyDonation.Dominio.Handlers.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EasyDonation.Dominio;
using EasyDonation.Dominio.Commands.Autenticacao;
using EasyDonation.Dominio.Handlers.Autenticacao;
using EasyDonation.Comum.Queries;
using EasyDonation.Dominio.Queries.Usuario;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using EasyDonation.Comum;

namespace EasyDonation.Api.Controllers
{
    [Route("usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // CADASTRAR
        [Route("cadastrar")]
        [HttpPost]
        public GenericCommandResult Cadastrar(CriarContaCommand command, [FromServices] CriarUsuarioHandler handler)
        {
            return (GenericCommandResult)handler.Handler(command);
        }

        // LISTAR
        [Route("id")]
        [HttpPost]
        public GenericCommandResult BuscarPeloId(BuscarUsuarioPeloIdCommand command, [FromServices] BuscarUsuarioPeloIdHandler handler)
        {
            return (GenericCommandResult)handler.Handler(command);
        }

        [Route("listar")]
        [HttpGet]
        //[Authorize(Roles = "3")]
        public GenericQueryResult Listar([FromServices] ListarUsuariosHadle handler)
        {
            ListarUsuariosQuery query = new ListarUsuariosQuery();
            return (GenericQueryResult)handler.Handler(query);
        }

        [Route ("nome")]
        [HttpPost]
        public GenericCommandResult BuscarPeloNome(BuscarUsuarioPeloNomeCommand command ,[FromServices] BuscarUsuarioPeloNomeHandler handler)
        {
            return (GenericCommandResult)handler.Handler(command);
        }

        // ATUALIZAR

        //DELETAR
        [Route("deletar")]
        [HttpDelete]
        public GenericCommandResult Deletar(DeletarUsuarioCommand command, [FromServices] DeletarUsuarioHandler handler)
        {
            return (GenericCommandResult)handler.Handler(command);
        }

        // OUTROS
        [Route("logar")]
        [HttpPost]
        public GenericCommandResult Logar(LogarCommand command, [FromServices] LogarHandler handler)
        {
            var resultado = (GenericCommandResult)handler.Handler(command);
            if (resultado.Sucesso)
            {
                var token = GenerateJSONWebToken((Usuario)resultado.Data);
                return new GenericCommandResult(resultado.Sucesso, resultado.Mensagem, new { Token = token });
            }

            return new GenericCommandResult(false, resultado.Mensagem, resultado.Data);
        }

        private string GenerateJSONWebToken(Usuario userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("EasyDonation-security-key"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
            new Claim(JwtRegisteredClaimNames.FamilyName, userInfo.NomeUsuario),
            new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
            new Claim(ClaimTypes.Role, userInfo.TipoUsuario.ToString()),
            new Claim("role", userInfo.TipoUsuario.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, userInfo.Id.ToString())
            };

            var token = new JwtSecurityToken
                (
                    issuer: "EasyDonation",
                    audience: "EasyDonation",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
