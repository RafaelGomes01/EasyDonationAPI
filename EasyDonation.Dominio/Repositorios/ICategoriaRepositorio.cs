using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDonation.Dominio.Repositorios
{
    public interface ICategoriaRepositorio
    {
        /// <summary>
        /// Metodo para adicionar uma nova categoria
        /// </summary>
        /// <param name="categoria">Objeto Categoria</param>
        void Adicionar(Categoria categoria);

        /// <summary>
        /// Metodo para alterar os dados de uma categoria
        /// </summary>
        /// <param name="categoria">Objeto Categoria</param>
        //void Alterar(Categoria categoria);

        /// <summary>
        /// Metodo para buscar pelo id
        /// </summary>
        /// <param name="id">Id para pesquisa</param>
        /// <returns>Retornar um objeto Categoria</returns>
        Categoria BuscarPeloId(Guid id);

        /// <summary>
        /// Metodo para buscar pelo nome
        /// </summary>
        /// <param name="nome">Nome para pesquisa</param>
        /// <returns>Retornar um objeto Categoria</returns>
        Categoria BuscarPeloNome(string nome);

        /// <summary>
        /// Metodo que retorna uma lista de Categorias
        /// </summary>
        /// <param name="ativo">Apenas Categorias ativas</param>
        /// <returns>Retornar uma lista de objetos Categorias</returns>
        ICollection<Categoria> Listar(bool? ativo = null);

        /// <summary>
        /// Metodo para deletar uma Categoria
        /// </summary>
        /// <param name="Id">Id da Categoria para excluir</param>
        void DeletarCategoria(Guid Id);
    }
}
