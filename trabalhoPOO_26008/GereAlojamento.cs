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
            //try
            //{
            //    IO.MostrarMensagem(Regras.CarregaClientes().ToString());
            //    IO.MostrarMensagem(Regras.CarregaFuncionarios().ToString());
            //    IO.MostrarMensagem(Regras.CarregaAlojamentos().ToString());
            //    IO.MostrarMensagem(Regras.CarregaReservas().ToString());
            //}
            //catch (Exception ex)
            //{
            //    IO.MostrarMensagemErro(ex.Message);
            //    return;
            //}

            Contacto c1 = new Contacto(TipoContacto.Telefone, "1");
            Contacto c2 = new Contacto(TipoContacto.Fax, "2");
            Contacto c3 = new Contacto(TipoContacto.Telefone, "3");
            Contacto c4 = new Contacto(TipoContacto.Telefone, "4");
            Contacto c5 = new Contacto(TipoContacto.Fax, "5");
            Contacto c6 = new Contacto(TipoContacto.Email, "6");
            Contacto c7 = new Contacto(TipoContacto.Email, "7");
            Contacto c8 = new Contacto(TipoContacto.Email, "8");
            Contacto c9 = new Contacto(TipoContacto.Telefone, "9");

            List<Contacto> lc2 = new List<Contacto>();
            lc2.Add(c2);
            lc2.Add(c7);
            lc2.Add(c8);

            List<Contacto> lc3 = new List<Contacto>();
            lc3.Add(c1);
            lc3.Add(c3);
            lc3.Add(c6);

            Pessoa p1 = new Pessoa("Marco", 'M', 100, lc2);
            Pessoa p2 = new Pessoa("Ana", 'f', 110, lc3);
            Pessoa p3 = new Pessoa("Bino", 'a', 99);
            Pessoa p4 = new Pessoa("Pess", 't', 01);

            Cliente cli1 = new Cliente(p3, 1, 5000);
            Cliente cli2 = new Cliente(p1, 2, 8000);
            Cliente cli3 = new Cliente(p2, 3);
            Funcionario fun1 = new Funcionario(p4, 1, TipoCargo.Gestor);

            Morada mor1 = new Morada("Rua de Cima", 2, "4700-132", "Braga");
            Alojamento alo1 = new Alojamento(1, mor1, 3, 5, 2, 1, 20);
            Alojamento alo2 = new Alojamento(2, mor1, 4, 4, 3, 1, 5);
            Alojamento alo3 = new Alojamento(3, mor1, 1, 2, 1, 1, 10);
            Alojamento alo4 = new Alojamento(4, mor1, 1, 3, 1, 1, 15);

            Reserva res1 = new Reserva(1, new DateTime(2024, 1, 1), new DateTime(2024, 1, 25), 1, 1, EstadoReserva.Aberta);
            Reserva res2 = new Reserva(1, new DateTime(2024, 1, 25), new DateTime(2024, 2, 26), 2, 1, EstadoReserva.Aberta);
            Reserva res3 = new Reserva(3, new DateTime(2024, 1, 25), new DateTime(2024, 2, 26), 1, 1, EstadoReserva.Cancelada);
            Reserva res4 = new Reserva(1, new DateTime(2023, 1, 25), new DateTime(2023, 2, 26), 3, 1, EstadoReserva.Fechada);

            try
            {
                IO.MostrarMensagem("cli1:" + Regras.AdicionarCliente(cli1).ToString());
                IO.MostrarMensagem("cli2:" + Regras.AdicionarCliente(cli2).ToString());
                IO.MostrarMensagem("cli3:" + Regras.AdicionarCliente(cli3).ToString());
                IO.MostrarMensagem("fun1:" + Regras.AdicionarFuncionario(fun1).ToString());
                IO.MostrarMensagem("alo3:" + Regras.AdicionarAlojamento(alo3).ToString());
                IO.MostrarMensagem("alo1:" + Regras.AdicionarAlojamento(alo1).ToString());
                IO.MostrarMensagem("alo2:" + Regras.AdicionarAlojamento(alo2).ToString());
                IO.MostrarMensagem("alo4:" + Regras.AdicionarAlojamento(alo4).ToString());
                IO.MostrarMensagem("res1:" + Regras.AdicionarReserva(res1).ToString());
                IO.MostrarMensagem("res2:" + Regras.AdicionarReserva(res2).ToString());
                IO.MostrarMensagem("res3:" + Regras.AdicionarReserva(res3).ToString());
                IO.MostrarMensagem("res4:" + Regras.AdicionarReserva(res4).ToString());
            }
            catch (Exception ex)
            {
                IO.MostrarMensagemErro(ex.Message);
                return;
            }

            Regras.OrdenarClientesNome();
            Regras.OrdenarAlojamentosPrecoDec();
            Regras.OrdenarReservas();

            IO.MostrarMensagem("--------------------\n--------------------");
            IO.MostraClientes(Regras.MostraListaClientes());
            IO.MostrarMensagem("--------------------");
            IO.MostraFuncionarios(Regras.MostraListaFuncionarios());
            IO.MostrarMensagem("--------------------");
            IO.MostraAlojamentos(Regras.MostraListaAlojamentos());
            IO.MostrarMensagem("--------------------");
            IO.MostraReservas(Regras.MostraListaReservas());
            IO.MostrarMensagem("--------------------\n--------------------");

            //IO.MostrarMensagem("Cancela 2:" + Regras.CancelarReserva(res2).ToString());
            
            //IO.MostrarMensagem("--------------------\n--------------------");
            //IO.MostraClientes(Regras.MostraListaClientes());
            //IO.MostrarMensagem("--------------------");
            //IO.MostraReservas(Regras.MostraListaReservas());
            //IO.MostrarMensagem("--------------------\n--------------------");

            //try 
            //{
            //    IO.MostrarMensagem(Regras.GravaClientes().ToString());
            //    IO.MostrarMensagem(Regras.GravaFuncionarios().ToString());
            //    IO.MostrarMensagem(Regras.GravaAlojamentos().ToString());
            //    IO.MostrarMensagem(Regras.GravaReservas().ToString());
            //}
            //catch (Exception ex)
            //{
            //    IO.MostrarMensagemErro(ex.Message);
            //}

            bool bl1 = true;
        }
    }
}
