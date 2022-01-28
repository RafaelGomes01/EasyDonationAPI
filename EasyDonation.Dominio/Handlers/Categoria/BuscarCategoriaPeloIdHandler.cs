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
    public class BuscarCategoriaPeloIdHandler : Notifiable<Notification>, IHandlerCommand<BuscarCategoriaPeloIdCommand>
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public BuscarCategoriaPeloIdHandler(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public ICommandResult Handler(BuscarCategoriaPeloIdCommand command)
        {
            // Validar se os dados estão corretos
            command.Validar();
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Dados incorretos", command.Notifications);
            }

            // Validar se existe essa doacao cadastrado
            var categoriaExiste = _categoriaRepositorio.BuscarPeloId(command.IdCategoria);
            if (categoriaExiste == null)
            {
                return new GenericCommandResult(false, "Categoria não encontrado", command.Notifications);
            }

            //Retornar o usuario buscado
            var categoria =_categoriaRepositorio.BuscarPeloId(command.IdCategoria);
            return new GenericCommandResult(true, "Categoria Buscada", categoria);
        }
    }
}
