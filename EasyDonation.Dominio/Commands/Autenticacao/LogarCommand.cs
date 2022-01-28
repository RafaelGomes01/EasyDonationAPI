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
    public class LogarCommand : Notifiable<Notification>, ICommand
    {
        public LogarCommand(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public string Email { get; set; }
        public string Senha { get; set; }

        public void Validar()
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsEmail(Email, "Email", "Email deve ser valido")
                .IsGreaterThan(Senha, 7, "Senha", "Senha deve ser maior que 8 caracteres")
            );
        }
    }
}
