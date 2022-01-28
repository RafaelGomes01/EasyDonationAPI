using EasyDonation.Comum.Handlers.Contracts;
using EasyDonation.Comum.Queries;
using EasyDonation.Dominio.Queries.Usuario;
using EasyDonation.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDonation.Dominio.Handlers.Usuarios
{
    public class ListarUsuariosHadle : IHandlerQuery<ListarUsuariosQuery>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public ListarUsuariosHadle(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IQueryResult Handler(ListarUsuariosQuery query)
        {
            // Usar o metodo do repositorio para trazer os objetos
            var usuarios = _usuarioRepositorio.Listar();

            //Limpar as infos desnecessarias
            var retornoUsuario = usuarios.Select(
                x =>
                    {
                        return new ListarUsuarioResult()
                        {
                            Id = x.Id,
                            NomeUsuario = x.NomeUsuario,
                            Email = x.Email,
                            TipoUsuario = x.TipoUsuario,
                            DataCriacao = x.DataCriacao
                        };
                    }
                );

            return new GenericQueryResult(true, "Usuario Encontrados", retornoUsuario);
        }
    }
}
