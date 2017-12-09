using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoodTime.Dominio.Entidades;
using System.Collections.Generic;

namespace FoodTime.UnitTest
{
    [TestClass]
    public class EstabelecimentoTest
    {
        [TestMethod]
        public void Testar_Inicializacao_De_Estabelecimento()
        {
            Endereco endereco = new Endereco("rua teste", "numero teste", "", "", "Centro", "Porto Alegre", "Rio Grande do Sul", "96508060", 15.0M, 15.0M);
            List<Categoria> listaCategorias = new List<Categoria>();
            List<Foto> listaFotos = new List<Foto>();

            //Estabelecimento estabelecimento;
            //var nome = "nome teste";
            //var telefone = "telefone teste";
            //DateTime horaFechamento = new DateTime().Date;
            //DateTime horaAbertura = new DateTime().Date;
            //decimal precoMedio = 14.0M;
            //bool aprovado = true;
            //estabelecimento = new Estabelecimento(asda,);

            //Assert.IsTrue(endereco.Rua == rua);
            //Assert.IsTrue(endereco.Numero == numero);
            //Assert.IsTrue(endereco.Apto == apto);
            //Assert.IsTrue(endereco.Complemento == complemento);
            //Assert.IsTrue(endereco.Bairro == bairro);
            //Assert.IsTrue(endereco.Cidade == cidade);
            //Assert.IsTrue(endereco.Estado == estado);
            //Assert.IsTrue(endereco.CEP == cep);
            //Assert.IsTrue(endereco.Latitude == latitude);
            //Assert.IsTrue(endereco.Longitude == longitude);
        }

    }
}
