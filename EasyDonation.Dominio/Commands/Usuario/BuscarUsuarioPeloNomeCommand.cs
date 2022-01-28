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
    public class BuscarUsuarioPeloNomeCommand : Notifiable<Notification>, ICommand
    {
        public BuscarUsuarioPeloNomeCommand(string nomeUsuario)
        {
            NomeUsuario = nomeUsuario;
        }

        public string NomeUsuario { get; set; }

        public void Validar()
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(NomeUsuario, "Nome do Usuario", "Nome do Usuario não pode ser vazio")
            );
        }

    }
}
