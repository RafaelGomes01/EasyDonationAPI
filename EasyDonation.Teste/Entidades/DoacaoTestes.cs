using EasyDonation.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EasyDonation.Teste
{
    
    public class DoacaoTestes
    {
        [Fact]
        public void DeveRetornarSeDoacaoForValido()
        {
            Doacao doacaoTeste = new Doacao(
                "Computador para estudos",
                "computador.png",
                "OLA MUNDO",
                EasyDonation.Comum.EnStatusDoacao.ativo,
                Guid.NewGuid(),
                Guid.NewGuid()
            );

            Assert.True(doacaoTeste.IsValid);
        }
    }
}
