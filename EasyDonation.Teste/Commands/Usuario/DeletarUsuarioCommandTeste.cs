using EasyDonation.Dominio.Commands.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EasyDonation.Teste.Commands.Usuario
{
    public class DeletarUsuarioCommandTeste
    {
        [Fact]
        public void DeveRetornarSucessoSeDadosForemValidos()
        {
            var command = new DeletarUsuarioCommand();
            command.IdUsuario = Guid.NewGuid();

            command.Validar();

            Assert.True(command.IsValid, "Os Dados Foram preenchidos corretamente");
        }
    }
}
