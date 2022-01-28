using EasyDonation.Dominio.Commands.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EasyDonation.Teste.Commands.Usuario
{
    public class AtualizarDadosUsuarioCommandTeste
    {
        [Fact]
        public void DeveRetornarSucessoSeDadosForemValidos()
        {
            var command = new AtualizarDadosUsuarioCommand();
            command.NomeUsuario = "Rafael Gomes";
            command.Email = "Rafael@gmail.com";
            command.Senha = "1234567890";
            command.TipoUsuario = Comum.EnTipoUsuario.Admin;

            command.Validar();

            Assert.True(command.IsValid, "Os Dados Foram preenchidos corretamente");
        }
    }
}
