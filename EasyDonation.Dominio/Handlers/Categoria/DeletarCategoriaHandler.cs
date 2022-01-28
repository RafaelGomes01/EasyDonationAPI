using EasyDonation.Comum.Commands;
using EasyDonation.Comum.Handlers.Contracts;
using EasyDonation.Dominio.Commands;
using EasyDonation.Dominio.Repositorios;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDonation.Dominio.Handlers.Categoria
{
    public class DeletarCategoriaHandler : Notifiable<Notification>, IHandlerCommand<DeletarCategoriaCommand>
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public DeletarCategoriaHandler(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public ICommandResult Handler(DeletarCategoriaCommand command)
        {
            // Validar
            command.Validar();
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Dados incorretos", command.Notifications);
            }

            // Validar se existe essa categoria cadastrado
            var categoriaExiste = _categoriaRepositorio.BuscarPeloId(command.IdCategoria);
            if (categoriaExiste == null)
            {
                return new GenericCommandResult(false, "Categoria não encontrado", command.Notifications);
            }

            // Deletar Categoria
            _categoriaRepositorio.DeletarCategoria(command.IdCategoria);
            return new GenericCommandResult(true, "Categoria Deletada", "Dados de retorno");
        }
    }
}
