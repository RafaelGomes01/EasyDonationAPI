using EasyDonation.Dominio;
using EasyDonation.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDonation.Teste.Repositorios
{
    public class FakeUsuarioRepositorio : IUsuarioRepositorio
    {
        public void Adicionar(Usuario usuario)
        {
        }

        public void Alterar(Usuario usuario)
        {
        }

        public void AlterarSenha(Usuario usuario)
        {
        }

        public Usuario BuscarPorEmail(string email)
        {
            return null;
        }

        public Usuario BuscarPorId(Guid Id)
        {
            return new Usuario("Rafael", "rafamax550@gmail.com", "1234567889", Comum.EnTipoUsuario.Admin);
        }

        public void DeletarUsuario(Guid Id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Usuario> Listar(bool? ativo = null)
        {
            return new List<Usuario>()
            {
                new Usuario("Rafael", "rafamax550@gmail.com", "1234567889", Comum.EnTipoUsuario.Admin),
                new Usuario("Rafael2", "rafamax560@gmail.com", "1234567889", Comum.EnTipoUsuario.Admin),
                new Usuario("Rafael3", "rafamax570@gmail.com", "1234567889", Comum.EnTipoUsuario.Admin),
                new Usuario("Rafael4", "rafamax580@gmail.com", "1234567889", Comum.EnTipoUsuario.Admin)
            };
        }
    }
}
