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
    public class BuscarUsuarioPeloIdCommand : Notifiable<Notification>, ICommand
    {
        public BuscarUsuarioPeloIdCommand(Guid idUsuario)
        {
            IdUsuario = idUsuario;
        }

        public Guid IdUsuario { get; set; }

        public void Validar()
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(IdUsuario, "Id do Usuario", "Id do Usuario não pode ser vazio")
            );
        }
    }
}
