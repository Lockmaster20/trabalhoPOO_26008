/*
*	<copyright file="IO" company="IPCA"></copyright>
* 	<author>Diogo Fernandes</author>
*	<contact>a26008@alunos.ipca.pt</contact>
*   <date>12/18/2023 11:32:23 PM</date>
*	<description>Classe para interagir com o utilizador.</description>
**/

using ObjetosNegocio;
using System;
using System.Collections.Generic;

namespace trabalhoPOO_26008
{
    public class IO
    {
        /// <summary>
        /// Método para limpar a consola.
        /// </summary>
        public static void LimparConsola() 
        {
            Console.Clear();
        }

        /// <summary>
        /// Método para mostrar uma mensagem na consola.
        /// </summary>
        /// <param name="m">Mensagem a mostrar</param>
        public static void MostrarMensagem(string m) 
        { 
            Console.WriteLine(m);
        }

        /// <summary>
        /// Método para mostrar uma mensagem de sucesso na consola.
        /// </summary>
        public static void MostrarMensagemSucesso()
        {
            Console.WriteLine("Sucesso.");
        }

        /// <summary>
        /// Método para mostrar uma mensagem de sucesso, com uma mensagem recebida, na consola.
        /// </summary>
        /// <param name="m">Mensagem a mostrar</param>
        public static void MostrarMensagemSucesso(string m)
        {
            Console.WriteLine("Sucesso: " + m);
        }

        /// <summary>
        /// Método para mostrar uma mensagem de erro na consola.
        /// </summary>
        public static void MostrarMensagemErro()
        {
            Console.WriteLine("Erro.");
        }

        /// <summary>
        /// Método para mostrar uma mensagem de erro, com uma mensagem recebida, na consola.
        /// </summary>
        /// <param name="m">Mensagem a mostrar</param>
        public static void MostrarMensagemErro(string m)
        {
            Console.WriteLine("Erro: " + m);
        }

        /// <summary>
        /// Método para listar os clientes da lista na consola.
        /// </summary>
        /// <param name="lc">Lista de clientes</param>
        public static void MostraClientes(List<Cliente> lc)
        {
            Console.WriteLine("Clientes:");
            foreach (Cliente c in lc)
            {
                MostrarMensagem(c.ToString());
            }
        }

        /// <summary>
        /// Método para listar os funcionários da lista na consola.
        /// </summary>
        /// <param name="lf">Lista de funcionários</param>
        public static void MostraFuncionarios(List<Funcionario> lf)
        {
            Console.WriteLine("Funcionários:");
            foreach (Funcionario f in lf)
            {
                MostrarMensagem(f.ToString());
            }
        }

        /// <summary>
        /// Método para listar os alojamentos da lista na consola.
        /// </summary>
        /// <param name="la">Lista de alojamentos</param>
        public static void MostraAlojamentos(List<Alojamento> la)
        {
            Console.WriteLine("Alojamentos:");
            foreach (Alojamento a in la)
            {
                MostrarMensagem(a.ToString());
            }
        }

        /// <summary>
        /// Método para listar as reservas da lista na consola.
        /// </summary>
        /// <param name="lr">Lista de reservas</param>
        public static void MostraReservas(List<Reserva> lr)
        {
            Console.WriteLine("Reservas:");
            foreach (Reserva r in lr)
            {
                MostrarMensagem(r.ToString());
            }
        }

        /// <summary>
        /// Método para apresentar o menu de opções
        /// </summary>
        public static void MostraMenu()
        {
            Console.WriteLine("------- MENU -------");
            Console.WriteLine();
            Console.WriteLine("1 - Adicionar cliente");
            Console.WriteLine("2 - Remover cliente");
            Console.WriteLine("3 - Alterar crédito cliente");
            Console.WriteLine();
            Console.WriteLine("4 - Adicionar funcionário");
            Console.WriteLine("5 - Remover funcionário");
            Console.WriteLine();
            Console.WriteLine("6 - Adicionar alojamento");
            Console.WriteLine("7 - Remover alojamento");
            Console.WriteLine();
            Console.WriteLine("8 - Adicionar reserva");
            Console.WriteLine("9 - Cancelar reserva");
            Console.WriteLine("10 - Terminar reserva");
            Console.WriteLine("11 - Remover reserva");
            Console.WriteLine("---");
            Console.WriteLine("20 - Listar clientes");
            Console.WriteLine("21 - Ordenar lista clientes por código");
            Console.WriteLine("22 - Ordenar lista clientes por nome");
            Console.WriteLine();
            Console.WriteLine("30 - Listar funcionários");
            Console.WriteLine("31 - Ordenar lista funcionários por código");
            Console.WriteLine("32 - Ordenar lista funcionários por nome");
            Console.WriteLine();
            Console.WriteLine("40 - Listar alojamentos");
            Console.WriteLine("41 - Ordenar lista alojamentos por código");
            Console.WriteLine("42 - Ordenar lista alojamentos por preço crescente");
            Console.WriteLine("43 - Ordenar lista alojamentos por preço decrescente");
            Console.WriteLine();
            Console.WriteLine("50 - Listar reservas");
            Console.WriteLine("51 - Ordenar lista reservas por código");
            Console.WriteLine("52 - Ordenar lista reservas por data de início");

            Console.WriteLine("0 - Sair");

            Console.WriteLine("--------------------");
        }

        /// <summary>
        /// Método para obter um int da consola.
        /// </summary>
        /// <returns>Devolve o int recebido.</returns>
        public static int ObterInt()
        {
            int i;
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out i))
                {
                    return i;
                }
                else
                {
                    MostrarMensagemErro("O valor inserido não é válido, tente novamente.");
                }
            }
        }

        /// <summary>
        /// Método para obter um double da consola.
        /// </summary>
        /// <returns>Devolve o double recebido.</returns>
        public static double ObterDouble()
        {
            double d;
            while (true)
            {
                if (Double.TryParse(Console.ReadLine(), out d))
                {
                    return d;
                }
                else
                {
                    MostrarMensagemErro("O valor inserido não é válido, tente novamente.");
                }
            }
        }

        /// <summary>
        /// Método para obter uma string da consola.
        /// </summary>
        /// <returns>Devolve a string recebida.</returns>
        public static string ObterString()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Método para obter um DateTime da consola.
        /// </summary>
        /// <returns>Devolve o DateTime recebido.</returns>
        public static DateTime ObterDateTime()
        {
            DateTime d;
            while (true)
            {
                if (DateTime.TryParse(Console.ReadLine(), out d))
                {
                    return d;
                }
                else
                {
                    MostrarMensagemErro("O valor inserido não é válido, tente novamente.");
                }
            }
        }


        /// <summary>
        /// Método para obter um char da consola.
        /// </summary>
        /// <returns>Devolve o char recebido.</returns>
        public static char ObterChar()
        {
            char c;
            while (true)
            {
                if (Char.TryParse(Console.ReadLine(), out c))
                {
                    return c;
                }
                else
                {
                    MostrarMensagemErro("O valor inserido não é válido, tente novamente.");
                }
            }
        }
    }
}
