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
    public class DoacaoRepositorio : IDoacaoRepositorio
    {
        private readonly EasyDonationContext _context;

        public DoacaoRepositorio(EasyDonationContext context)
        {
            _context = context;
        }

        public void Adicionar(Doacao doacao)
        {
            _context.Doacoes.Add(doacao);
            _context.SaveChanges();
        }

        public Doacao BuscarPeloId(Guid id)
        {
            return _context.Doacoes.FirstOrDefault(x => x.Id == id);
        }

        public Doacao BuscarPeloNome(string nome)
        {
            return _context.Doacoes.FirstOrDefault(x => x.Titulo == nome);
        }

        public void DeletarDoacao(Guid Id)
        {
            Doacao delete = _context.Doacoes.FirstOrDefault(x => x.Id == Id);
            _context.Remove(delete);
            _context.SaveChanges();
        }

        public ICollection<Doacao> Listar()
        {
            return _context.Doacoes.ToList();
        }
    }
}
