/*
*	<copyright file="Excecoes" company="IPCA"></copyright>
* 	<author>Diogo Fernandes</author>
*	<contact>a26008@alunos.ipca.pt</contact>
*   <date>12/14/2023 4:45:48 PM</date>
*	<description></description>
**/


using System;

namespace Excecoes
{
    public class ClienteExisteException : ApplicationException
    {
        public ClienteExisteException() : base("O cliente já existe.") { }

        public ClienteExisteException(string s) : base(s) { }

        public ClienteExisteException(string s, Exception e)
        {
            throw new ClienteExisteException(e.Message + " - " + s);
        }
    }
    public class FuncionarioExisteException : ApplicationException
    {
        public FuncionarioExisteException() : base("O funcionário já existe.") { }

        public FuncionarioExisteException(string s) : base(s) { }

        public FuncionarioExisteException(string s, Exception e)
        {
            throw new FuncionarioExisteException(e.Message + " - " + s);
        }
    }
}
