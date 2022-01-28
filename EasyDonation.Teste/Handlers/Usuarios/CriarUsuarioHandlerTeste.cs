using EasyDonation.Comum.Commands;
using EasyDonation.Dominio.Commands.Usuario;
using EasyDonation.Dominio.Handlers.Usuarios;
using EasyDonation.Teste.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EasyDonation.Teste.Handlers
{
    public class CriarUsuarioHandlerTeste
    {
        [Fact]
        public void DeveRetornarCasoDadosDoHandlerSejamValidos()
        {
            // Criar um Command
            var command = new CriarContaCommand();
            command.NomeUsuario = "Rafael Gomes";
            command.Email = "Rafael@gmail.com";
            command.Senha = "1234567890";
            command.TipoUsuario = Comum.EnTipoUsuario.Admin;

            // Criar um handle passando o repositorio
            var handler = new CriarUsuarioHandler(new FakeUsuarioRepositorio());

            // Pegar o resultado passando o handler + command
            var resultado = (GenericCommandResult)handler.Handler(command);

            // Validar a condição
            Assert.True(resultado.Sucesso, "Usuario valido");
        }
    }
}
