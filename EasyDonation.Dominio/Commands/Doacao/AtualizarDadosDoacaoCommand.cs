using EasyDonation.Comum;
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
    public class AtualizarDadosDoacaoCommand : Notifiable<Notification>, ICommand
    {
        public AtualizarDadosDoacaoCommand()
        {

        }

        public AtualizarDadosDoacaoCommand(string titulo, string imagem, string descricao, EnStatusDoacao statusDoacao, Guid idUsuario, Guid idCategoria, Guid idDocao)
        {
            Titulo = titulo;
            Imagem = imagem;
            Descricao = descricao;
            StatusDoacao = statusDoacao;
            IdUsuario = idUsuario;
            IdCategoria = idCategoria;
            IdDocao = idDocao;
        }

        
        public string Titulo { get; private set; }
        public string Imagem { get; private set; }
        public string Descricao { get; private set; }
        public EnStatusDoacao StatusDoacao { get; private set; }
        public Guid IdUsuario { get; private set; }
        public Guid IdCategoria { get; private set; }
        public Guid IdDocao { get; private set; }

        public void Validar()
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(Titulo, "Titulo", "Titulo não pode ser vazio")
                .IsNotEmpty(Imagem, "Email", "Imagem não pode ser vazio")
                .IsNotEmpty(Descricao, "Descrição", "Descrição não pode ser vazio")
                .IsNotNull(IdUsuario, "Id Usuario", "Id do Usuario não pode ser vazio")
                .IsNotNull(IdCategoria, "Id Usuario", "Id do Usuario não pode ser vazio")
            );
        }
    }
}
