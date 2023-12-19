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
using Outros;
using System;

namespace RegrasNegocio
{
    public class Regras
    {
        #region Clientes

        public static bool AdicionarCliente(Cliente c)
        {
            if(c.CodigoCliente > 0 && !String.IsNullOrEmpty(c.Nome) && c.Credito >= 0 && c.NumeroContribuinte > 0)
            {
                try
                {
                    return Clientes.AdicionarCliente(c);
                }
                catch (ClienteExisteException e)
                {
                    throw new ClienteExisteException(e.ToString());
                }
                catch (Exception e)
                {
                    throw new Exception(e.ToString());
                }
            }

            return false;
        }

        public static bool RemoverCliente(Cliente c)
        {
            if (Reservas.ExisteReservaCliente(c.CodigoCliente))
            {
                return false;
            }

            return Clientes.RemoverCliente(c);

        }

        public static bool RemoverCliente(int codigo)
        {
            if (Reservas.ExisteReservaCliente(codigo))
            {
                return false;
            }

            return Clientes.RemoverCliente(codigo);
        }

        public static void OrdenarClientes()
        {
            Clientes.OrdenaLista();
        }

        public static void OrdenarClientesNome()
        {
            Clientes.OrdenaListaNome();
        }

        #endregion

        #region Funcionarios

        public static bool AdicionarFuncionario(Funcionario f)
        {
            if (f.CodigoFuncionario> 0 && !String.IsNullOrEmpty(f.Nome) && f.NumeroContribuinte > 0)
            {
                try
                {
                    return Funcionarios.AdicionarFuncionario(f);
                }
                catch (FuncionarioExisteException e)
                {
                    throw new FuncionarioExisteException(e.ToString());
                }
                catch (Exception e)
                {
                    throw new Exception(e.ToString());
                }
            }

            return false;
        }

        public static bool RemoverFuncionario(Funcionario f)
        {

            if (Reservas.ExisteReservaFuncionario(f.CodigoFuncionario))
            {
                return false;
            }

            return Funcionarios.RemoverFuncionario(f);
        }

        public static bool RemoverFuncionario(int codigo)
        {

            if (Reservas.ExisteReservaFuncionario(codigo))
            {
                return false;
            }

            return Funcionarios.RemoverFuncionario(codigo);
        }

        public static void OrdenarFuncionarios()
        {
            Funcionarios.OrdenaLista();
        }

        public static void OrdenarFuncionariosNome()
        {
            Funcionarios.OrdenaListaNome();
        }

        #endregion

        #region Alojamentos
        private static bool VerificaMorada(Morada m)
        {
            if (!String.IsNullOrEmpty(m.Rua) && !String.IsNullOrEmpty(m.CodigoPostal) && !String.IsNullOrEmpty(m.Localidade) && m.Numero >= 0)
            {
                return true;
            }

            return false;
        }

        public static bool AdicionarAlojamento(Alojamento a)
        {
            if (a.CodigoAlojamento >= 0 && a.Cozinhas >= 0 && a.Quartos >= 0 && a.Camas >= 0 && a.CasasBanho >= 0 && a.Preco >= 0 && VerificaMorada(a.Morada))
            {
                try
                {
                    return Alojamentos.AdicionarAlojamento(a);
                }
                catch (AlojamentoExisteException e)
                {
                    throw new AlojamentoExisteException(e.ToString());
                }
                catch (Exception e)
                {
                    throw new Exception(e.ToString());
                }

            }

            return false;
        }

        public static bool RemoverAlojamento(Alojamento a)
        {
            if (Reservas.ExisteReservaAlojamento(a.CodigoAlojamento))
            {
                return false;
            }

            return Alojamentos.RemoverAlojamento(a);
        }

        public static bool RemoverAlojamento(int codigo)
        {

            if (Reservas.ExisteReservaAlojamento(codigo))
            {
                return false;
            }

            return Alojamentos.RemoverAlojamento(codigo);
        }

        public static void OrdenarAlojamentos()
        {
            Alojamentos.OrdenaLista();
        }

        #endregion

        #region Reservas

        public static bool AdicionarReserva(Reserva r)
        {
            //if (r.)
                // Se reserva aberta, returar preço aos creditos.
            return false;
        }


        #endregion
    }
}
