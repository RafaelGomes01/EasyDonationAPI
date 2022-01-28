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
    public class CriarDoacaoCommand : Notifiable<Notification>, ICommand
    {
        public CriarDoacaoCommand(string titulo, string imagem, string descricao, EnStatusDoacao statusDoacao, Guid idUsuario, Guid idCategoria)
        {
            Titulo = titulo;
            Imagem = imagem;
            Descricao = descricao;
            StatusDoacao = statusDoacao;
            IdUsuario = idUsuario;
            IdCategoria = idCategoria;
        }

        public string Titulo { get; set; }
        public string Imagem { get; set; }
        public string Descricao { get; set; }
        public EnStatusDoacao StatusDoacao { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdCategoria { get; set; }


        public void Validar()
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(Titulo, "Titulo", "Titulo não pode ser vazio")
                .IsNotEmpty(Imagem, "Email", "Imagem não pode ser vazio")
                .IsNotEmpty(Descricao, "Descrição", "Descrição não pode ser vazio")
                .IsNotEmpty(IdUsuario, "id do usuario", "id do usuario não pode ser vazio")
                .IsNotEmpty(IdCategoria, "id da categoria", "id da categoria não pode ser vazio")
            );
        }
    }
}
