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
using System.IO;

namespace trabalhoPOO_26008
{
    class GereAlojamento
    {
        static void Main(string[] args)
        {
            /// Tenta carregar listas
            try
            {
                IO.MostrarMensagem(Regras.CarregaClientes().ToString());
                IO.MostrarMensagem(Regras.CarregaFuncionarios().ToString());
                IO.MostrarMensagem(Regras.CarregaAlojamentos().ToString());
                IO.MostrarMensagem(Regras.CarregaReservas().ToString());
            }
            catch (FileNotFoundException e)
            {
                IO.MostrarMensagemErro(e.Message);
            }
            catch (Exception ex)
            {
                IO.MostrarMensagemErro(ex.Message);
                return;
            }

            /// Apresenta menu para testar serviços implementados
            Menu.OpcoesMenu();

            /// Tenta guardar listas
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
        }
    }
}
