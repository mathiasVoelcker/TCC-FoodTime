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

        [TestMethod]
        public void Testar_Validar_De_Endereco_Com_Rua_Nula_Ou_Vazia()
        {
            Endereco endereco;
            var rua = "";
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
            Assert.IsTrue(endereco.ValidarEntrada().Count==1);
            Assert.IsTrue(endereco.ValidarEntrada().Contains("Rua não pode ser nula."));
        }

        [TestMethod]
        public void Testar_Validar_De_Endereco_Com_Rua_Maior()
        {
            Endereco endereco;
            var rua = "Llorem ipsum Llorem ipsum Llorem ipsum Llorem ipsum Llorem ipsum Llorem ipsum Llorem ipsum ";
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
            Assert.IsTrue(endereco.ValidarEntrada().Count == 1);
            Assert.IsTrue(endereco.ValidarEntrada().Contains("Tamanho máximo 50 caracteres."));
        }

        [TestMethod]
        public void Testar_Validar_De_Endereco_Com_Numero_Nulo_Ou_Vazio()
        {
            Endereco endereco;
            var rua = "rua teste";
            var numero = "";
            var apto = "";
            var complemento = "";
            var bairro = "Centro";
            var cidade = "Porto Alegre";
            var estado = "Rio Grande do Sul";
            var cep = "96508060";
            var latitude = 15.0M;
            var longitude = 15.0M;

            endereco = new Endereco(rua, numero, apto, complemento, bairro, cidade, estado, cep, latitude, longitude);

            Assert.IsTrue(endereco.Numero == numero);
            Assert.IsTrue(endereco.ValidarEntrada().Count == 1);
            Assert.IsTrue(endereco.ValidarEntrada().Contains("Numero não pode ser nulo."));
        }

        [TestMethod]
        public void Testar_Validar_De_Endereco_Com_Numero_Maior()
        {
            Endereco endereco;
            var rua = "rua teste";
            var numero = "Llorem ipsum Llorem ipsum Llorem ";
            var apto = "";
            var complemento = "";
            var bairro = "Centro";
            var cidade = "Porto Alegre";
            var estado = "Rio Grande do Sul";
            var cep = "96508060";
            var latitude = 15.0M;
            var longitude = 15.0M;

            endereco = new Endereco(rua, numero, apto, complemento, bairro, cidade, estado, cep, latitude, longitude);

            Assert.IsTrue(endereco.Numero == numero);
            Assert.IsTrue(endereco.ValidarEntrada().Count == 1);
            Assert.IsTrue(endereco.ValidarEntrada().Contains("Tamanho máximo 20 caracteres."));
        }

        [TestMethod]
        public void Testar_Validar_De_Endereco_Com_Bairro_Nulo_Ou_Vazio()
        {
            Endereco endereco;
            var rua = "rua teste";
            var numero = "369";
            var apto = "";
            var complemento = "";
            var bairro = "";
            var cidade = "Porto Alegre";
            var estado = "Rio Grande do Sul";
            var cep = "96508060";
            var latitude = 15.0M;
            var longitude = 15.0M;

            endereco = new Endereco(rua, numero, apto, complemento, bairro, cidade, estado, cep, latitude, longitude);

            Assert.IsTrue(endereco.Bairro == bairro);
            Assert.IsTrue(endereco.ValidarEntrada().Count == 1);
            Assert.IsTrue(endereco.ValidarEntrada().Contains("Bairro não pode ser nulo."));
        }

        [TestMethod]
        public void Testar_Validar_De_Endereco_Com_Bairro_Maior()
        {
            Endereco endereco;
            var rua = "rua teste";
            var numero = "369";
            var apto = "";
            var complemento = "";
            var bairro = "Llorem ipsum Llorem ipsum Llorem ipsum Llorem ipsum Llorem ipsum Llorem ipsum Llorem ";
            var cidade = "Porto Alegre";
            var estado = "Rio Grande do Sul";
            var cep = "96508060";
            var latitude = 15.0M;
            var longitude = 15.0M;

            endereco = new Endereco(rua, numero, apto, complemento, bairro, cidade, estado, cep, latitude, longitude);

            Assert.IsTrue(endereco.Bairro == bairro);
            Assert.IsTrue(endereco.ValidarEntrada().Count == 1);
            Assert.IsTrue(endereco.ValidarEntrada().Contains("Tamanho máximo 50 caracteres."));
        }


        [TestMethod]
        public void Testar_Validar_De_Endereco_Com_Cidade_Nulo_Ou_Vazio()
        {
            Endereco endereco;
            var rua = "rua teste";
            var numero = "369";
            var apto = "";
            var complemento = "";
            var bairro = "Centro";
            var cidade = "";
            var estado = "Rio Grande do Sul";
            var cep = "96508060";
            var latitude = 15.0M;
            var longitude = 15.0M;

            endereco = new Endereco(rua, numero, apto, complemento, bairro, cidade, estado, cep, latitude, longitude);

            Assert.IsTrue(endereco.Cidade == cidade);
            Assert.IsTrue(endereco.ValidarEntrada().Count == 1);
            Assert.IsTrue(endereco.ValidarEntrada().Contains("Cidade não pode ser nula."));
        }

        [TestMethod]
        public void Testar_Validar_De_Endereco_Com_Cidade_Maior()
        {
            Endereco endereco;
            var rua = "rua teste";
            var numero = "369";
            var apto = "";
            var complemento = "";
            var bairro = "Centro";
            var cidade = "Llorem ipsum Llorem ipsum Llorem ipsum Llorem ipsum Llorem ipsum Llorem ipsum Llorem ";
            var estado = "Rio Grande do Sul";
            var cep = "96508060";
            var latitude = 15.0M;
            var longitude = 15.0M;

            endereco = new Endereco(rua, numero, apto, complemento, bairro, cidade, estado, cep, latitude, longitude);

            Assert.IsTrue(endereco.Cidade == cidade);
            Assert.IsTrue(endereco.ValidarEntrada().Count == 1);
            Assert.IsTrue(endereco.ValidarEntrada().Contains("Tamanho máximo 50 caracteres."));
        }

        [TestMethod]
        public void Testar_Validar_De_Endereco_Com_Estado_Nulo_Ou_Vazio()
        {
            Endereco endereco;
            var rua = "rua teste";
            var numero = "369";
            var apto = "";
            var complemento = "";
            var bairro = "Centro";
            var cidade = "Porto Alegre";
            var estado = "";
            var cep = "96508060";
            var latitude = 15.0M;
            var longitude = 15.0M;

            endereco = new Endereco(rua, numero, apto, complemento, bairro, cidade, estado, cep, latitude, longitude);

            Assert.IsTrue(endereco.Estado == estado);
            Assert.IsTrue(endereco.ValidarEntrada().Count == 1);
            Assert.IsTrue(endereco.ValidarEntrada().Contains("Estado não pode ser nulo."));
        }

        [TestMethod]
        public void Testar_Validar_De_Endereco_Com_Estado_Maior()
        {
            Endereco endereco;
            var rua = "rua teste";
            var numero = "369";
            var apto = "";
            var complemento = "";
            var bairro = "Centro";
            var cidade = "Porto Alegre";
            var estado = "Llorem ipsum Llorem ipsum Llorem ipsum Llorem ipsum Llorem ipsum Llorem ipsum Llorem ";
            var cep = "96508060";
            var latitude = 15.0M;
            var longitude = 15.0M;

            endereco = new Endereco(rua, numero, apto, complemento, bairro, cidade, estado, cep, latitude, longitude);

            Assert.IsTrue(endereco.Estado == estado);
            Assert.IsTrue(endereco.ValidarEntrada().Count == 1);
            Assert.IsTrue(endereco.ValidarEntrada().Contains("Tamanho máximo 50 caracteres."));
        }

        [TestMethod]
        public void Testar_Validar_De_Endereco_Com_Cep_Nulo_Ou_Vazio()
        {
            Endereco endereco;
            var rua = "rua teste";
            var numero = "369";
            var apto = "";
            var complemento = "";
            var bairro = "Centro";
            var cidade = "Porto Alegre";
            var estado = "Rio Grande do Sul";
            var cep = "";
            var latitude = 15.0M;
            var longitude = 15.0M;

            endereco = new Endereco(rua, numero, apto, complemento, bairro, cidade, estado, cep, latitude, longitude);

            Assert.IsTrue(endereco.CEP == cep);
            Assert.IsTrue(endereco.ValidarEntrada().Count == 1);
            Assert.IsTrue(endereco.ValidarEntrada().Contains("CEP não pode ser nulo ou conter espaços."));
        }

        [TestMethod]
        public void Testar_Validar_De_Endereco_Com_Cep_Com_Espacos()
        {
            Endereco endereco;
            var rua = "rua teste";
            var numero = "369";
            var apto = "";
            var complemento = "";
            var bairro = "Centro";
            var cidade = "Porto Alegre";
            var estado = "Rio Grande do Sul";
            var cep = "96 508 060";
            var latitude = 15.0M;
            var longitude = 15.0M;

            endereco = new Endereco(rua, numero, apto, complemento, bairro, cidade, estado, cep, latitude, longitude);

           
            Assert.IsTrue(endereco.CEP == cep);
            //Espacos e CEP>8
            Assert.IsTrue(endereco.ValidarEntrada().Count == 2);
            Assert.IsTrue(endereco.ValidarEntrada().Contains("CEP não pode ser nulo ou conter espaços."));
        }

        [TestMethod]
        public void Testar_Validar_De_Endereco_Com_CEP_Maior()
        {
            Endereco endereco;
            var rua = "rua teste";
            var numero = "369";
            var apto = "";
            var complemento = "";
            var bairro = "Centro";
            var cidade = "Porto Alegre";
            var estado = "Rio Grande do Sul";
            var cep = "9650806096508060";
            var latitude = 15.0M;
            var longitude = 15.0M;

            endereco = new Endereco(rua, numero, apto, complemento, bairro, cidade, estado, cep, latitude, longitude);

            Assert.IsTrue(endereco.CEP == cep);
            Assert.IsTrue(endereco.ValidarEntrada().Count == 1);
            Assert.IsTrue(endereco.ValidarEntrada().Contains("Tamanho máximo 8 caracteres."));
        }

        [TestMethod]
        public void Testar_Validar_De_Endereco_Com_Latitude_Nula_Ou_Vazia()
        {
            Endereco endereco;
            var rua = "rua teste";
            var numero = "369";
            var apto = "";
            var complemento = "";
            var bairro = "Centro";
            var cidade = "Porto Alegre";
            var estado = "Rio Grande do Sul";
            var cep = "96508060";
            var latitude = 0M;
            var longitude = 15.0M;

            endereco = new Endereco(rua, numero, apto, complemento, bairro, cidade, estado, cep, latitude, longitude);

            Assert.IsTrue(endereco.Latitude == latitude);
            Assert.IsTrue(endereco.ValidarEntrada().Count == 1);
            Assert.IsTrue(endereco.ValidarEntrada().Contains("Latitude não pode ser nula."));
        }

        [TestMethod]
        public void Testar_Validar_De_Endereco_Com_Longitude_Nula_Ou_Vazia()
        {
            Endereco endereco;
            var rua = "rua teste";
            var numero = "369";
            var apto = "";
            var complemento = "";
            var bairro = "Centro";
            var cidade = "Porto Alegre";
            var estado = "Rio Grande do Sul";
            var cep = "96508060";
            var latitude = 15.1M;
            var longitude = 0M;

            endereco = new Endereco(rua, numero, apto, complemento, bairro, cidade, estado, cep, latitude, longitude);

            Assert.IsTrue(endereco.Longitude == longitude);
            Assert.IsTrue(endereco.ValidarEntrada().Count == 1);
            Assert.IsTrue(endereco.ValidarEntrada().Contains("Longitude não pode ser nula."));
        }

        [TestMethod]
        public void Testar_Comparar_Com_Retorno_True()
        {
            Endereco endereco;
            var rua = "rua teste";
            var numero = "369";
            var apto = "";
            var complemento = "";
            var bairro = "Centro";
            var cidade = "Porto Alegre";
            var estado = "Rio Grande do Sul";
            var cep = "96508060";
            var latitude = 15.1M;
            var longitude = 0M;
            var stringAComparar = "ua tes";

            endereco = new Endereco(rua, numero, apto, complemento, bairro, cidade, estado, cep, latitude, longitude);
            Assert.IsTrue(endereco.Comparar(stringAComparar));
        }

        [TestMethod]
        public void Testar_Comparar_Com_Retorno_False()
        {
            Endereco endereco;
            var rua = "rua teste";
            var numero = "369";
            var apto = "";
            var complemento = "";
            var bairro = "Centro";
            var cidade = "Porto Alegre";
            var estado = "Rio Grande do Sul";
            var cep = "96508060";
            var latitude = 15.1M;
            var longitude = 0M;
            var stringAComparar = "ua test ";

            endereco = new Endereco(rua, numero, apto, complemento, bairro, cidade, estado, cep, latitude, longitude);
            Assert.IsFalse(endereco.Comparar(stringAComparar));
        }
    }
}
