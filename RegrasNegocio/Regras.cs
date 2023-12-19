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

        /// <summary>
        /// Método para adicionar um cliente à lista de clientes. Só adiciona se os dados forem válidos.
        /// </summary>
        /// <param name="c">Cliente a adicionar.</param>
        /// <returns>Verdadeiro se adiconar com sucesso ou falso se não.</returns>
        /// <exception cref="ClienteExisteException"></exception>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Método para remover um cliente da lista de clientes.
        /// </summary>
        /// <param name="c">Cliente a remover.</param>
        /// <returns>Verdadeiro se remover com sucesso ou falso se não.</returns>
        public static bool RemoverCliente(Cliente c)
        {
            if (Reservas.ExisteReservaCliente(c.CodigoCliente))
            {
                return false;
            }

            return Clientes.RemoverCliente(c);

        }

        /// <summary>
        /// Método para remover um cliente da lista de clientes pelo código.
        /// </summary>
        /// <param name="codigo">Cliente a remover.</param>
        /// <returns>Verdadeiro se remover com sucesso ou falso se não.</returns>
        public static bool RemoverCliente(int codigo)
        {
            if (Reservas.ExisteReservaCliente(codigo))
            {
                return false;
            }

            return Clientes.RemoverCliente(codigo);
        }

        /// <summary>
        /// Método para ordenar a lista de clientes.
        /// </summary>
        public static void OrdenarClientes()
        {
            Clientes.OrdenaLista();
        }

        /// <summary>
        /// Método para ordenar a lista de clientes por nome.
        /// </summary>
        public static void OrdenarClientesNome()
        {
            Clientes.OrdenaListaNome();
        }

        #endregion

        #region Funcionarios

        /// <summary>
        /// Método para adicionar um funcionário à lista de funcionários. Só adiciona se os dados forem válidos.
        /// </summary>
        /// <param name="f">Funcionário a adicionar.</param>
        /// <returns>Verdadeiro se adiconar com sucesso ou falso se não.</returns>
        /// <exception cref="FuncionarioExisteException"></exception>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Método para remover um funcionário da lista de funcionários.
        /// </summary>
        /// <param name="f">Funcionário a remover.</param>
        /// <returns>Verdadeiro se remover com sucesso ou falso se não.</returns>
        public static bool RemoverFuncionario(Funcionario f)
        {

            if (Reservas.ExisteReservaFuncionario(f.CodigoFuncionario))
            {
                return false;
            }

            return Funcionarios.RemoverFuncionario(f);
        }

        /// <summary>
        /// Método para remover um funcionário da lista de funcionários pelo código.
        /// </summary>
        /// <param name="codigo">Funcionário a remover.</param>
        /// <returns>Verdadeiro se remover com sucesso ou falso se não.</returns>
        public static bool RemoverFuncionario(int codigo)
        {

            if (Reservas.ExisteReservaFuncionario(codigo))
            {
                return false;
            }

            return Funcionarios.RemoverFuncionario(codigo);
        }

        /// <summary>
        /// Método para ordenar a lista de funcionários.
        /// </summary>
        public static void OrdenarFuncionarios()
        {
            Funcionarios.OrdenaLista();
        }

        /// <summary>
        /// Método para ordenar a lista de funcionários por nome.
        /// </summary>
        public static void OrdenarFuncionariosNome()
        {
            Funcionarios.OrdenaListaNome();
        }

        #endregion

        #region Alojamentos

        /// <summary>
        /// Método para verificar se os dados de uma morada são válidos
        /// </summary>
        /// <param name="m">Morada a verificar.</param>
        /// <returns></returns>
        private static bool VerificaMorada(Morada m)
        {
            if (!String.IsNullOrEmpty(m.Rua) && !String.IsNullOrEmpty(m.CodigoPostal) && !String.IsNullOrEmpty(m.Localidade) && m.Numero >= 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Método para adicionar um alojamento à lista de alojamentos. Só adiciona se os dados forem válidos.
        /// </summary>
        /// <param name="a">Alojamento a adicionar.</param>
        /// <returns>Verdadeiro se adiconar com sucesso ou falso se não.</returns>
        /// <exception cref="AlojamentoExisteException"></exception>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Método para remover um alojamento da lista de alojamentos.
        /// </summary>
        /// <param name="a">Alojamento a remover.</param>
        /// <returns>Verdadeiro se remover com sucesso ou falso se não.</returns>
        public static bool RemoverAlojamento(Alojamento a)
        {
            if (Reservas.ExisteReservaAlojamento(a.CodigoAlojamento))
            {
                return false;
            }

            return Alojamentos.RemoverAlojamento(a);
        }

        /// <summary>
        /// Método para remover um alojamento da lista de alojamentos pelo código.
        /// </summary>
        /// <param name="codigo">Alojamento a remover.</param>
        /// <returns>Verdadeiro se remover com sucesso ou falso se não.</returns>
        public static bool RemoverAlojamento(int codigo)
        {

            if (Reservas.ExisteReservaAlojamento(codigo))
            {
                return false;
            }

            return Alojamentos.RemoverAlojamento(codigo);
        }

        /// <summary>
        /// Método para ordenar a lista de alojamentos.
        /// </summary>
        public static void OrdenarAlojamentos()
        {
            Alojamentos.OrdenaLista();
        }

        #endregion

        #region Reservas

        /// <summary>
        /// Método para calcular o custo de uma reserva.
        /// </summary>
        /// <param name="r">Reserva que se pretende calcular o custo.</param>
        /// <returns>Devolve o custo da reserva(Dias*Preço).</returns>
        private static double CalculaCustoReserva(Reserva r)
        {
            return (r.CalculaCusto(Alojamentos.EncontraAlojamento(r.CodigoAlojamento).Preco));
        }

        /// <summary>
        /// Método para adiconar uma reserva à lista de reservas. Só pode adicionar a reserva se reservar mais do que 0 dias, e se o cliente, o alojamento e o gestor existirem.
        /// Se a reserva a adicionar estiver aberta, verifica se o cliente tem créditos suficientes para fazer a reserva.
        /// Se se verificar, ao fazer a reserva, atualiza os créditos do cliente.
        /// </summary>
        /// <param name="r">Reserva a adicionar.</param>
        /// <returns>Verdadeiro se adiconar com sucesso ou falso se não.</returns>
        public static bool AdicionarReserva(Reserva r)
        {
            if (r.CalculaDias() > 0 && Clientes.ExisteCliente(r.CodigoCliente) && Alojamentos.ExisteAlojamento(r.CodigoAlojamento) && Funcionarios.ExisteFuncionarioGestor(r.Gestor))
            {
                if (r.Estado == EstadoReserva.Fechada || r.Estado == EstadoReserva.Cancelada)
                {
                    return Reservas.AdicionarReserva(r);
                } 
                else if(r.Estado == EstadoReserva.Aberta && Clientes.EncontraCliente(r.CodigoCliente).TemCreditoSuficiente(CalculaCustoReserva(r)) && !Reservas.ExisteReservaClienteAtiva(r.CodigoCliente) && !Reservas.ExisteReservaAlojamentoAtiva(r.CodigoAlojamento, r.DataInicio, r.DataFim))
                {  
                    if (Reservas.AdicionarReserva(r))
                    {
                        return Clientes.EncontraCliente(r.CodigoCliente).AlterarCredito(CalculaCustoReserva(r));
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Método para cancelar uma reserva. Só pode terminar uma reserva aberta. 
        /// Se cancelar 10 dias antes da data de início, devolve metade do valor da reserva ao cliente.
        /// </summary>
        /// <param name="r"></param>
        /// <returns>Verdadeiro se cancelar com sucesso ou falso se não.</returns>
        public static bool CancelarReserva(Reserva r)
        {
            if (r.Estado == EstadoReserva.Aberta)
            {
                if (Reservas.CancelarReserva(r))
                {
                    if ((r.DataInicio-DateTime.Now).Days >= 10)
                    {
                        return Clientes.EncontraCliente(r.CodigoCliente).AlterarCredito(-(CalculaCustoReserva(r)/2));
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Método para terminar uma reserva aberta. Só pode terminar depois da data de início da reserva.
        /// </summary>
        /// <param name="r">Reserva a terminar.</param>
        /// <returns>Verdadeiro se terminar com sucesso ou falso se não.</returns>
        public static bool TerminarReserva(Reserva r)
        {
            if (r.Estado == EstadoReserva.Aberta && r.DataInicio<DateTime.Now)
            {
                return Reservas.TerminarReserva(r);
            }
            return false;
        }

        /// <summary>
        /// Método para remover uma reserva da lista de reservas.
        /// </summary>
        /// <param name="r">Reserva a remover.</param>
        /// <returns>Verdadeiro se remover com sucesso ou falso se não.</returns>
        public static bool RemoverReserva(Reserva r)
        {
            return Reservas.RemoverReserva(r);
        }

        /// <summary>
        /// Método para ordenar a lista de reservas.
        /// </summary>
        public static void OrdenarReservas()
        {
            Reservas.OrdenaLista();
        }


        #endregion
    }
}
