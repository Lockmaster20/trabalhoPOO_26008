/*
*	<copyright file="Validacoes" company="IPCA"></copyright>
* 	<author>Diogo Fernandes</author>
*	<contact>a26008@alunos.ipca.pt</contact>
*   <date>12/9/2023 4:16:36 PM</date>
*	<description>Classe para validacoes</description>
**/

using System;

namespace Outros
{
    public class Validacoes
    {
        /// <summary>
        /// Método para verificar se existe sobreposição entre dois intervalos de data
        /// </summary>
        /// <param name="inicio1">Data de início da 1a data</param>
        /// <param name="fim1">Data de fim da 1a data</param>
        /// <param name="inicio2">Data de início da 2a data</param>
        /// <param name="fim2">Data de fim da 2a data</param>
        /// <returns>Se existir sobreposição de datas devolve verdadeiro, se não devolve falso.</returns>
        public static bool VerificaSobreposicaoDatas(DateTime inicio1, DateTime fim1, DateTime inicio2, DateTime fim2)
        {
            return inicio1 < fim2 && fim1 > inicio2;
        }

    }
}
