/*
*	<copyright file="Pessoa" company="IPCA"></copyright>
* 	<author>Diogo Fernandes</author>
*	<contact>a26008@alunos.ipca.pt</contact>
*   <date>12/8/2023 10:06:14 PM</date>
*	<description>Classe para descrever uma pessoa</description>
**/

using Outros;
using System;
using System.Collections.Generic;

namespace ObjetosNegocio
{
    /// <summary>
    /// Classe para comparar duas pessoas pelo nome.
    /// </summary>
    public class PessoaPorNome: IComparer<Pessoa>
    {
        /// <summary>
        /// Compara duas pessoas.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>Devolve o valor de acordo com o nome das pessoas.</returns>
        public int Compare(Pessoa p1, Pessoa p2)
        {
            return p1.Nome.CompareTo(p2.Nome);
        }
    }

    [Serializable]
    public class Pessoa: IComparable<Pessoa>
    {
        #region Atributos

        const char DEFAULTSEXO = 'O';
        const int MAXCONTACTOS = 3;

        static int totalPessoas;

        string nome;
        char sexo;
        List<Contacto> contactos;
        int numeroContribuinte;

        #endregion

        #region Métodos

        #region Construtores

        static Pessoa()
        {
            totalPessoas = 0;
        }

        /// <summary>
        /// Construtor de pessoa por defeito.
        /// </summary>
        public Pessoa()
        {
            nome = String.Empty;
            sexo = DEFAULTSEXO;
            numeroContribuinte = -1;

            totalPessoas++;
        }

        /// <summary>
        /// Construtor de pessoa com dados, sem contactos.
        /// </summary>
        /// <param name="nome">Nome da pessoa.</param>
        /// <param name="sexo">Sexo da pessoa.</param>
        /// <param name="numeroContribuinte">Número de contribuinte da pessoa.</param>
        public Pessoa(string nome, char sexo, int numeroContribuinte)
        {
            this.nome = nome;
            this.sexo = DefSexo(sexo);
            this.numeroContribuinte = numeroContribuinte;

            totalPessoas++;
        }

        /// <summary>
        /// Construtor de pessoa com dados e contactos
        /// </summary>
        /// <param name="nome">Nome da pessoa.</param>
        /// <param name="sexo">Sexo da pessoa.</param>
        /// <param name="numeroContribuinte">Número de contribuinte da pessoa.</param>
        /// <param name="contactos">Contactos da pessoa.</param>
        public Pessoa(string nome, char sexo, int numeroContribuinte, List<Contacto> contactos)
        {
            this.nome = nome;
            this.sexo = DefSexo(sexo);
            if (contactos.Count <= MAXCONTACTOS)
            {
                this.contactos = contactos;
            }
            this.numeroContribuinte = numeroContribuinte;

            totalPessoas++;
        }

        /// <summary>
        /// Construtor de pessoa através de pessoa.
        /// </summary>
        /// <param name="p">Pessoa</param>
        public Pessoa(Pessoa p)
        {
            this.nome = p.Nome;
            this.sexo = p.Sexo;
            this.contactos = p.Contactos;
            this.numeroContribuinte = p.numeroContribuinte;
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Propriedade para o atributo TotalPessoas.
        /// </summary>
        public int TotalPessoas
        {
            get { return totalPessoas; }
            set { }
        }

        /// <summary>
        /// Propriedade para o atributo Nome.
        /// </summary>
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        /// <summary>
        /// Propriedade para o atributo Sexo.
        /// </summary>
        public char Sexo
        {
            get { return sexo; }
            set { sexo = DefSexo(value); }
        }

        /// <summary>
        /// Propriedade para o atributo Contactos.
        /// </summary>
        public List<Contacto> Contactos
        {
            get { return contactos; }
            set { if(value.Count <= MAXCONTACTOS) contactos = value; }
        }

        /// <summary>
        /// Propriedade para o atributo NumeroContribuinte.
        /// </summary>
        public int NumeroContribuinte
        {
            get { return numeroContribuinte; }
            set { numeroContribuinte = value; }
        }

        #endregion

        #region Operadores

        #endregion

        #region Overrides

        /// <summary>
        /// Redefinição do método ToString.
        /// </summary>
        /// <returns>Devolve uma string com o formato redefinido da pessoa.</returns>
        public override string ToString()
        {
            return String.Format("{0}({1})", Nome, NumeroContribuinte);
        }

        /// <summary>
        /// Redefinição do método Equals, verifica se o objeto recebido é igual à pessoa.
        /// </summary>
        /// <param name="objeto">Objeto a ser comparado com a pessoa.</param>
        /// <returns>
        /// Se tiverem o mesmo número de contribuinte, são considerados a mesma pessoa logo devolve verdadeiro, caso contrário devolve falso.
        /// </returns>
        public override bool Equals(object objeto)
        {
            if (objeto is Pessoa)
            {
                Pessoa p = (Pessoa)objeto;
                if (this.NumeroContribuinte == p.NumeroContribuinte)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Outros Métodos

        /// <summary>
        /// Método para estandardizar as opções do sexo da pessoa. 
        /// Recebe um carácter para o sexo da pessoa e devolve o valor correspondente aceite pelo programa.
        /// </summary>
        /// <param name="sexo">Carácter do sexo pretendido.</param>
        /// <returns>Caso o carácter seja 'M' ou 'F' devolve o carácter correspondente, caso contrário dolve o carácter por defeito.</returns>
        private char DefSexo(char sexo)
        {
            sexo = Char.ToUpper(sexo);
            switch (sexo)
            {
                case 'M':
                case 'F':
                    return sexo;
                default:
                    return DEFAULTSEXO;
            }
        }

        /// <summary>
        /// Método para comparar pessoas.
        /// </summary>
        /// <param name="p">Pessoa a comparar.</param>
        /// <returns>Se o valor do número de contribuinte a comparar for menor devolve 1, se for maior devolve -1, se for igual 0.</returns>
        public int CompareTo(Pessoa p)
        {
            if (p is null) return 1;

            return NumeroContribuinte.CompareTo(p.NumeroContribuinte);
        }

        #endregion

        #endregion
    }
}
