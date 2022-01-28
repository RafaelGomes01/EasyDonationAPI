using EasyDonation.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDonation.Dominio.Commands
{
    public class DeletarCategoriaCommand : Notifiable<Notification>, ICommand
    {
        public DeletarCategoriaCommand()
        {

        }

        public DeletarCategoriaCommand(Guid idCategoria)
        {
            IdCategoria = idCategoria;
        }

        public Guid IdCategoria { get; set; }

        public void Validar()
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(IdCategoria, "Id da Categoria", "Id da Categoria não pode ser vazio")
            );
        }
    }
}
