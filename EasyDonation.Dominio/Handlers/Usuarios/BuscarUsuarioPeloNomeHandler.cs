using EasyDonation.Comum.Commands;
using EasyDonation.Comum.Handlers.Contracts;
using EasyDonation.Dominio.Commands.Usuario;
using EasyDonation.Dominio.Repositorios;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDonation.Dominio.Handlers.Usuarios
{
    public class BuscarUsuarioPeloNomeHandler : Notifiable<Notification>, IHandlerCommand<BuscarUsuarioPeloNomeCommand>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public BuscarUsuarioPeloNomeHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public ICommandResult Handler(BuscarUsuarioPeloNomeCommand command)
        {
            command.Validar();
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Dados incorretos", command.Notifications);
            }

            // Validar se usuario existe
            var usuarioExiste = _usuarioRepositorio.BuscarPeloNome(command.NomeUsuario);
            if (usuarioExiste == null)
            {
                return new GenericCommandResult(false, "Usuario não encontrado", "Informe outro Id");
            }

            var usuario = _usuarioRepositorio.BuscarPeloNome(command.NomeUsuario);
            return new GenericCommandResult(true, "Busca Criada", usuario);
        }
    }
}
