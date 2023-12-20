/*
*	<copyright file="Alojamentos" company="IPCA"></copyright>
* 	<author>Diogo Fernandes</author>
*	<contact>a26008@alunos.ipca.pt</contact>
*   <date>12/18/2023 8:59:57 PM</date>
*	<description></description>
**/

using Excecoes;
using ObjetosNegocio;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Dados
{
    public class Alojamentos
    {
        #region Atributos

        const string NOMEFICHEIRO = "alojamentos.bin";

        static List<Alojamento> listaAlojamentos;

        #endregion

        #region Métodos

        #region Construtores

        /// <summary>
        /// Construtor estático de alojamentos
        /// </summary>
        static Alojamentos()
        {
            listaAlojamentos = new List<Alojamento>();
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Propriedade para o atributo ListaAlojamentos, pode obter a lista, mas não a pode alterar
        /// </summary>
        public static List<Alojamento> ListaAlojamentos
        {
            get { return listaAlojamentos.ToList(); }
        }

        #endregion

        #region Operadores

        #endregion

        #region Overrides

        #endregion

        #region Outros Métodos

        /// <summary>
        /// Método para verificar se a lista tem o alojamento.
        /// </summary>
        /// <param name="a">Alojamento a verificar</param>
        /// <returns>Devolve verdadeiro se existe ou falso se não existe</returns>
        public static bool ExisteAlojamento(Alojamento a)
        {
            return listaAlojamentos.Contains(a);
        }

        /// <summary>
        /// Método para verificar se a lista tem o alojamento através do código.
        /// </summary>
        /// <param name="codigo">Código a verificar</param>
        /// <returns>Devolve verdadeiro se existe ou falso se não existe</returns>
        public static bool ExisteAlojamento(int codigo)
        {
            if (EncontraAlojamento(codigo) == null) return false;

            return true;
        }

        /// <summary>
        /// Método para encontrar o alojamento com o código especificado.
        /// </summary>
        /// <param name="codigo">Código do alojamento a encontrar.</param>
        /// <returns>Devolve o alojamento com o código ou null se não encontrar.</returns>
        public static Alojamento EncontraAlojamento(int codigo)
        {
            return listaAlojamentos.Find(alojamento => alojamento.CodigoAlojamento == codigo);
        }

        /// <summary>
        /// Adiciona o alojamento na lista.
        /// </summary>
        /// <param name="a">Alojamento a adicionar.</param>
        /// <returns>Devolve verdadeiro se conclui com sucesso.</returns>
        public static bool AdicionarAlojamento(Alojamento a)
        {
            if (ExisteAlojamento(a))
            {
                throw new AlojamentoExisteException();
            }

            listaAlojamentos.Add(a);
            return true;
        }

        /// <summary>
        /// Remove o alojamento da lista.
        /// </summary>
        /// <param name="a">Alojamento a remover</param>
        /// <returns>Devolve verdadeiro se removeu o alojamento com sucesso.</returns>
        public static bool RemoverAlojamento(Alojamento a)
        {
            if (!ExisteAlojamento(a))
            {
                throw new AlojamentoExisteException("O alojamento não existe.");
            }

            return listaAlojamentos.Remove(a);
        }

        /// <summary>
        /// Remove o alojamento da lista pelo código.
        /// </summary>
        /// <param name="codigo">Alojamento a remover</param>
        /// <returns>Devolve verdadeiro se removeu o alojamento com sucesso.</returns>
        public static bool RemoverAlojamento(int codigo)
        {
            if (!ExisteAlojamento(codigo))
            {
                throw new AlojamentoExisteException("O alojamento não existe.");
            }

            return listaAlojamentos.Remove(EncontraAlojamento(codigo));
        }

        /// <summary>
        /// Método para remover todos os alojamentos da lista.
        /// </summary>
        /// <returns></returns>
        public static bool RemoverTodosClientes()
        {
            listaAlojamentos.Clear();
            return true;
        }

        /// <summary>
        /// Método para ordenar a lista.
        /// </summary>
        public static void OrdenaLista()
        {
            listaAlojamentos.Sort();
        }

            // !!! Terminar os sort
        /*
        /// <summary>
        /// Método para ordenar a lista por preco ascendente.
        /// </summary>
        public static void OrdenaListaPrecoAsc()
        {
            listaAlojamentos.Sort(new AlojamentoPorPrecoAsc());
        }

        /// <summary>
        /// Método para ordenar a lista por preco decrescente.
        /// </summary>
        public static void OrdenaListaPrecoDec()
        {
            listaAlojamentos.Sort(new AlojamentoPorPrecoDec());
        }*/

        public static bool GravaAlojamentos()
        {
            Stream s = File.Open(NOMEFICHEIRO, FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, listaAlojamentos);
            s.Close();
            return true;
        }

        public static bool CarregaAlojamentos()
        {
            Stream s = File.Open(NOMEFICHEIRO, FileMode.Open);
            BinaryFormatter b = new BinaryFormatter();
            listaAlojamentos = (List<Alojamento>)b.Deserialize(s);
            s.Close();
            return true;
        }

        #endregion

        #endregion
    }
}
