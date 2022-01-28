using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDonation.Dominio.Repositorios
{
    public interface IUsuarioRepositorio
    {
        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="usuario">Dados de um Usuario</param>
        void Adicionar(Usuario usuario);

        /// <summary>
        /// Buscar usuario por email
        /// </summary>
        /// <param name="email">Email para busca</param>
        /// <returns></returns>
        Usuario BuscarPorEmail(string email);

        /// <summary>
        /// Buscar usuario por Id
        /// </summary>
        /// <param name="Id">Id para busca</param>
        /// <returns></returns>
        Usuario BuscarPorId(Guid Id);

        /// <summary>
        /// Buscar Usuario pelo nome
        /// </summary>
        /// <param name="nomeUsuario">Nome para busca</param>
        /// <returns></returns>
        Usuario BuscarPeloNome(string nomeUsuario);

        /// <summary>
        /// Lista de usuarios
        /// </summary>
        /// <param name="ativo">Usuario ativos</param>
        /// <returns></returns>
        ICollection<Usuario> Listar();

        /// <summary>
        /// Deletar um usuario
        /// </summary>
        /// <param name="Id">Id para busca</param>
        void DeletarUsuario(Guid Id);
    }
}
