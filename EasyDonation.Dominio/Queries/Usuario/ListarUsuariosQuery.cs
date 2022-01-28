using EasyDonation.Comum;
using EasyDonation.Comum.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDonation.Dominio.Queries.Usuario
{
    public class ListarUsuariosQuery : IQuery
    {
        // Sem necessidade de validar.
        public void Validar(){}
    }

    public class ListarUsuarioResult
    {
        public Guid Id { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public EnTipoUsuario TipoUsuario { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
