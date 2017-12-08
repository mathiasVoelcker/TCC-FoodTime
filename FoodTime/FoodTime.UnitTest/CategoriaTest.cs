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
        public void Testar_Inicializacao_De_Categoria_Com_Descricao_Invalida()
        {
            Categoria categoria;
            var descricao = "testeNome";

            categoria = new Categoria(descricao);

            Assert.IsTrue(categoria.Descricao == descricao);
        }
    }
}
