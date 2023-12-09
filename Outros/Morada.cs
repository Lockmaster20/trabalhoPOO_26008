/*
*	<copyright file="Morada" company="IPCA"></copyright>
* 	<author>Diogo Fernandes</author>
*	<contact>a26008@alunos.ipca.pt</contact>
*   <date>12/9/2023 3:01:38 AM</date>
*	<description>Classe para descrever uma morada</description>
**/

using System;

namespace Outros
{
    [Serializable]
    public class Morada
    {
        #region Atributos

        string rua;
        int numero;
        string codigoPostal;
        string localidade;

        #endregion

        #region Métodos

        #region Construtores

        /// <summary>
        /// Construtor de morada por defeito.
        /// </summary>
        public Morada()
        {
            rua = string.Empty;
            numero = -1;
            codigoPostal = string.Empty;
            localidade = string.Empty;
        }

        /// <summary>
        /// Construtor de morada com os dados completos.
        /// </summary>
        /// <param name="rua">Rua da morada.</param>
        /// <param name="numero">Número da porta.</param>
        /// <param name="codigoPostal">Código postal da morada.</param>
        /// <param name="localidade">Localidade da morada.</param>
        public Morada(string rua, int numero, string codigoPostal, string localidade)
        {
            this.rua = rua;
            this.numero = DefNumero(numero);
            this.codigoPostal = codigoPostal;
            this.localidade = localidade;
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Propriedade para o atributo Rua.
        /// </summary>
        public string Rua
        {
            get { return rua; }
            set { rua = value; }
        }

        /// <summary>
        /// Propriedade para o atributo Numero.
        /// </summary>
        public int Numero
        {
            get { return numero; }
            set { numero = DefNumero(value); }
        }

        /// <summary>
        /// Propriedade para o atributo CodigoPostal.
        /// </summary>
        public string CodigoPostal
        {
            get { return codigoPostal; }
            set { codigoPostal = value; }
        }

        /// <summary>
        /// Propriedade para o atributo Localidade.
        /// </summary>
        public string Localidade
        {
            get { return localidade; }
            set { localidade = value; }
        }

        #endregion

        #region Operadores

        #endregion

        #region Overrides

        /// <summary>
        /// Redefinição do método ToString.
        /// </summary>
        /// <returns>Devolve uma string com o formato redefinido da morada.</returns>
        public override string ToString()
        {
            return String.Format("{0}, nº{1}, {2} {3}", Rua, Numero, CodigoPostal, Localidade);
        }

        /// <summary>
        /// Redefinição do método Equals, verifica se o objeto recebido é igual à morada.
        /// </summary>
        /// <param name="objeto">Objeto a ser comparado com a morada.</param>
        /// <returns>
        /// Se tiverem os mesmos valores devolve verdadeiro, caso contrário devolve falso.
        /// </returns>
        public override bool Equals(object objeto)
        {
            if (objeto is Morada)
            {
                Morada m = (Morada)objeto;
                if ((this.Rua == m.Rua) && (this.Numero == m.Numero) && (this.CodigoPostal == m.CodigoPostal) && (this.Localidade == m.Localidade))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Outros Métodos

        /// <summary>
        /// Método para não inserir um número não válido.
        /// </summary>
        /// <param name="numero">Número a verificar.</param>
        /// <returns>Se o número for válido devolve o seu valor, se não for válido define o número como -1.</returns>
        private int DefNumero(int numero)
        {
            if (numero < 0)
            {
                return (-1);
            }

            return numero;
        }

        #endregion

        #endregion
    }
}
