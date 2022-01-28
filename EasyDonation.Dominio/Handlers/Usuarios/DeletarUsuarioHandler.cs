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
    public class DeletarUsuarioHandler : Notifiable<Notification>, IHandlerCommand<DeletarUsuarioCommand>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public DeletarUsuarioHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public ICommandResult Handler(DeletarUsuarioCommand command)
        {
            //Validar
            command.Validar();
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Dados incorretos", command.Notifications);
            }

            //Ver se o usuario existe
            var usuarioExiste = _usuarioRepositorio.BuscarPorId(command.IdUsuario);
            if (usuarioExiste == null)
            {
                return new GenericCommandResult(false, "Usuario não encontrado", "Informe outro email");
            }

            //Deletar Usuario
            _usuarioRepositorio.DeletarUsuario(command.IdUsuario);
            return new GenericCommandResult(true, "Usuario Deletado", "Dados de retorno");
        }
    }
}
