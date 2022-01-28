using EasyDonation.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EasyDonation.Teste
{
    public class CategoriaTestes
    {
        [Fact]
        public void DeveRetornarSeCategoriaForValido()
        {
            Categoria categoriaTeste = new Categoria(
                "Eletronicos",
                EasyDonation.Comum.EnStatusCategoria.Ativo
            );
        }
    }
}
