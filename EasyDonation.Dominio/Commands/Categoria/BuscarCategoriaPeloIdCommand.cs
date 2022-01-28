using EasyDonation.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDonation.Dominio.Commands.Categoria
{
    public class BuscarCategoriaPeloIdCommand : Notifiable<Notification>, ICommand
    {
        public BuscarCategoriaPeloIdCommand()
        {

        }

        public BuscarCategoriaPeloIdCommand(Guid idCategoria)
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
