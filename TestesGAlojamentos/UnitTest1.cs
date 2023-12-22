using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ObjetosNegocio;
using Dados;
using Excecoes;
using Outros;
using System.Collections.Generic;

namespace TestesGAlojamentos
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestaAlterarCredito()
        {
            // Arrange
            double creditos = 200.34;
            double preco = 26.78;
            double esperado = 173.56;
            Pessoa p1 = new Pessoa("Maria", 'F', 999999999);
            Cliente c = new Cliente(p1, 1, creditos);

            // Act
            c.AlterarCredito(-preco);

            // Assert
            double obtido = c.Credito;
            Assert.AreEqual(esperado, obtido, 0.001, "Não alterou corretamente os créditos.");
        }

        [TestMethod]
        public void TestaSexoPessoa()
        {
            // Arrange
            char original = 'F';
            char alteracao = 'a';
            char esperado = 'O';
            Pessoa p1 = new Pessoa("Maria", original, 999999999);

            // Act
            p1.Sexo = alteracao;

            // Assert
            double obtido = p1.Sexo;
            Assert.AreEqual(esperado, obtido, 0.001, "Não alterou corretamente os dados.");
        }

        [TestMethod]
        public void TestaIntervaloDatas()
        {
            // Arrange
            DateTime data1 = new DateTime(2024, 1, 1);
            DateTime data2 = new DateTime(2024, 1, 16);
            DateTime data3 = new DateTime(2024, 1, 30);
            DateTime data4 = new DateTime(2024, 2, 4);

            // Act
            bool b1 = Validacoes.VerificaSobreposicaoDatas(data1, data3, data2, data4);

            // Assert
            Assert.IsTrue(b1, "Não verificou corretamente o intervalo de datas.");
        }
    }
}
