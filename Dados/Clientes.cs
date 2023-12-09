/*
*	<copyright file="Clientes" company="IPCA"></copyright>
* 	<author>Diogo Fernandes</author>
*	<contact>a26008@alunos.ipca.pt</contact>
*   <date>12/9/2023 6:20:18 PM</date>
*	<description>Lista de clientes</description>
**/

using ObjetosNegocio;
using System.Collections.Generic;

namespace Dados
{
    public class Clientes
    {
        #region Atributos

        static List<Cliente> listaClientes;

        #endregion

        #region Métodos

        #region Construtores

        /// <summary>
        /// Construtor estático de clientes
        /// </summary>
        static Clientes()
        {
            listaClientes = new List<Cliente>();
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Propriedade para o atributo ListaClientes, pode obter a lista, mas não a pode alterar
        /// </summary>
        public List<Cliente> ListaClientes 
        { 
            get { return listaClientes; } 
        }

        #endregion

        #region Operadores

        #endregion

        #region Overrides

        #endregion

        #region Outros Métodos

        /// <summary>
        /// Método para verificar se a lista tem o cliente.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool ExisteCliente(Cliente c)
        {
            return listaClientes.Contains(c);
        }

        /// <summary>
        /// Método para verificar se a lista tem o cliente através do código.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool ExisteCliente(int codigo)
        {
            if(EncontraCliente(codigo) == null) return false;

            return true;
        }

        /// <summary>
        /// Método para encontrar o cliente com o código especificado.
        /// </summary>
        /// <param name="codigo">Código do cliente a encontrar.</param>
        /// <returns>Devolve o cliente com o código ou null se não encontrar.</returns>
        public static Cliente EncontraCliente(int codigo)
        {
            return listaClientes.Find(cliente => cliente.CodigoCliente == codigo);
        }

        /// <summary>
        /// Adiciona o cliente na lista.
        /// </summary>
        /// <param name="c">Cliente a adicionar.</param>
        /// <returns></returns>
        public static bool AdicionarCliente(Cliente c)
        {
            //  !!! Adicionar Exceção
            if (ExisteCliente(c)) return false;

            listaClientes.Add(c); 
            return true;
        }

        /// <summary>
        /// Remove o cliente da lista.
        /// </summary>
        /// <param name="c">Cliente a remover</param>
        /// <returns>Devolve verdadeiro se removeu o cliente com sucesso.</returns>
        public static bool RemoverCliente(Cliente c)
        {
            //  !!! Adicionar Exceção
            if (!ExisteCliente(c)) return false;

            return listaClientes.Remove(c);
        }

        /// <summary>
        /// Remove o cliente da lista pelo código.
        /// </summary>
        /// <param name="c">Cliente a remover</param>
        /// <returns>Devolve verdadeiro se removeu o cliente com sucesso.</returns>
        public static bool RemoverCliente(int codigo)
        {
            //  !!! Adicionar Exceção
            if (!ExisteCliente(codigo)) return false;

            return listaClientes.Remove(EncontraCliente(codigo));
        }

        #endregion

        #endregion
    }
}
