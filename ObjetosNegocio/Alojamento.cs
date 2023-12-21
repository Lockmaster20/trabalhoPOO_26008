/*
*	<copyright file="Alojamento" company="IPCA"></copyright>
* 	<author>Diogo Fernandes</author>
*	<contact>a26008@alunos.ipca.pt</contact>
*   <date>12/9/2023 3:13:44 AM</date>
*	<description>Classe para descrever um alojamento</description>
**/

using Outros;
using System;
using System.Collections.Generic;

namespace ObjetosNegocio
{
    /// <summary>
    /// Classe para comparar dois alojamentos pelo preço crescente.
    /// </summary>
    public class AlojamentoPorPreco : IComparer<Alojamento>
    {
        /// <summary>
        /// Compara duas pessoas.
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="a2"></param>
        /// <returns>Devolve o valor de acordo com o preço do alojamento.</returns>
        public int Compare(Alojamento a1, Alojamento a2)
        {
            return a1.Preco.CompareTo(a2.Preco);
        }
    }

    [Serializable]
    public class Alojamento: IComparable<Alojamento>
    {
        #region Atributos

        //static int totalAlojamentos;

        int codigoAlojamento;
        Morada morada;
        int quartos;
        int camas;
        int casasBanho;
        int cozinhas;
        double preco;

        #endregion

        #region Métodos

        #region Construtores

        //static Alojamento()
        //{
        //    totalAlojamentos = 0;
        //}

        /// <summary>
        /// Construtor de alojamento.
        /// </summary>
        /// <param name="codigoAlojamento">Código do alojamento.</param>
        public Alojamento(int codigoAlojamento)
        {
            this.codigoAlojamento = codigoAlojamento;
            morada = new Morada();
            quartos = -1;
            camas = -1;
            casasBanho = -1;
            cozinhas = -1;
            preco = 0;

            //totalAlojamentos++;
        }

        /// <summary>
        /// Construtor de alojamento com os dados completos.
        /// </summary>
        /// <param name="codigoAlojamento">Código do alojamento.</param>
        /// <param name="morada">Morada do alojamento.</param>
        /// <param name="quartos">Número de quartos do alojamento.</param>
        /// <param name="camas">Número de camas do alojamento.</param>
        /// <param name="casasBanho">Número de casas de banho do alojamento.</param>
        /// <param name="cozinhas">Número de cozinhas do alojamento.</param>
        /// <param name="preco">Preço por dia do alojamento.</param>
        public Alojamento(int codigoAlojamento, Morada morada, int quartos, int camas, int casasBanho, int cozinhas, double preco)
        {
            this.codigoAlojamento = codigoAlojamento;
            this.morada = morada;
            this.quartos = quartos;
            this.camas = camas;
            this.casasBanho = casasBanho;
            this.cozinhas = cozinhas;
            this.preco = preco;

            //totalAlojamentos++;
        }

        #endregion

        #region Propriedades

        //public static int TotalAlojamentos
        //{
        //    get { return totalAlojamentos; }
        //    set { }
        //}

        /// <summary>
        /// Propriedade para o atributo CodigoAlojamento, pode obter o código do alojamento, mas não o pode alterar
        /// </summary>
        public int CodigoAlojamento
        {
            get { return codigoAlojamento; }
            set { }
        }

        /// <summary>
        /// Propriedade para o atributo Morada.
        /// </summary>
        public Morada Morada
        {
            get { return morada; }
            set { morada = value; }
        }

        /// <summary>
        /// Propriedade para o atributo Quartos.
        /// </summary>
        public int Quartos
        {
            get { return quartos; }
            set { quartos = value; }
        }

        /// <summary>
        /// Propriedade para o atributo Camas.
        /// </summary>
        public int Camas
        {
            get { return camas; }
            set { quartos = value; }
        }

        /// <summary>
        /// Propriedade para o atributo CasasBanho.
        /// </summary>
        public int CasasBanho
        {
            get { return casasBanho; }
            set { casasBanho = value; }
        }

        /// <summary>
        /// Propriedade para o atributo Cozinhas.
        /// </summary>
        public int Cozinhas
        {
            get { return cozinhas; }
            set { cozinhas = value; }
        }

        /// <summary>
        /// Propriedade para o atributo Preco.
        /// </summary>
        public double Preco
        {
            get { return preco; }
            set { preco = value; }
        }

        #endregion

        #region Operadores

        #endregion

        #region Overrides

        /// <summary>
        /// Redefinição do método ToString.
        /// </summary>
        /// <returns>Devolve uma string com o formato redefinido do alojamento.</returns>
        public override string ToString()
        {
            return String.Format("Código: {0}; Morada: {1}; Quartos: {2}; Camas: {3};Casas de Banho: {4}; Cozinhas: {5}; Preço: {6:0.00}", CodigoAlojamento.ToString(), Morada.ToString(), Quartos.ToString(), Camas.ToString(), CasasBanho.ToString(), Cozinhas.ToString(), Preco);
        }

        /// <summary>
        /// Redefinição do método Equals, verifica se o objeto recebido é igual ao alojamento.
        /// </summary>
        /// <param name="objeto">Objeto a ser comparado com o alojamento.</param>
        /// <returns>
        /// Se tiverem o mesmo código ou os mesmos valores devolve verdadeiro, caso contrário devolve falso.
        /// </returns>
        public override bool Equals(object objeto)
        {
            if (objeto is Alojamento)
            {
                Alojamento a = (Alojamento)objeto;
                if (CodigoAlojamento == a.CodigoAlojamento || (Morada.Equals(a.Morada) && (Quartos == a.Quartos) && (Camas == a.Camas) && (CasasBanho == a.CasasBanho) && (Cozinhas == a.Cozinhas) && (Preco == a.Preco)))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Outros Métodos

        /// <summary>
        /// Método para comparar Alojamentos.
        /// </summary>
        /// <param name="a">Alojamento a comparar.</param>
        /// <returns>Se o código do alojamento a comparar for menor devolve 1, se for maior devolve -1, se for igual 0.</returns>
        public int CompareTo(Alojamento a)
        {
            if (a is null) return 1;

            return CodigoAlojamento.CompareTo(a.CodigoAlojamento);
        }

        #endregion

        #endregion
    }
}
