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

namespace EasyDonation.Teste.Handlers.Usuarios
{
    public class BuscarUsuarioPeloIdHandlerTeste
    {
        [Fact]
        public void DeveRetornarCasoDadosDoHandlerSejamValidos()
        {
            //Criar um command
            var command = new BuscarUsuarioPeloIdCommand();
            command.IdUsuario = Guid.NewGuid();

            //Criar um Handler
            var handler = new BuscarUsuarioPeloIdHandler(new FakeUsuarioRepositorio());


            //Pegar o resultado e validar
            var resultado = (GenericCommandResult)handler.Handler(command);
            Assert.True(resultado.Sucesso, "Usuario Buscado");
        }
    }
}
