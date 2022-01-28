using EasyDonation.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EasyDonation.Teste
{
    public class UsuarioTestes
    {
        [Fact]
        public void DeveRetornarSeUsuarioForValido()
        {
            Usuario usuarioTeste = new Usuario(
                "Rafael",
                "Rafael@gmail.com",
                "1234567890",
                EasyDonation.Comum.EnTipoUsuario.Admin
            );

            Assert.True(usuarioTeste.IsValid);
        }
    }
}
