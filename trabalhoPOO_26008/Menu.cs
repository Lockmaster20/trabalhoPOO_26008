/*
*	<copyright file="Menu" company="IPCA"></copyright>
* 	<author>Diogo Fernandes</author>
*	<contact>a26008@alunos.ipca.pt</contact>
*   <date>12/22/2023 1:15:26 AM</date>
*	<description></description>
**/

namespace trabalhoPOO_26008
{
    public class Menu
    {
        public static void OpcoesMenu()
        {
            IO.MostraMenu();
            int opc = IO.ObterInt();
            IO.MostrarMensagem(opc.ToString());
        }

    }
}
