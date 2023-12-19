/*
*	<copyright file="Funcionarios" company="IPCA"></copyright>
* 	<author>Diogo Fernandes</author>
*	<contact>a26008@alunos.ipca.pt</contact>
*   <date>12/18/2023 8:59:34 PM</date>
*	<description>Lista de funcionarios</description>
**/

using Excecoes;
using ObjetosNegocio;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Dados
{
    public class Funcionarios
    {
        #region Atributos

        const string NOMEFICHEIRO = "funcionarios.bin";

        static List<Funcionario> listaFuncionarios;

        #endregion

        #region Métodos

        #region Construtores

        /// <summary>
        /// Construtor estático de funcionários
        /// </summary>
        static Funcionarios()
        {
            listaFuncionarios = new List<Funcionario>();
        }
        #endregion

        #region Propriedades

        #endregion

        #region Operadores

        #endregion

        #region Overrides

        #endregion

        #region Outros Métodos

        /// <summary>
        /// Método para verificar se a lista tem o funcionário.
        /// </summary>
        /// <param name="f">Funcionário a verificar</param>
        /// <returns>Devolve verdadeiro se existe ou falso se não existe</returns>
        public static bool ExisteFuncionario(Funcionario f)
        {
            return listaFuncionarios.Contains(f);
        }

        /// <summary>
        /// Método para verificar se a lista tem o funcionário através do código.
        /// </summary>
        /// <param name="codigo">Código a verificar</param>
        /// <returns>Devolve verdadeiro se existe ou falso se não existe</returns>
        public static bool ExisteFuncionario(int codigo)
        {
            if (EncontraFuncionario(codigo) == null) return false;

            return true;
        }

        /// <summary>
        /// Método para encontrar o funcionário com o código especificado.
        /// </summary>
        /// <param name="codigo">Código do funcionário a encontrar.</param>
        /// <returns>Devolve o funcionário com o código ou null se não encontrar.</returns>
        public static Funcionario EncontraFuncionario(int codigo)
        {
            return listaFuncionarios.Find(funcionario => funcionario.CodigoFuncionario == codigo);
        }

        /// <summary>
        /// Adiciona o funcionário na lista.
        /// </summary>
        /// <param name="f">Funcionário a adicionar.</param>
        /// <returns>Devolve verdadeiro se conclui com sucesso.</returns>
        public static bool AdicionarFuncionario(Funcionario f)
        {
            if (ExisteFuncionario(f))
            {
                throw new FuncionarioExisteException();
            }

            listaFuncionarios.Add(f);
            return true;
        }

        /// <summary>
        /// Remove o funcionário da lista.
        /// </summary>
        /// <param name="f">Funcionário a remover</param>
        /// <returns>Devolve verdadeiro se removeu o funcionário com sucesso.</returns>
        public static bool RemoverFuncionario(Funcionario f)
        {
            if (!ExisteFuncionario(f))
            {
                throw new FuncionarioExisteException("O funcionário não existe.");
            }

            return listaFuncionarios.Remove(f);
        }

        /// <summary>
        /// Remove o funcionário da lista pelo código.
        /// </summary>
        /// <param name="codigo">Funcionário a remover</param>
        /// <returns>Devolve verdadeiro se removeu o funcionário com sucesso.</returns>
        public static bool RemoverFuncionario(int codigo)
        {
            //  !!! Adicionar Exceção
            if (!ExisteFuncionario(codigo)) return false;

            return listaFuncionarios.Remove(EncontraFuncionario(codigo));
        }

        /// <summary>
        /// Método para remover todos os funcionários da lista.
        /// </summary>
        /// <returns></returns>
        public static bool RemoverTodosFuncionarios()
        {
            listaFuncionarios.Clear();
            return true;
        }

        /// <summary>
        /// Método para ordenar a lista.
        /// </summary>
        public static void OrdenaLista()
        {
            listaFuncionarios.Sort();
        }

        /// <summary>
        /// Método para ordenar a lista por nome do funcionário.
        /// </summary>
        public static void OrdenaListaNome()
        {
            listaFuncionarios.Sort(new PessoaPorNome());
        }

        // !!! testar códigos guardar, carregar
        public static bool GravaFuncionarios()
        {
            Stream s = File.Open(NOMEFICHEIRO, FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, listaFuncionarios);
            s.Close();
            return true;
        }

        public static bool CarregaFuncionarios()
        {
            Stream s = File.Open(NOMEFICHEIRO, FileMode.Open);
            BinaryFormatter b = new BinaryFormatter();
            listaFuncionarios = (List<Funcionario>)b.Deserialize(s);
            s.Close();
            return true;
        }

        #endregion

        #endregion
    }
}
