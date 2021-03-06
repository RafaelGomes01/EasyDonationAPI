using EasyDonation.Comum.Commands;
using EasyDonation.Comum.Handlers.Contracts;
using EasyDonation.Dominio.Commands.Doacao;
using EasyDonation.Dominio.Repositorios;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDonation.Dominio.Handlers.Doacao
{
    public class BuscarDoacaoPeloIdHandler : Notifiable<Notification>, IHandlerCommand<BuscarDoacaoPeloIdCommand>
    {
        private readonly IDoacaoRepositorio _doacaoRepositorio;

        public BuscarDoacaoPeloIdHandler(IDoacaoRepositorio doacaoRepositorio)
        {
            _doacaoRepositorio = doacaoRepositorio;
        }

        public ICommandResult Handler(BuscarDoacaoPeloIdCommand command)
        {
            // Validar se os dados estão corretos
            command.Validar();
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Dados incorretos", command.Notifications);
            }

            // Validar se existe essa doacao cadastrado
            var doacaoExiste = _doacaoRepositorio.BuscarPeloId(command.IdDoacao);
            if (doacaoExiste == null)
            {
                return new GenericCommandResult(false, "Doação não encontrado", command.Notifications);
            }

            //Retornar o usuario buscado
            var doacaoBuscada = _doacaoRepositorio.BuscarPeloId(command.IdDoacao);
            return new GenericCommandResult(true, "Doação Buscada", doacaoBuscada);
        }
    }
}
