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
    public class BuscarUsuarioPeloIdHandler : Notifiable<Notification>, IHandlerCommand<BuscarUsuarioPeloIdCommand>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public BuscarUsuarioPeloIdHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public ICommandResult Handler(BuscarUsuarioPeloIdCommand command)
        {
            // Validar se os dados estão corretos
            command.Validar();
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Dados incorretos", command.Notifications);
            }

            // Validar se usuario existe
            var usuarioExiste = _usuarioRepositorio.BuscarPorId(command.IdUsuario);
            if(usuarioExiste == null)
            {
                return new GenericCommandResult(false, "Usuario não encontrado", "Informe outro Id");
            }

            //Retornar o usuario buscado
            var usuario = _usuarioRepositorio.BuscarPorId(command.IdUsuario);
            return new GenericCommandResult(true, "Busca Criada", usuario);
        }
    }
}
