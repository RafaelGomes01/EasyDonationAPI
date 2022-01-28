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
    public class CriarDoacaoHandler : Notifiable<Notification>, IHandlerCommand<CriarDoacaoCommand>
    {
        private readonly IDoacaoRepositorio _doacaoRepositorio;

        public CriarDoacaoHandler(IDoacaoRepositorio doacaoRepositorio, IUsuarioRepositorio usuarioRepositorio)
        {
            _doacaoRepositorio = doacaoRepositorio;
        }

        public ICommandResult Handler(CriarDoacaoCommand command)
        {
            // Validar se os dados estão corretos
            command.Validar();

            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Dados incorretos", command.Notifications);
            }

            // Validar se já existe esse nome cadastrado
            var doacaoExiste = _doacaoRepositorio.BuscarPeloNome(command.Titulo);
            if (doacaoExiste != null)
            {
                return new GenericCommandResult(false, "Nome já cadastrado", command.Notifications);
            }

            // Criar nova doacao e validar
            Dominio.Doacao doacao = new Dominio.Doacao(command.Titulo, command.Imagem, command.Descricao, command.StatusDoacao, command.IdUsuario, command.IdCategoria);
            if (!doacao.IsValid)
            {
                return new GenericCommandResult(false, "Dados invalidos", doacao.Notifications);
            }

            // Adicionar doacao no banco
            _doacaoRepositorio.Adicionar(doacao);
            return new GenericCommandResult(true, "Doação Criada", doacao);
        }
    }
}
