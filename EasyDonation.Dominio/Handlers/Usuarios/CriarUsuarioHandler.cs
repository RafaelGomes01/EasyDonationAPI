using EasyDonation.Comum.Commands;
using EasyDonation.Comum.Handlers.Contracts;
using EasyDonation.Comum.Utils;
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
    public class CriarUsuarioHandler : Notifiable<Notification>, IHandlerCommand<CriarContaCommand>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public CriarUsuarioHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public ICommandResult Handler(CriarContaCommand command)
        {
            // Validar se os dados estão corretos
            command.Validar();

            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Dados incorretos", command.Notifications);
            }

            // Validar se já existe esse usuario cadastrado
            var usuarioExiste = _usuarioRepositorio.BuscarPorEmail(command.Email);
            if(usuarioExiste != null)
            {
                return new GenericCommandResult(false, "Email já cadastrado", "Informe outro email");
            }

            // Criptografar a senha
            command.Senha = Senha.Criptografar(command.Senha);

            // Criar novo usuario e validar
            Usuario user = new Usuario(command.NomeUsuario, command.Email, command.Senha, command.TipoUsuario);
            if (!user.IsValid)
            {
                return new GenericCommandResult(false, "Dados de usuario invalidos", user.Notifications);
            }

            // Adicionar usuario no banco
            _usuarioRepositorio.Adicionar(user);
            return new GenericCommandResult(true, "Usuario Criado", "Usuario foi cadastrado com sucesso");
        }
    }
}
