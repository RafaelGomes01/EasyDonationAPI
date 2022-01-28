using EasyDonation.Comum.Commands;
using EasyDonation.Comum.Queries;
using EasyDonation.Dominio.Commands.Doacao;
using EasyDonation.Dominio.Handlers.Doacao;
using EasyDonation.Dominio.Queries.Doacoes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyDonation.Api.Controllers
{
    [Route("doacao")]
    [ApiController]
    public class DoacaoController : ControllerBase
    {
        [Route("cadastrar")]
        [HttpPost]
        public GenericCommandResult Cadastrar([FromBody] CriarDoacaoCommand command, [FromServices] CriarDoacaoHandler handler)
        {
            return (GenericCommandResult)handler.Handler(command);
        }

        [Route("id")]
        [HttpPost]
        public GenericCommandResult BuscarPorId(BuscarDoacaoPeloIdCommand command, [FromServices] BuscarDoacaoPeloIdHandler handler)
        {
            return (GenericCommandResult)handler.Handler(command);
        }

        [Route("deletar")]
        [HttpDelete]
        public GenericCommandResult Deletar(DeletarDoacaoCommand command, [FromServices] DeletarDoacaoHandler handler)
        {
            return (GenericCommandResult)handler.Handler(command);
        }

        [Route("listar")]
        [HttpGet]
        public GenericQueryResult Listar([FromServices] ListarDoacoesHandle handle)
        {
            ListarDoacoesQuery query = new ListarDoacoesQuery();
            return (GenericQueryResult)handle.Handler(query);
        }
    }
}
