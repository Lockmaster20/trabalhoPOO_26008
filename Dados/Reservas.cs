/*
*	<copyright file="Reservas" company="IPCA"></copyright>
* 	<author>Diogo Fernandes</author>
*	<contact>a26008@alunos.ipca.pt</contact>
*   <date>12/18/2023 9:00:15 PM</date>
*	<description></description>
**/

using Excecoes;
using ObjetosNegocio;
using Outros;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Dados
{
    public class Reservas
    {
        #region Atributos

        const string NOMEFICHEIRO = "reservas.bin";

        static List<Reserva> listaReservas;

        #endregion

        #region Métodos

        #region Construtores

        /// <summary>
        /// Construtor estático de reservas
        /// </summary>
        static Reservas()
        {
            listaReservas = new List<Reserva>();
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Propriedade para o atributo ListaReservas, pode obter a lista, mas não a pode alterar
        /// </summary>
        public List<Reserva> ListaReservas
        {
            get { return listaReservas; }
        }

        #endregion

        #region Operadores

        #endregion

        #region Overrides

        #endregion

        #region Outros Métodos

        /// <summary>
        /// Método para encontrar reservas do cliente.
        /// </summary>
        /// <param name="codigo">Código do cliente a encontrar.</param>
        /// <returns>Devolve uma lista das reservas do cliente.</returns>
        public static List<Reserva> EncontraReservasCliente(int codigo)
        {
            return listaReservas.FindAll(reservas => reservas.CodigoCliente == codigo);
        }

        /// <summary>
        /// Método para encontrar a reserva aberta do cliente.
        /// </summary>
        /// <param name="codigo">Código do cliente a encontrar.</param>
        /// <returns>Devolve a reserva aberta do cliente.</returns>
        public static Reserva EncontraReservaClienteAtiva(int codigo)
        {
            return listaReservas.Find(reserva => reserva.CodigoCliente == codigo && reserva.Estado == EstadoReserva.Aberta);
        }

        /// <summary>
        /// Método para verificar se o cliente tem
        /// </summary>
        /// <param name="codigoCliente"></param>
        /// <returns></returns>
        public static bool ExisteReservaCliente(int codigoCliente)
        {
            if (EncontraReservaClienteAtiva(codigoCliente) == null) return false;

            return true;
        }

        /// <summary>
        /// Método para encontrar a reserva aberta do alojamento.
        /// </summary>
        /// <param name="codigoAlojamento">Código do alojamento a encontrar.</param>
        /// <param name="dataInicio">Data de início da reserva a verificar.</param>
        /// <param name="dataFim">Data de fim da reserva a verificar.</param>
        /// <returns>Devolve a reserva ativa do alojamento no intervalo de datas.</returns>
        public static Reserva EncontraReservaAlojamentoAtiva(int codigoAlojamento, DateTime dataInicio, DateTime dataFim)
        {
            return listaReservas.Find(reserva => reserva.CodigoAlojamento == codigoAlojamento && reserva.Estado == EstadoReserva.Aberta && Validacoes.VerificaSobreposicaoDatas(reserva.DataInicio, reserva.DataFim, dataInicio, dataFim));
        }

        /// <summary>
        /// Método para verificar se um alojamento já tem uma reserva ativa no intervalo de datas.
        /// </summary>
        /// <param name="codigoAlojamento">Código do alojamento a encontrar.</param>
        /// <param name="dataInicio">Data de início da reserva a verificar.</param>
        /// <param name="dataFim">Data de fim da reserva a verificar.</param>
        /// <returns>Devolve verdadeiro se encontrar a reserva, ou falso se não encontrar.</returns>
        public static bool ExisteReservaAlojamento(int codigoAlojamento, DateTime dataInicio, DateTime dataFim)
        {
            if (EncontraReservaAlojamentoAtiva(codigoAlojamento, dataInicio, dataFim) == null) return false;

            return true;
        }

        /// <summary>
        /// Método para verificar se a lista tem a reserva.
        /// </summary>
        /// <param name="r">Reserva a verificar</param>
        /// <returns>Devolve verdadeiro se existe ou falso se não existe.</returns>
        public static bool ExisteReserva(Reserva r)
        {
            return listaReservas.Contains(r);
        }

        /// <summary>
        /// Adiciona reserva na lista.
        /// </summary>
        /// <param name="r">Reserva a adicionar</param>
        /// <returns>Devolve verdadeiro se conclui com sucesso ou falso se já existir a reserva.</returns>
        public static bool AdicionarReserva(Reserva r)
        {
            if (ExisteReserva(r))
            {
                return false;
            }

            listaReservas.Add(r);
            return true;
        }

        /// <summary>
        /// Remove o reserva da lista.
        /// </summary>
        /// <param name="r">Reserva a remover</param>
        /// <returns>Devolve verdadeiro se removeu a reserva com sucesso.</returns>
        public static bool RemoverReserva(Reserva r)
        {
            return listaReservas.Remove(r);
        }

        /// <summary>
        /// Método para remover todas as reservas da lista.
        /// </summary>
        /// <returns></returns>
        public static bool RemoverTodasReservas()
        {
            listaReservas.Clear();
            return true;
        }

        /// <summary>
        /// Método para ordenar a lista.
        /// </summary>
        public static void OrdenaLista()
        {
            listaReservas.Sort();
        }


        public static bool GravaClientes()
        {
            Stream s = File.Open(NOMEFICHEIRO, FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, listaReservas);
            s.Close();
            return true;
        }

        public static bool CarregaClientes()
        {
            Stream s = File.Open(NOMEFICHEIRO, FileMode.Open);
            BinaryFormatter b = new BinaryFormatter();
            listaReservas = (List<Cliente>)b.Deserialize(s);
            s.Close();
            return true;
        }

        #endregion

        #endregion
    }
}
