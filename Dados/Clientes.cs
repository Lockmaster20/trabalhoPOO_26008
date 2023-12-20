/*
*	<copyright file="Clientes" company="IPCA"></copyright>
* 	<author>Diogo Fernandes</author>
*	<contact>a26008@alunos.ipca.pt</contact>
*   <date>12/9/2023 6:20:18 PM</date>
*	<description>Lista de clientes</description>
**/

using Excecoes;
using ObjetosNegocio;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Dados
{
    public class Clientes
    {
        #region Atributos

        const string NOMEFICHEIRO = "clientes.bin";

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
        public static List<Cliente> ListaClientes 
        { 
            get { return listaClientes.ToList(); } 
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
        /// <param name="c">Cliente a verificar</param>
        /// <returns>Devolve verdadeiro se existe ou falso se não existe.</returns>
        public static bool ExisteCliente(Cliente c)
        {
            return listaClientes.Contains(c);
        }

        /// <summary>
        /// Método para verificar se a lista tem o cliente através do código.
        /// </summary>
        /// <param name="codigo">Código a verificar</param>
        /// <returns>Devolve verdadeiro se existe ou falso se não existe</returns>
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
        /// <returns>Devolve verdadeiro se conclui com sucesso.</returns>
        public static bool AdicionarCliente(Cliente c)
        {
            if (ExisteCliente(c))
            {
                //  !!! Uso de exceções apenas para testes
                throw new ClienteExisteException();
            }

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
            if (!ExisteCliente(c))
            {
                throw new ClienteExisteException("O cliente não existe.");
            }

            return listaClientes.Remove(c);
        }

        /// <summary>
        /// Remove o cliente da lista pelo código.
        /// </summary>
        /// <param name="codigo">Cliente a remover</param>
        /// <returns>Devolve verdadeiro se removeu o cliente com sucesso.</returns>
        public static bool RemoverCliente(int codigo)
        {
            if (!ExisteCliente(codigo))
            {
                throw new ClienteExisteException("O cliente não existe.");
            }

            return listaClientes.Remove(EncontraCliente(codigo));
        }

        /// <summary>
        /// Método para remover todos os clientes da lista.
        /// </summary>
        /// <returns></returns>
        public static bool RemoverTodosClientes()
        {
            listaClientes.Clear();
            return true;
        }

        /// <summary>
        /// Método para ordenar a lista.
        /// </summary>
        public static void OrdenaLista()
        {
            listaClientes.Sort();
        }

        /// <summary>
        /// Método para ordenar a lista por nome do cliente.
        /// </summary>
        public static void OrdenaListaNome()
        {
            listaClientes.Sort(new PessoaPorNome());
        }

        public static bool GravaClientes()
        {
            Stream s = File.Open(NOMEFICHEIRO, FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, listaClientes);
            s.Close();
            return true;
        }

        public static bool CarregaClientes()
        {
            Stream s = File.Open(NOMEFICHEIRO, FileMode.Open);
            BinaryFormatter b = new BinaryFormatter();
            listaClientes = (List<Cliente>)b.Deserialize(s);
            s.Close();
            return true;
        }

        #endregion

        #endregion
    }
}
