using EasyDonation.Comum;
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
    public class CriarCategoriaCommand : Notifiable<Notification>, ICommand
    {
        public CriarCategoriaCommand(string nomeCategoria, EnStatusCategoria statusCategoria, string descricaoCategoria, string imageCategoria)
        {
            NomeCategoria = nomeCategoria;
            StatusCategoria = statusCategoria;
            DescricaoCategoria = descricaoCategoria;
            ImageCategoria = imageCategoria;
        }

        public string NomeCategoria { get; set; }
        public string DescricaoCategoria { get; set; }
        public string ImageCategoria { get; set; }
        public EnStatusCategoria StatusCategoria { get; set; }

        public void Validar()
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(NomeCategoria, "Nome da Categoria", "Nome da Categoria não pode ser vazio")
                .IsNotEmpty(DescricaoCategoria, "Descrição da Categoria", "Descrição da categoria não pode ser vazio")
                .IsNotEmpty(ImageCategoria, "Imagem da categoria", "Imagem da categoria não pode ser vazio")
            );
        }
    }
}
