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
    public class Doacao : Base
    {
        public Doacao(string titulo, string imagem, string descricao, EnStatusDoacao statusDoacao, Guid idUsuario, Guid idCategoria)
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(titulo, "Titulo", "Titulo não pode ser vazio")
                .IsNotEmpty(imagem, "Email", "Imagem não pode ser vazio")
                .IsNotEmpty(descricao, "Descrição", "Descrição não pode ser vazio")
                .IsNotEmpty(idUsuario, "id usuario", "id usuario não pode ser vazio")
                .IsNotEmpty(idCategoria, "id descricao", "id descricao não pode ser vazio")
            );

            if (IsValid)
            {
                Titulo = titulo;
                Imagem = imagem;
                Descricao = descricao;
                StatusDoacao = statusDoacao;
                IdUsuario = idUsuario;
                IdCategoria = idCategoria;
            }
                        
        }

        public string Titulo { get; private set; }
        public string Imagem { get; private set; }
        public string Descricao { get; private set; }
        public EnStatusDoacao StatusDoacao { get; private set; }
        public Guid IdUsuario { get; private set; }
        public Guid IdCategoria { get; private set; }


    }
}
