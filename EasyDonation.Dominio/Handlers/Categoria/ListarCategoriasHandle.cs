using EasyDonation.Comum.Handlers.Contracts;
using EasyDonation.Comum.Queries;
using EasyDonation.Dominio.Queries.Categorias;
using EasyDonation.Dominio.Repositorios;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDonation.Dominio.Handlers.Categoria
{
    public class ListarCategoriasHandle : Notifiable<Notification>, IHandlerQuery<ListarCategoriasQuery>
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public ListarCategoriasHandle(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public IQueryResult Handler(ListarCategoriasQuery query)
        {
            var categorias = _categoriaRepositorio.Listar().ToList();
            return new GenericQueryResult(true, "Busca concluida", categorias);
        }
    }
}
