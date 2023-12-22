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
        public static void MostrarMensagem(string m) 
        { 
            Console.WriteLine(m);
        }

        public static void MostrarMensagemSucesso()
        {
            Console.WriteLine("Sucesso.");
        }

        public static void MostrarMensagemSucesso(string m)
        {
            Console.WriteLine("Sucesso:" + m);
        }

        public static void MostrarMensagemErro()
        {
            Console.WriteLine("Erro.");
        }

        public static void MostrarMensagemErro(string m)
        {
            Console.WriteLine("Erro:" + m);
        }

        public static void MostraClientes(List<Cliente> lc)
        {
            Console.WriteLine("Clientes:");
            foreach (Cliente c in lc)
            {
                MostrarMensagem(c.ToString());
            }
        }

        public static void MostraFuncionarios(List<Funcionario> lf)
        {
            Console.WriteLine("Funcionários:");
            foreach (Funcionario f in lf)
            {
                MostrarMensagem(f.ToString());
            }
        }

        public static void MostraAlojamentos(List<Alojamento> la)
        {
            Console.WriteLine("Alojamentos:");
            foreach (Alojamento a in la)
            {
                MostrarMensagem(a.ToString());
            }
        }

        public static void MostraReservas(List<Reserva> lr)
        {
            Console.WriteLine("Reservas:");
            foreach (Reserva r in lr)
            {
                MostrarMensagem(r.ToString());
            }
        }

        public static void MostraMenu()
        {
            Console.WriteLine("------- MENU -------");

            Console.WriteLine("1 - Adicionar cliente");
            Console.WriteLine("2 - Remover cliente");

            Console.WriteLine("3 - Adicionar funcionario");
            Console.WriteLine("4 - Remover funcionario");

            Console.WriteLine("5 - Adicionar alojamento");
            Console.WriteLine("6 - Remover alojamento");

            Console.WriteLine("7 - Adicionar reserva");
            Console.WriteLine("8 - Cancelar reserva");
            Console.WriteLine("9 - Remover reserva");

            Console.WriteLine("--------------------");
        }

        public static int ObterInt()
        {
            try
            {
                return Convert.ToInt32(Console.ReadLine());
            } 
            catch
            {
                return -1;
            }
        }
    }
}
