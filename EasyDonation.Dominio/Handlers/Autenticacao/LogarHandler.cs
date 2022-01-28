using EasyDonation.Comum.Commands;
using EasyDonation.Comum.Handlers.Contracts;
using EasyDonation.Comum.Utils;
using EasyDonation.Dominio.Commands.Autenticacao;
using EasyDonation.Dominio.Repositorios;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDonation.Dominio.Handlers.Autenticacao
{
    public class LogarHandler : Notifiable<Notification>, IHandlerCommand<LogarCommand>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LogarHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public ICommandResult Handler(LogarCommand command)
        {
            // Validar se os dados estão corretos
            command.Validar();

            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Dados incorretos", command.Notifications);
            }

            // Buscar usuario por email
            var usuario = _usuarioRepositorio.BuscarPorEmail(command.Email);
            if(usuario == null)
            {
                return new GenericCommandResult(false, "Usuario não encontrado", command.Notifications);
            }

            // Validar Hashes
            if (!Senha.ValidarHashes(command.Senha, usuario.Senha)){
                return new GenericCommandResult(false, "Dados incorretos", command.Notifications);
            }

            return new GenericCommandResult(true, "Logado com sucesso", usuario);
        }
    }
}
