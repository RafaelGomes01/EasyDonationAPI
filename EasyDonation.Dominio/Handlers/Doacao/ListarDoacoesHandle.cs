using EasyDonation.Comum.Handlers.Contracts;
using EasyDonation.Comum.Queries;
using EasyDonation.Dominio.Commands.Doacao;
using EasyDonation.Dominio.Queries.Doacoes;
using EasyDonation.Dominio.Repositorios;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDonation.Dominio.Handlers.Doacao
{
    public class ListarDoacoesHandle : Notifiable<Notification>, IHandlerQuery<ListarDoacoesQuery>
    {
        private readonly IDoacaoRepositorio _doacaoRepositorio;

        public ListarDoacoesHandle(IDoacaoRepositorio doacaoRepositorio)
        {
            _doacaoRepositorio = doacaoRepositorio;
        }

        public IQueryResult Handler(ListarDoacoesQuery query)
        {
            var doacoes = _doacaoRepositorio.Listar().ToList();
            return new GenericQueryResult(true, "Busca concluida", doacoes);
        }
    }
}
