/*
*	<copyright file="IReserva" company="IPCA"></copyright>
* 	<author>Diogo Fernandes</author>
*	<contact>a26008@alunos.ipca.pt</contact>
*   <date>12/20/2023 3:00:00 PM</date>
*	<description></description>
**/

namespace ObjetosNegocio
{
    interface IReserva
    {
        int CalculaDias();
        bool AtualizaEstado(bool b);
    }
}
