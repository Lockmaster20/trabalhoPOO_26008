/*
*	<copyright file="Reserva" company="IPCA"></copyright>
* 	<author>Diogo Fernandes</author>
*	<contact>a26008@alunos.ipca.pt</contact>
*   <date>12/9/2023 3:24:17 AM</date>
*	<description>Classe para descrever uma reserva</description>
**/

using Outros;
using System;

namespace ObjetosNegocio
{
    interface IReserva
    {
        int CalculaDias();
        bool AtualizaEstado(bool b);
    }

    public enum EstadoReserva
    {
        Aberta,
        Fechada,
        Cancelada
    }

    public class Reserva: IComparable<Reserva>, IReserva
    {
        #region Atributos

        static int totalReservas;

        int codigoAlojamento;
        DateTime dataInicio;
        DateTime dataFim;
        int codigoCliente;
        int codigoGestor;

        EstadoReserva estado;

        #endregion

        #region Métodos

        #region Construtores

        static Reserva()
        {
            totalReservas = 0;
        }

        /// <summary>
        /// Construtor de reserva com os dados completos.
        /// </summary>
        /// <param name="alojamento">Alojamento a reservar.</param>
        /// <param name="dataInicio">Data de início da reserva.</param>
        /// <param name="dataFim">Data de fim da reserva.</param>
        /// <param name="cliente">Cliente que faz a reserva.</param>
        /// <param name="gestor">Funcionário que gere a reserva.</param>
        /// <param name="estado">Estado da reserva.</param>
        public Reserva(int alojamento, DateTime dataInicio, DateTime dataFim, int cliente, int gestor, EstadoReserva estado)
        {
            this.codigoAlojamento = alojamento;
            this.dataInicio = dataInicio;
            this.dataFim = DefDataFim(dataFim);
            this.codigoCliente = cliente;
            this.codigoGestor = gestor;
            this.estado = estado;
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Propriedade para o atributo Alojamento, pode obter o alojamento, mas não o pode alterar
        /// </summary>
        public int CodigoAlojamento
        {
            get { return codigoAlojamento; }
        }

        /// <summary>
        /// Propriedade para o atributo DataInicio, pode obter a data de início, mas não a pode alterar
        /// </summary>
        public DateTime DataInicio
        {
            get { return dataInicio; }
        }

        /// <summary>
        /// Propriedade para o atributo DataFim, pode obter a data de fim, mas não a pode alterar
        /// </summary>
        public DateTime DataFim
        {
            get { return dataFim; }
        }

        /// <summary>
        /// Propriedade para o atributo Cliente, pode obter o cliente, mas não o pode alterar
        /// </summary>
        public int CodigoCliente
        {
            get { return codigoCliente; }
        }

        /// <summary>
        /// Propriedade para o atributo Gestor, pode obter o funcionário gestor, mas não o pode alterar
        /// </summary>
        public int Gestor
        {
            get { return codigoGestor; }
        }

        /// <summary>
        /// Propriedade para o atributo Estado, pode obter o estado da reserva, mas não o pode alterar
        /// </summary>
        public EstadoReserva Estado
        {
            get { return estado; }
        }

        #endregion

        #region Operadores

        #endregion

        #region Overrides

        /// <summary>
        /// Redefinição do método ToString.
        /// </summary>
        /// <returns>Devolve uma string com o formato redefinido da reserva.</returns>
        public override string ToString()
        {
            return String.Format("Cliente {0} reserva alojamento {1}, de {2} a {3}.", CodigoCliente.ToString(), CodigoAlojamento.ToString(), DataInicio.ToString(), DataFim.ToString());
        }

        /// <summary>
        /// Redefinição do método Equals, verifica se o objeto recebido é igual à morada.
        /// </summary>
        /// <param name="objeto">Objeto a ser comparado com a morada.</param>
        /// <returns>
        /// Se tiverem o mesmo alojamento e as datas sobrepõem-se devolve verdadeiro, caso contrário devolve falso.
        /// </returns>
        public override bool Equals(object objeto)
        {
            if (objeto is Reserva)
            {
                Reserva r = (Reserva)objeto;
                if ((this.CodigoAlojamento == r.CodigoAlojamento) && (Validacoes.VerificaSobreposicaoDatas(DataInicio, DataFim, r.DataInicio, r.DataFim)) && (this.Estado == r.Estado))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Outros Métodos

        /// <summary>
        /// Método para prevenir que a data de fim seja menor que a data de início.
        /// </summary>
        /// <param name="dataFim">Data final da reserva a comparar.</param>
        /// <returns>Se a data final for menor que a data inicial, devolve a data inicial, caso contrário devolve a data final recebida.</returns>
        private DateTime DefDataFim(DateTime dataFim)
        {
            if (DataInicio > dataFim)
                return dataInicio;

            return dataFim;
        }

        /// <summary>
        /// Método para calcular os dias entre as datas de fim e início.
        /// </summary>
        /// <returns>Devolve o número inteiro de dias entre as datas da reserva.</returns>
        public int CalculaDias()
        {
            return ((int)((DataFim - DataInicio).TotalDays));
        }

        /// <summary>
        /// Método para calcular o custo da reserva, obtem os dias da reserva e multiplica pelo preço recebido.
        /// </summary>
        /// <param name="preco">Preço por noite do alojamento</param>
        /// <returns>Devolve o total do preço da reserva.</returns>
        public double CalculaCusto(double preco)
        {
            return (-(CalculaDias() * preco));
        }

        /// <summary>
        /// Método para alterar o estado da reserva.
        /// </summary>
        /// <param name="b">True para fechar a reserva ou false para cancelar.</param>
        /// <returns>Devolve verdadeiro se houve alteração.</returns>
        public bool AtualizaEstado(bool b)
        {
            if (estado == EstadoReserva.Aberta)
            {
                if (b) 
                { 
                    estado = EstadoReserva.Fechada; 
                }
                else 
                {
                    estado = EstadoReserva.Cancelada;
                }
                return true;
            }

            return false;
        }

        /// <summary>
        /// Método para comparar Reservas.
        /// </summary>
        /// <param name="r">Reserva a comparar.</param>
        /// <returns>Se a data de início da reserva a comparar for menor devolve 1, se for maior devolve -1, se for igual 0.</returns>
        public int CompareTo(Reserva r)
        {
            if (r is null) return 1;

            return DataInicio.CompareTo(r.DataInicio);
        }

        #endregion

        #endregion
    }
}
