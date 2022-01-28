using EasyDonation.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDonation.Dominio.Commands.Autenticacao
{
    public class RecuperarSenhaCommand : Notifiable<Notification>, ICommand
    {
        public RecuperarSenhaCommand(string email)
        {
            Email = email;
        }

        public string Email { get; set; }

        public void Validar()
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsEmail(Email, "Email", "Email deve ser valido")
            );
        }
    }
}
