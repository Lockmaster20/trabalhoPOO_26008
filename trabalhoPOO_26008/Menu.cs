/*
*	<copyright file="Menu" company="IPCA"></copyright>
* 	<author>Diogo Fernandes</author>
*	<contact>a26008@alunos.ipca.pt</contact>
*   <date>12/22/2023 1:15:26 AM</date>
*	<description></description>
**/

using ObjetosNegocio;
using RegrasNegocio;
using System;

namespace trabalhoPOO_26008
{
    public class Menu
    {
        /// <summary>
        /// Método para adicionar um novo cliente à lista com os dados recebidos da consola.
        /// </summary>
        public static void AdicionarCliente()
        {
            IO.MostrarMensagem("Adicionar Cliente");

            IO.MostrarMensagem("Código:");
            int codigo = IO.ObterInt();

            IO.MostrarMensagem("Nome:");
            string nome = IO.ObterString();

            IO.MostrarMensagem("Sexo:");
            char sexo = IO.ObterChar();

            IO.MostrarMensagem("Número de Contribuinte:");
            int numeroContribuinte = IO.ObterInt();

            IO.MostrarMensagem("Crédito:");
            double credito = IO.ObterDouble();

            IO.LimparConsola();

            try
            {
                if (Regras.AdicionarCliente(new Cliente(new Pessoa(nome, sexo, numeroContribuinte), codigo, credito)))
                {
                    IO.MostrarMensagemSucesso("Cliente adiconado com sucesso.");
                }
                else IO.MostrarMensagemErro("Não foi possível criar o cliente.");
            }
            catch (Exception e)
            {
                IO.MostrarMensagemErro(e.Message);
            }
        }

        /// <summary>
        /// Método para remover um cliente da lista com o código recebido da consola.
        /// </summary>
        public static void RemoverCliente()
        {
            IO.MostrarMensagem("Remover Cliente");

            IO.MostrarMensagem("Código:");
            int codigo = IO.ObterInt();

            IO.LimparConsola();

            try
            {
                if (Regras.RemoverCliente(codigo))
                {
                    IO.MostrarMensagemSucesso("Cliente removido com sucesso.");
                }
                else IO.MostrarMensagemErro("Não foi possível remover o cliente.");
            }
            catch (Exception e)
            {
                IO.MostrarMensagemErro(e.Message);
            }
        }

        /// <summary>
        /// Método para adicionar um valor aos créditos do cliente da lista com o código recebido da consola.
        /// </summary>
        public static void AlterarCreditoCliente()
        {
            IO.MostrarMensagem("Alterar Crédito Cliente");

            IO.MostrarMensagem("Código:");
            int codigo = IO.ObterInt();

            IO.MostrarMensagem("Valor:");
            double valor = IO.ObterDouble();

            IO.LimparConsola();

            if (Regras.AlterarCreditoCliente(codigo, valor))
            {
                IO.MostrarMensagemSucesso("Crédito do cliente alterado com sucesso.");
            }
            else IO.MostrarMensagemErro("Não foi possível alterar o crédito do cliente.");
        }

        /// <summary>
        /// Método para adicionar um novo funcionário à lista com os dados recebidos da consola.
        /// </summary>
        public static void AdicionarFuncionario()
        {
            IO.MostrarMensagem("Adicionar Funcionário");

            IO.MostrarMensagem("Código:");
            int codigo = IO.ObterInt();

            IO.MostrarMensagem("Nome:");
            string nome = IO.ObterString();

            IO.MostrarMensagem("Sexo:");
            char sexo = IO.ObterChar();

            IO.MostrarMensagem("Número de Contribuinte:");
            int numeroContribuinte = IO.ObterInt();

            IO.MostrarMensagem("Tipo de Funcionario (1-Empregado; 2-Gestor):");
            TipoCargo tipo = TipoCargo.Empregado;

            bool sucesso = false;
            while (!sucesso)
            {
                int tipoInt = IO.ObterInt();
                switch (tipoInt)
                {
                    case 1:
                        sucesso = true;
                        break;
                    case 2:
                        tipo = TipoCargo.Gestor;
                        sucesso = true;
                        break;
                    default:
                        IO.MostrarMensagemErro("Valor inválido, tente novamente.");
                        break;
                }
            }

            IO.LimparConsola();

            try
            {
                if (Regras.AdicionarFuncionario(new Funcionario(new Pessoa(nome, sexo, numeroContribuinte), codigo, tipo)))
                {
                    IO.MostrarMensagemSucesso("Funcionário adiconado com sucesso.");
                }
                else IO.MostrarMensagemErro("Não foi possível criar o funcionário.");
            }
            catch (Exception e)
            {
                IO.MostrarMensagemErro(e.Message);
            }
        }

        /// <summary>
        /// Método para remover um funcionário da lista com o código recebido da consola.
        /// </summary>
        public static void RemoverFuncionario()
        {
            IO.MostrarMensagem("Remover Funcionário");

            IO.MostrarMensagem("Código:");
            int codigo = IO.ObterInt();

            IO.LimparConsola();

            try
            {
                if (Regras.RemoverFuncionario(codigo))
                {
                    IO.MostrarMensagemSucesso("Funcionário removido com sucesso.");
                }
                else IO.MostrarMensagemErro("Não foi possível remover o funcionário.");
            }
            catch (Exception e)
            {
                IO.MostrarMensagemErro(e.Message);
            }
        }

        /// <summary>
        /// Método para adicionar um novo alojamento à lista com os dados recebidos da consola.
        /// </summary>
        public static void AdicionarAlojamento()
        {
            IO.MostrarMensagem("Adicionar Alojamento");

            IO.MostrarMensagem("Código:");
            int codigo = IO.ObterInt();

            IO.MostrarMensagem("Rua:");
            string rua = IO.ObterString();

            IO.MostrarMensagem("Número:");
            int numero = IO.ObterInt();

            IO.MostrarMensagem("Código Postal:");
            string codigoPostal = IO.ObterString();

            IO.MostrarMensagem("Localidade:");
            string localidade = IO.ObterString();

            IO.MostrarMensagem("Número de Quartos:");
            int quartos = IO.ObterInt();

            IO.MostrarMensagem("Número de Camas:");
            int camas = IO.ObterInt();

            IO.MostrarMensagem("Número de Casas de Banho:");
            int casasBanho = IO.ObterInt();

            IO.MostrarMensagem("Número de Cozinhas:");
            int cozinhas = IO.ObterInt();

            IO.MostrarMensagem("Preço:");
            double preco = IO.ObterDouble();

            IO.LimparConsola();

            try
            {
                if (Regras.AdicionarAlojamento(new Alojamento(codigo, new Outros.Morada(rua, numero, codigoPostal, localidade), quartos, camas, casasBanho, cozinhas, preco)))
                {
                    IO.MostrarMensagemSucesso("Alojamento adiconado com sucesso.");
                }
                else IO.MostrarMensagemErro("Não foi possível criar o alojamento.");
            }
            catch (Exception e)
            {
                IO.MostrarMensagemErro(e.Message);
            }
        }

        /// <summary>
        /// Método para remover um alojamento da lista com o código recebido da consola.
        /// </summary>
        public static void RemoverAlojamento()
        {
            IO.MostrarMensagem("Remover Alojamento");

            IO.MostrarMensagem("Código:");
            int codigo = IO.ObterInt();

            IO.LimparConsola();

            try
            {
                if (Regras.RemoverAlojamento(codigo))
                {
                    IO.MostrarMensagemSucesso("Alojamento removido com sucesso.");
                }
                else IO.MostrarMensagemErro("Não foi possível remover o alojamento.");
            }
            catch (Exception e)
            {
                IO.MostrarMensagemErro(e.Message);
            }
        }

        /// <summary>
        /// Método para adicionar uma nova reserva à lista com os dados recebidos da consola.
        /// </summary>
        public static void AdicionarReserva()
        {
            IO.MostrarMensagem("Adicionar Reserva");

            IO.MostrarMensagem("Código do Alojamento:");
            int codigoAlojamento = IO.ObterInt();

            IO.MostrarMensagem("Código do Cliente:");
            int codigoCliente = IO.ObterInt();

            IO.MostrarMensagem("Código do Funcionário Gestor:");
            int codigoGestor = IO.ObterInt();

            IO.MostrarMensagem("Data de Início da Reserva:");
            DateTime dataInicio = IO.ObterDateTime();

            IO.MostrarMensagem("Data de Fim da Reserva:");
            DateTime dataFim = IO.ObterDateTime();

            IO.MostrarMensagem("Estado da Reserva (1-Aberta; 2-Fechada; 3-Cancelada):");
            EstadoReserva estado = EstadoReserva.Aberta;

            bool sucesso = false;
            while (!sucesso)
            {
                int estadoInt = IO.ObterInt();
                switch (estadoInt)
                {
                    case 1:
                        sucesso = true;
                        break;
                    case 2:
                        estado = EstadoReserva.Fechada;
                        sucesso = true;
                        break;
                    case 3:
                        estado = EstadoReserva.Cancelada;
                        sucesso = true;
                        break;
                    default:
                        IO.MostrarMensagemErro("Valor inválido, tente novamente.");
                        break;
                }
            }

            IO.LimparConsola();

            try
            {
                if (Regras.AdicionarReserva(new Reserva(codigoAlojamento, dataInicio, dataFim, codigoCliente, codigoGestor, estado)))
                {
                    IO.MostrarMensagemSucesso("Reserva adiconada com sucesso.");
                }
                else IO.MostrarMensagemErro("Não foi possível criar a reserva.");
            }
            catch (Exception e)
            {
                IO.MostrarMensagemErro(e.Message);
            }
        }

        /// <summary>
        /// Método para alterar o estado de uma reserva, ou remover a reserva da lista, de acordo com a opção recebida.
        /// Opção 1 para cancelar a reserva, 2 para terminar a reserva ou 3 para remover a reserva da lista.
        /// </summary>
        /// <param name="opcao"></param>
        public static void AlterarEstadoReserva(int opcao)
        {
            if (opcao == 1)
            {
                IO.MostrarMensagem("Cancelar Reserva");
            }
            else if (opcao == 2)
            {
                IO.MostrarMensagem("Terminar Reserva");
            }
            else if (opcao == 3)
            {
                IO.MostrarMensagem("Remover Reserva");
            }
            else
            {
                IO.MostrarMensagemErro();
                return;
            }

            IO.MostrarMensagem("Código do Alojamento:");
            int codigoAlojamento = IO.ObterInt();

            IO.MostrarMensagem("Código do Cliente:");
            int codigoCliente = IO.ObterInt();

            IO.MostrarMensagem("Data de Início da Reserva:");
            DateTime dataInicio = IO.ObterDateTime();

            IO.LimparConsola();

            switch (opcao)
            {
                case 1:
                    try
                    {
                        if (Regras.CancelarReserva(codigoAlojamento, codigoCliente, dataInicio))
                        {
                            IO.MostrarMensagemSucesso("Reserva cancelada com sucesso.");
                        }
                        else IO.MostrarMensagemErro("Não foi possível cancelar a reserva.");
                    }
                    catch (Exception e)
                    {
                        IO.MostrarMensagemErro(e.Message);
                    }
                    break;
                case 2:
                    try
                    {
                        if (Regras.TerminarReserva(codigoAlojamento, codigoCliente, dataInicio))
                        {
                            IO.MostrarMensagemSucesso("Reserva terminada com sucesso.");
                        }
                        else IO.MostrarMensagemErro("Não foi possível terminar a reserva.");
                    }
                    catch (Exception e)
                    {
                        IO.MostrarMensagemErro(e.Message);
                    }
                    break;
                case 3:
                    try
                    {
                        if (Regras.RemoverReserva(codigoAlojamento, codigoCliente, dataInicio))
                        {
                            IO.MostrarMensagemSucesso("Reserva removida com sucesso.");
                        }
                        else IO.MostrarMensagemErro("Não foi possível remover a reserva.");
                    }
                    catch (Exception e)
                    {
                        IO.MostrarMensagemErro(e.Message);
                    }
                    break;
            }
        }

        /// <summary>
        /// Método para realizar a ação escolhida.
        /// </summary>
        public static void OpcoesMenu()
        {
            bool sucesso = false;
            while (!sucesso)
            {
                IO.MostraMenu();
                int opc = IO.ObterInt();

                IO.LimparConsola();

                switch (opc)
                {
                    case 0:
                        sucesso = true;
                        break;
                    case 1:
                        AdicionarCliente();
                        break;
                    case 2:
                        RemoverCliente();
                        break;
                    case 3:
                        AlterarCreditoCliente();
                        break;
                    case 4:
                        AdicionarFuncionario();
                        break;
                    case 5:
                        RemoverFuncionario();
                        break;
                    case 6:
                        AdicionarAlojamento();
                        break;
                    case 7:
                        RemoverAlojamento();
                        break;
                    case 8:
                        AdicionarReserva();
                        break;
                    case 9:
                        AlterarEstadoReserva(1);
                        break;
                    case 10:
                        AlterarEstadoReserva(2);
                        break;
                    case 11:
                        AlterarEstadoReserva(3);
                        break;
                    case 20:
                        IO.MostraClientes(Regras.MostraListaClientes());
                        break;
                    case 21:
                        Regras.OrdenarClientes();
                        break;
                    case 22:
                        Regras.OrdenarClientesNome();
                        break;
                    case 30:
                        IO.MostraFuncionarios(Regras.MostraListaFuncionarios());
                        break;
                    case 31:
                        Regras.OrdenarFuncionarios();
                        break;
                    case 32:
                        Regras.OrdenarFuncionariosNome();
                        break;
                    case 40:
                        IO.MostraAlojamentos(Regras.MostraListaAlojamentos());
                        break;
                    case 41:
                        Regras.OrdenarAlojamentos();
                        break;
                    case 42:
                        Regras.OrdenarAlojamentosPrecoCre();
                        break;
                    case 43:
                        Regras.OrdenarAlojamentosPrecoDec();
                        break;
                    case 50:
                        IO.MostraReservas(Regras.MostraListaReservas());
                        break;
                    case 51:
                        Regras.OrdenarReservas();
                        break;
                    default:
                        IO.MostrarMensagemErro("Valor inválido, tente novamente.");
                        break;
                }
            }
        }

    }
}
