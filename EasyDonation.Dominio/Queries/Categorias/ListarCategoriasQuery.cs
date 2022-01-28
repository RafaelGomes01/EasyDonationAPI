using EasyDonation.Comum.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDonation.Dominio.Queries.Categorias
{
    public class ListarCategoriasQuery : IQuery
    {
        public void Validar()
        {
            throw new NotImplementedException();
        }
    }

    public class ListarCategoriasResult
    {
        public Guid Id { get; set; }
        public string NomeCategoria { get; set; }
    }
}
