using EasyDonation.Dominio;
using EasyDonation.Dominio.Commands.Usuario;
using EasyDonation.Dominio.Repositorios;
using EasyDonation.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDonation.Infra.Data.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly EasyDonationContext _context;

        public UsuarioRepositorio(EasyDonationContext context)
        {
            _context = context;
        }

        public void Adicionar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public Usuario BuscarPeloNome(string nomeUsuario)
        {
            return _context.Usuarios.FirstOrDefault(x => x.NomeUsuario == nomeUsuario);
        }

        public Usuario BuscarPorEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
        }

        public Usuario BuscarPorId(Guid Id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == Id);
        }

        public void DeletarUsuario(Guid Id)
        {
            Usuario delete = _context.Usuarios.FirstOrDefault(x => x.Id == Id);
            _context.Remove(delete);
            _context.SaveChanges();
        }

        public ICollection<Usuario> Listar()
        {
            //return _context.Usuarios.AsNoTracking().Include(x => x.Doacoes).OrderBy(x => x.DataCriacao).ToList();
            return _context.Usuarios.ToList();
        }
    }
}
