using EasyDonation.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDonation.Dominio.Commands.Doacao
{
    public class DeletarDoacaoCommand : Notifiable<Notification>, ICommand
    {
        public DeletarDoacaoCommand()
        {

        }

        public DeletarDoacaoCommand(Guid idDoacao)
        {
            IdDoacao = idDoacao;
        }

        public Guid IdDoacao { get; set; }

        public void Validar()
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(IdDoacao, "Id da Doacao", "Id da Doacao não pode ser vazio")
            );
        }
    }
}
