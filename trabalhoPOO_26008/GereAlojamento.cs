/*
*	<copyright file="GereAlojamento" company="IPCA"></copyright>
* 	<author>Diogo Fernandes</author>
*	<contact>a26008@alunos.ipca.pt - github.com/Lockmaster20</contact>
*   <date>12/8/2023 10:08:00 PM</date>
*	<description>Programa para a gestão de alojamentos turísticos.</description>
**/

using Outros;
using ObjetosNegocio;
using RegrasNegocio;
using System;
using System.Collections.Generic;

namespace trabalhoPOO_26008
{
    class GereAlojamento
    {
        static void Main(string[] args)
        {
            try
            {
                IO.MostrarMensagem(Regras.CarregaClientes().ToString());
                IO.MostrarMensagem(Regras.CarregaFuncionarios().ToString());
                IO.MostrarMensagem(Regras.CarregaAlojamentos().ToString());
                IO.MostrarMensagem(Regras.CarregaReservas().ToString());
            }
            catch (Exception ex)
            {
                IO.MostrarMensagemErro(ex.Message);
            }

            //Contacto c1 = new Contacto(TipoContacto.Telefone, "1");
            //Contacto c2 = new Contacto(TipoContacto.Fax, "2");
            //Contacto c3 = new Contacto(TipoContacto.Telefone, "3");
            //Contacto c4 = new Contacto(TipoContacto.Telefone, "4");
            //Contacto c5 = new Contacto(TipoContacto.Fax, "5");
            //Contacto c6 = new Contacto(TipoContacto.Email, "6");
            //Contacto c7 = new Contacto(TipoContacto.Email, "7");
            //Contacto c8 = new Contacto(TipoContacto.Email, "8");
            //Contacto c9 = new Contacto(TipoContacto.Telefone, "9");

            //List<Contacto> lc2 = new List<Contacto>();
            //lc2.Add(c2);
            //lc2.Add(c7);
            //lc2.Add(c8);

            //List<Contacto> lc3 = new List<Contacto>();
            //lc3.Add(c1);
            //lc3.Add(c3);
            //lc3.Add(c6);

            //Pessoa p1 = new Pessoa("Marco", 'M', 100);
            //Pessoa p2 = new Pessoa("Ana", 'f', 110);
            //Pessoa p3 = new Pessoa("Bino", 'a', 99);
            //Pessoa p4 = new Pessoa("Pess", 't', 01);

            //Cliente cli1 = new Cliente(p3, 1, 500.42);
            //Cliente cli2 = new Cliente(p1, 2);
            //Cliente cli3 = new Cliente(p2, 3);
            //Funcionario fun1 = new Funcionario(p4, 1, TipoCargo.Gestor);

            //Morada mor1 = new Morada("Rua de Cima", 2, "4700-132", "Braga");
            //Alojamento alo1 = new Alojamento(1, mor1, 3, 5, 2, 1, 20);

            //Reserva res1 = new Reserva(1, new DateTime(2024, 1, 1), new DateTime(2024, 1, 25), 1, 1, EstadoReserva.Aberta);
            //Reserva res2 = new Reserva(1, new DateTime(2024, 1, 15), new DateTime(2024, 1, 20), 2, 1, EstadoReserva.Aberta);

            //bool b1 = Regras.AdicionarCliente(cli1);
            //bool b2 = Regras.AdicionarCliente(cli2);
            //bool b3 = Regras.AdicionarCliente(cli3);
            //bool b4 = Regras.AdicionarFuncionario(fun1);
            //bool b5 = Regras.AdicionarAlojamento(alo1);

            //bool b6 = Regras.AdicionarReserva(res1);
            //bool b7 = Regras.AdicionarReserva(res2);

            //Regras.OrdenarClientesNome();


            //bool bl2 = Regras.CarregaClientes();

            //Pessoa p5 = new Pessoa("Pess5", 'M', 555);
            //Cliente cli5 = new Cliente(p5, 5);
            //bool a = Regras.AdicionarCliente(cli5);
            //Console.WriteLine("-----------------\n" + a.ToString());

            IO.MostrarMensagem("--------------------\n--------------------");
            IO.MostraClientes(Regras.MostraListaClientes());
            IO.MostrarMensagem("--------------------");
            IO.MostraFuncionarios(Regras.MostraListaFuncionarios());
            IO.MostrarMensagem("--------------------");
            IO.MostraAlojamentos(Regras.MostraListaAlojamentos());
            IO.MostrarMensagem("--------------------");
            IO.MostraReservas(Regras.MostraListaReservas());
            IO.MostrarMensagem("--------------------\n--------------------");

            try 
            {
                IO.MostrarMensagem(Regras.GravaClientes().ToString());
                IO.MostrarMensagem(Regras.GravaFuncionarios().ToString());
                IO.MostrarMensagem(Regras.GravaAlojamentos().ToString());
                IO.MostrarMensagem(Regras.GravaReservas().ToString());
            }
            catch (Exception ex)
            {
                IO.MostrarMensagemErro(ex.Message);
            }

            bool bl1 = true;
        }
    }
}
