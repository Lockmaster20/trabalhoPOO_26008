/*
*	<copyright file="Cliente" company="IPCA"></copyright>
* 	<author>Diogo Fernandes</author>
*	<contact>a26008@alunos.ipca.pt</contact>
*   <date>12/9/2023 1:28:50 AM</date>
*	<description>Classes para descrever um cliente</description>
**/

using System;

namespace ObjetosNegocio
{
    [Serializable]
    public class Cliente: Pessoa, IComparable<Cliente>
    {
        #region Atributos

        //static int totalClientes;

        int codigoCliente;
        double credito;

        #endregion

        #region Métodos

        #region Construtores

        //static Cliente()
        //{
        //    totalClientes = 0;
        //}

        /// <summary>
        /// Construtor de cliente com base numa pessoa, e um valor de código.
        /// </summary>
        /// <param name="p">Pessoa em que o cliente se baseia.</param>
        /// <param name="codigoCliente">Código do cliente.</param>
        public Cliente(Pessoa p, int codigoCliente) : base(p)
        {
            this.codigoCliente = codigoCliente;
            credito = 0;

            //totalClientes++;
        }


        /// <summary>
        /// Construtor de cliente com base numa pessoa, um valor de código e um valor de crédito.
        /// </summary>
        /// <param name="p">Pessoa em que o cliente se baseia.</param>
        /// <param name="codigoCliente">Código do cliente.</param>
        /// <param name="credito">Crédito do cliente.</param>
        public Cliente(Pessoa p, int codigoCliente, double credito) : base(p)
        {
            this.codigoCliente = codigoCliente;
            this.credito = credito;

            //totalClientes++;
        }

        #endregion

        #region Propriedades

        //public static int TotalClientes
        //{
        //    get { return totalClientes; }
        //    set { }
        //}

        /// <summary>
        /// Propriedade para o atributo CodigoCliente, pode obter o código do cliente, mas não o pode alterar
        /// </summary>
        public int CodigoCliente
        {
            get { return codigoCliente; }
            set { }
        }

        /// <summary>
        /// Propriedade para o atributo Credito
        /// </summary>
        public double Credito
        {
            get { return credito; }
            set { credito = value; }
        }

        #endregion

        #region Operadores

        #endregion

        #region Overrides

        /// <summary>
        /// Redefinição do método ToString.
        /// </summary>
        /// <returns>Devolve uma string com o formato redefinido do cliente.</returns>
        public override string ToString()
        {
            return String.Format("{0} -> {1}: {2:0.00} ", base.ToString(), CodigoCliente.ToString(), Credito);
        }

        /// <summary>
        /// Redefinição do método Equals, verifica se o objeto recebido é igual ao cliente.
        /// </summary>
        /// <param name="objeto">Objeto a ser comparado com o cliente.</param>
        /// <returns>
        /// Se forem a mesma pessoa ou tiverem os mesmos códigos, devolve verdadeiro, caso contrário devolve falso.
        /// </returns>
        public override bool Equals(object objeto)
        {
            if (objeto is Cliente)
            {
                Cliente c = (Cliente)objeto;
                if ((this.CodigoCliente == c.CodigoCliente) || base.Equals(c))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Outros Métodos

        /// <summary>
        /// Método para alterar o valor do crédito do cliente, tendo em conta o valor anterior e o valor a adicionar.
        /// </summary>
        /// <param name="valorAlteracao">Valor da alteração esperada do crédito.</param>
        /// <returns>Devolve verdadeiro para confirmar a conclusão.</returns>
        public bool AlterarCredito(double valorAlteracao)
        {
            credito += valorAlteracao;
            return true;
        }

        /// <summary>
        /// Método para comparar Clientes.
        /// </summary>
        /// <param name="c">Cliente a comparar.</param>
        /// <returns>Se o código do cliente a comparar for menor devolve 1, se for maior devolve -1, se for igual 0.</returns>
        public int CompareTo(Cliente c)
        {
            if (c is null) return 1;

            return CodigoCliente.CompareTo(c.CodigoCliente);
        }

        /// <summary>
        /// Método para verificar se o cliente tem créditos suficientes para realizar uma ação, através de uma soma do valor recebido aos créditos do cliente.
        /// </summary>
        /// <param name="valor">Valor a somar a créditos</param>
        /// <returns>Devolve verdadeiro se a soma for superior ou igual a 0, devolve falso se for menor.</returns>
        public bool TemCreditoSuficiente(double valor)
        {
            if (credito + valor >= 0)
            {
                return true;
            }

            return false;
        }

        #endregion

        #endregion
    }
}
