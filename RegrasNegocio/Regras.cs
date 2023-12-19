/*
*	<copyright file="Regras" company="IPCA"></copyright>
* 	<author>Diogo Fernandes</author>
*	<contact>a26008@alunos.ipca.pt</contact>
*   <date>12/9/2023 7:09:44 PM</date>
*	<description>Regras de negócio</description>
**/

using ObjetosNegocio;
using Dados;
using Excecoes;
using System;

namespace RegrasNegocio
{
    public class Regras
    {
        #region Clientes

        public static bool AdicionarCliente(Cliente c)
        {
            //  !!! Adicionar regras
            //if(c.CodigoCliente > 0)
            try
            {
                return Clientes.AdicionarCliente(c);
            } 
            catch (ClienteExisteException e)
            {
                throw new Excecoes.ClienteExisteException(e.ToString());
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }

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

        public static bool ExisteCliente(int codigo)
        {
            return Clientes.ExisteCliente(codigo);
        }

        #endregion

        #region Funcionarios
        #endregion

        #region Alojamentos
        #endregion

        #region Reservas
        #endregion
    }
}
