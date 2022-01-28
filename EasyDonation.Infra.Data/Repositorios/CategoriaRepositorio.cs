using EasyDonation.Dominio;
using EasyDonation.Dominio.Repositorios;
using EasyDonation.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDonation.Infra.Data.Repositorios
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly EasyDonationContext _context;

        public CategoriaRepositorio(EasyDonationContext context)
        {
            _context = context;
        }

        public void Adicionar(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }

        public Categoria BuscarPeloId(Guid id)
        {
            return _context.Categorias.FirstOrDefault(x => x.Id == id);
        }

        public Categoria BuscarPeloNome(string nome)
        {
            return _context.Categorias.FirstOrDefault(x => x.NomeCategoria == nome);
        }

        public void DeletarCategoria(Guid Id)
        {
            Categoria delete = _context.Categorias.FirstOrDefault(x => x.Id == Id);
            _context.Remove(delete);
            _context.SaveChanges();
        }

        public ICollection<Categoria> Listar(bool? ativo = null)
        {
            return _context.Categorias.ToList();
        }
    }
}
