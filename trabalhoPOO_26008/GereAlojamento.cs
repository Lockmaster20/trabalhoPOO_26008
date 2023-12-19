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

            Pessoa p1 = new Pessoa("Marco", 'M', 100);
            Pessoa p2 = new Pessoa("Ana", 'f', 110);
            Pessoa p3 = new Pessoa("Bino", 'a', 99);
            Pessoa p4 = new Pessoa("Pess", 't', 01);

            Cliente cli1 = new Cliente(p3, 1, 123.42);
            Cliente cli2 = new Cliente(p1, 2);
            Cliente cli3 = new Cliente(p2, 3);
            Cliente cli4 = new Cliente(p4, 4);

            bool b1 = Regras.AdicionarCliente(cli1);
            bool b2 = Regras.AdicionarCliente(cli2);
            bool b3 = Regras.AdicionarCliente(cli3);
            bool b4 = Regras.AdicionarCliente(cli4);

            Regras.OrdenarCliente();

            bool b5 = Regras.AdicionarCliente(cli4);

            int tst = 0;
        }
    }
}
