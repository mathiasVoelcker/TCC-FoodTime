using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoodTime.Dominio.Entidades;

namespace FoodTime.UnitTest
{
    [TestClass]
    public class EnderecoTest
    {
        [TestMethod]
        public void Testar_Inicializacao_De_Endereco()
        {
            Endereco endereco;
            var rua = "rua teste";
            var numero = "numero teste";
            var apto = "";
            var complemento = "";
            var bairro = "Centro";
            var cidade = "Porto Alegre";
            var estado = "Rio Grande do Sul";
            var cep = "96508060";
            var latitude = 15.0M;
            var longitude = 15.0M;

            endereco = new Endereco(rua, numero, apto, complemento, bairro, cidade, estado, cep, latitude, longitude);

            Assert.IsTrue(endereco.Rua == rua);
            Assert.IsTrue(endereco.Numero == numero);
            Assert.IsTrue(endereco.Apto == apto);
            Assert.IsTrue(endereco.Complemento == complemento);
            Assert.IsTrue(endereco.Bairro == bairro);
            Assert.IsTrue(endereco.Cidade == cidade);
            Assert.IsTrue(endereco.Estado == estado);
            Assert.IsTrue(endereco.CEP == cep);
            Assert.IsTrue(endereco.Latitude == latitude);
            Assert.IsTrue(endereco.Longitude == longitude);
        }
    }
}
