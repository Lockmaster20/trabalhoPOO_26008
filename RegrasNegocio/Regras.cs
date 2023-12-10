﻿/*
*	<copyright file="Regras" company="IPCA"></copyright>
* 	<author>Diogo Fernandes</author>
*	<contact>a26008@alunos.ipca.pt</contact>
*   <date>12/9/2023 7:09:44 PM</date>
*	<description>Regras de negócio</description>
**/

using ObjetosNegocio;
using Dados;

namespace RegrasNegocio
{
    public class Regras
    {
        #region Clientes

        public static bool AdicionarCliente(Cliente c)
        {
            //  !!! Adicionar regras
            return Clientes.AdicionarCliente(c);

        }

        public static bool RemoverCliente(Cliente c)
        {
            return Clientes.RemoverCliente(c);

        }

        public static bool RemoverCliente(int codigo)
        {
            //  !!! Adicionar regras
            return Clientes.RemoverCliente(codigo);

        }

        public static void OrdenarCliente()
        {
            Clientes.OrdenaListaNome();
        }

        #endregion
    }
}
