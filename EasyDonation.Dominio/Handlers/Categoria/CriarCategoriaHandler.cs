using EasyDonation.Comum.Commands;
using EasyDonation.Comum.Handlers.Contracts;
using EasyDonation.Dominio.Commands.Categoria;
using EasyDonation.Dominio.Repositorios;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDonation.Dominio.Handlers.Categoria
{
    public class CriarCategoriaHandler : Notifiable<Notification>, IHandlerCommand<CriarCategoriaCommand>
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CriarCategoriaHandler(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public ICommandResult Handler(CriarCategoriaCommand command)
        {
            // Validar se os dados estão corretos
            command.Validar();

            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Dados incorretos", command.Notifications);
            }

            // Validar se já existe esse nome cadastrado
            var categoriaExiste = _categoriaRepositorio.BuscarPeloNome(command.NomeCategoria);
            if (categoriaExiste != null)
            {
                return new GenericCommandResult(false, "Nome já cadastrado", command.Notifications);
            }

            // Criar nova categoria e validar
            Dominio.Categoria categoria = new Dominio.Categoria(command.NomeCategoria, command.StatusCategoria, command.DescricaoCategoria, command.ImageCategoria);
            if (!categoria.IsValid)
            {
                return new GenericCommandResult(false, "Dados invalidos", categoria.Notifications);
            }

            // Adicionar categoria no banco
            _categoriaRepositorio.Adicionar(categoria);
            return new GenericCommandResult(true, "Categoria Criada", categoria);
        }
    }
}
