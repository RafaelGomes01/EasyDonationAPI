using EasyDonation.Comum;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDonation.Dominio
{
    public class Usuario : Base
    {
        public Usuario(string nomeUsuario, string email, string senha, EnTipoUsuario tipoUsuario)
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(nomeUsuario, "Nome do Usuario", "Nome do Usuario não pode ser vazio")
                .IsEmail(email, "Email", "Email deve ser valido")
                .IsGreaterThan(senha, 7, "Senha", "Senha deve ser maior que 8 caracteres")
            );

            if (IsValid)
            {
                NomeUsuario = nomeUsuario;
                Email = email;
                Senha = senha;
                TipoUsuario = tipoUsuario;
            }
        }

        public string NomeUsuario { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public EnTipoUsuario TipoUsuario { get; private set; }
        public IReadOnlyCollection<Doacao> Doacoes { get { return _Doacoes;  } }
        private List<Doacao> _Doacoes { get; set; }



    }
}
