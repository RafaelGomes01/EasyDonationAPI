using EasyDonation.Comum;
using EasyDonation.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDonation.Dominio.Commands.Usuario
{
    public class CriarContaCommand : Notifiable<Notification>, ICommand
    {
        public CriarContaCommand(string nomeUsuario, string email, string senha, EnTipoUsuario tipoUsuario)
        {
            NomeUsuario = nomeUsuario;
            Email = email;
            Senha = senha;
            TipoUsuario = tipoUsuario;
        }

        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public EnTipoUsuario TipoUsuario { get; set; }

        public void Validar()
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(NomeUsuario, "Nome do Usuario", "Nome do Usuario não pode ser vazio")
                .IsEmail(Email, "Email", "Email deve ser valido")
                .IsGreaterThan(Senha, 7, "Senha", "Senha deve ser maior que 8 caracteres")
            );
        }
    }
}
