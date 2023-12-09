/*
*	<copyright file="Contacto" company="IPCA"></copyright>
* 	<author>Diogo Fernandes</author>
*	<contact>a26008@alunos.ipca.pt</contact>
*   <date>12/8/2023 10:08:00 PM</date>
*	<description>Classe para descrever um contacto</description>
**/

using System;

namespace Outros
{
    public enum TipoContacto
    {
        Telefone,
        Email,
        Fax
    }

    [Serializable]
    public class Contacto: IComparable<Contacto>
    {
        #region Atributos

        TipoContacto tipo;
        string valor;

        #endregion

        #region Métodos

        #region Construtores
        /// <summary>
        /// Construtor de contacto.
        /// </summary>
        /// <param name="tipo">Tipo do contacto a costruir.</param>
        /// <param name="valor">Valor do contacto a construir.</param>
        public Contacto(TipoContacto tipo, string valor)
        {
            this.tipo = tipo;
            this.valor = valor;
        }
        #endregion

        #region Propriedades

        /// <summary>
        /// Propriedade para o atributo Tipo
        /// </summary>
        public TipoContacto Tipo 
        { 
            get { return tipo; }
            set { tipo = value; }
        }

        /// <summary>
        /// Propriedade para o atributo Valor
        /// </summary>
        public string Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        #endregion

        #region Operadores

        #endregion

        #region Overrides

        /// <summary>
        /// Redefinição do método ToString.
        /// </summary>
        /// <returns>Devolve uma string com o formato "tipo: valor" do contacto.</returns>
        public override string ToString()
        {
            return String.Format("{0}: {1}", Tipo.ToString(), Valor);
        }

        /// <summary>
        /// Redefinição do método Equals, verifica se o objeto recebido é igual ao contacto.
        /// </summary>
        /// <param name="objeto">Objeto a ser comparado com o contacto.</param>
        /// <returns>
        /// Se forem do mesmo tipo e tiverem os mesmos valores, devolve verdadeiro, caso contrário devolve falso.
        /// </returns>
        public override bool Equals(object objeto)
        {
            if (objeto is Contacto)
            {
                Contacto c = (Contacto)objeto;
                if ((this.Tipo == c.Tipo) && (this.Valor == c.Valor))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Outros Métodos

        /// <summary>
        /// Método para comparar contactos.
        /// </summary>
        /// <param name="c">Contacto a comparar.</param>
        /// <returns>Se o valor do contacto a comparar for menor devolve 1, se for maior devolve -1, se for igual 0.</returns>
        public int CompareTo(Contacto c) 
        {
            if (c is null) return 1;

            return Valor.CompareTo(c.Valor);
        }

        #endregion

        #endregion
    }
}
