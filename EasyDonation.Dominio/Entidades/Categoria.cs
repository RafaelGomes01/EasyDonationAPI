using EasyDonation.Comum;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDonation.Dominio
{
    public class Categoria : Base
    {
        public Categoria(string nomeCategoria, EnStatusCategoria statusCategoria, string descricaoCategoria, string imageCategoria)
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(nomeCategoria, "Nome da Categoria", "Nome da Categoria não pode ser vazio")
                .IsNotEmpty(descricaoCategoria, "Descrição da Categoria", "Descrição da categoria não pode ser vazio")
                .IsNotEmpty(imageCategoria, "Imagem da categoria", "Imagem da categoria não pode ser vazio")
            );

            if (IsValid)
            {
                NomeCategoria = nomeCategoria;
                StatusCategoria = statusCategoria;
                DescricaoCategoria = descricaoCategoria;
                ImageCategoria = imageCategoria;
            }
        }

        public string NomeCategoria { get; private set; }
        public EnStatusCategoria StatusCategoria { get; private set; }
        public string DescricaoCategoria { get; private set; }
        public string ImageCategoria { get; private set; }
        public IReadOnlyCollection<Doacao> Doacoes { get { return _Doacoes; } }
        private List<Doacao> _Doacoes { get; set; }

    }
}
