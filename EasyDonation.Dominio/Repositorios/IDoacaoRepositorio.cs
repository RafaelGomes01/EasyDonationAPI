using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDonation.Dominio.Repositorios
{
    public interface IDoacaoRepositorio
    {
        /// <summary>
        /// Metodo para adicionar uma nova doação
        /// </summary>
        /// <param name="doacao">Objeto Doacao</param>
        void Adicionar(Doacao doacao);

        /// <summary>
        /// Metodo para buscar pelo id
        /// </summary>
        /// <param name="id">Id para pesquisa</param>
        /// <returns>Retornar um objeto Doação</returns>
        Doacao BuscarPeloId(Guid id);

        /// <summary>
        /// Metodo para buscar pelo nome
        /// </summary>
        /// <param name="nome">Nome para pesquisa</param>
        /// <returns>Retornar um objeto Doação</returns>
        Doacao BuscarPeloNome(string nome);

        /// <summary>
        /// Metodo que retorna uma lista de doações
        /// </summary>
        /// <param name="ativo">Apenas doações ativas</param>
        /// <returns>Retornar uma lista de objetos Doação</returns>
        ICollection<Doacao> Listar();

        /// <summary>
        /// Metodo para deletar uma doação
        /// </summary>
        /// <param name="Id">Id da doação para excluir</param>
        void DeletarDoacao(Guid Id);
    }
}
