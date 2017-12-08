using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoodTime.Dominio.Entidades;

namespace FoodTime.UnitTest
{
    [TestClass]
    public class CategoriaTest
    {
        [TestMethod]
        public void Testar_Inicializacao_De_Categoria()
        {
            Categoria categoria;
            var descricao = "testeDescricao";

            categoria = new Categoria(descricao);

            Assert.IsTrue(categoria.Descricao == descricao);
        }

        [TestMethod]
        public void Testar_Inicializacao_De_Categoria_Com_Descricao_Maior()
        {
            Categoria categoria;
            var descricao = "Usando llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun";

            categoria = new Categoria(descricao);

            Assert.IsTrue(categoria.Descricao == descricao);
            Assert.IsTrue(categoria.ValidarEntrada().Count == 1);
        }

        [TestMethod]
        public void Testar_Inicializacao_De_Categoria_Com_Descricao_Nula()
        {
            Categoria categoria;
            var descricao = "";
            
            categoria = new Categoria(descricao);

            Assert.IsTrue(categoria.ValidarEntrada().Count==1);
            Assert.IsTrue(categoria.ValidarEntrada().Contains("Descricao não pode ser nulo."));

        }
    }
}
