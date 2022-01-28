using EasyDonation.Comum;
using EasyDonation.Comum.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDonation.Dominio.Queries.Doacoes
{
    public class ListarDoacoesQuery : IQuery
    {
        public void Validar()
        {
            throw new NotImplementedException();
        }
    }

    public class ListarDoacaoResult
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Imagem { get; set; }
        public string Descricao { get; set; }
        public EnStatusDoacao StatusDoacao { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdCategoria { get; set; }
    }
}
