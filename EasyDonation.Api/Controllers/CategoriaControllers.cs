    using EasyDonation.Comum.Commands;
using EasyDonation.Comum.Queries;
using EasyDonation.Dominio.Commands;
using EasyDonation.Dominio.Commands.Categoria;
using EasyDonation.Dominio.Handlers.Categoria;
using EasyDonation.Dominio.Queries.Categorias;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyDonation.Api.Controller
{
    [Route("categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        [Route("cadastrar")]
        [HttpPost]
        public GenericCommandResult CadastrarCategoria(CriarCategoriaCommand command, [FromServices] CriarCategoriaHandler handler)
        {
            return (GenericCommandResult)handler.Handler(command);
        }

        [Route("id")]
        [HttpPost]
        public GenericCommandResult ListarPeloId(BuscarCategoriaPeloIdCommand command, [FromServices] BuscarCategoriaPeloIdHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        [Route("listar")]
        [HttpGet]
        public GenericQueryResult ListarCategorias([FromServices] ListarCategoriasHandle handle)
        {
            ListarCategoriasQuery query = new ListarCategoriasQuery();
            return (GenericQueryResult)handle.Handler(query);
        }

        [Route("deletar")]
        [HttpDelete]
        public GenericCommandResult DeletarCategorias(DeletarCategoriaCommand command, [FromServices] DeletarCategoriaHandler handler)
        {
            return (GenericCommandResult)handler.Handler(command);
        }
    }
}
