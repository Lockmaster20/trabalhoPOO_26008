/*
*	<copyright file="Funcionario" company="IPCA"></copyright>
* 	<author>Diogo Fernandes</author>
*	<contact>a26008@alunos.ipca.pt</contact>
*   <date>12/9/2023 2:02:35 AM</date>
*	<description>Classes para descrever um funcionário</description>
**/

using System;

namespace ObjetosNegocio
{
    public enum TipoCargo
    {
        Gestor,
        Empregado
    }

    [Serializable]
    public class Funcionario: Pessoa, IComparable<Funcionario>
    {
        #region Atributos

        //static int totalFuncionarios;

        int codigoFuncionario;
        TipoCargo cargo;

        #endregion

        #region Métodos

        #region Construtores

        /// <summary>
        /// Construtor de funcionário com base numa pessoa, um valor de código e um cargo.
        /// </summary>
        /// <param name="p">Pessoa em que o funcionário se baseia.</param>
        /// <param name="codigoFuncionario">Código do funcionário.</param>
        /// <param name="cargo">Cargo do funcionário.</param>
        public Funcionario(Pessoa p, int codigoFuncionario, TipoCargo cargo) : base(p)
        {
            this.codigoFuncionario = codigoFuncionario;
            this.cargo = cargo;

            //totalFuncionarios++;
        }

        #endregion

        #region Propriedades

        //public static int TotalFuncionarios 
        //{  
        //    get { return totalFuncionarios; }
        //    set { }
        //}

        /// <summary>
        /// Propriedade para o atributo CodigoFuncionario, pode obter o código do funcionário, mas não o pode alterar
        /// </summary>
        public int CodigoFuncionario
        {
            get { return codigoFuncionario; }
            set { }
        }

        /// <summary>
        /// Propriedade para o atributo Cargo
        /// </summary>
        public TipoCargo Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }

        #endregion

        #region Operadores

        #endregion

        #region Overrides

        /// <summary>
        /// Redefinição do método ToString.
        /// </summary>
        /// <returns>Devolve uma string com o formato redefinido do funcionário.</returns>
        public override string ToString()
        {
            return String.Format("{0} -> {1}, {2} ", base.ToString(), CodigoFuncionario.ToString(), Cargo.ToString());
        }

        /// <summary>
        /// Redefinição do método Equals, verifica se o objeto recebido é igual ao funcionário.
        /// </summary>
        /// <param name="objeto">Objeto a ser comparado com o funcionário.</param>
        /// <returns>
        /// Se forem a mesma pessoa ou tiverem os mesmos códigos, devolve verdadeiro, caso contrário devolve falso.
        /// </returns>
        public override bool Equals(object objeto)
        {
            if (objeto is Funcionario)
            {
                Funcionario f = (Funcionario)objeto;
                if ((this.CodigoFuncionario == f.CodigoFuncionario) || base.Equals(f))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Outros Métodos

        /// <summary>
        /// Método para comparar Funcionários.
        /// </summary>
        /// <param name="f">Funcionário a comparar.</param>
        /// <returns>Se o código do funcionário a comparar for menor devolve 1, se for maior devolve -1, se for igual 0.</returns>
        public int CompareTo(Funcionario f)
        {
            if (f is null) return 1;

            return CodigoFuncionario.CompareTo(f.CodigoFuncionario);
        }

        #endregion

        #endregion
    }
}
