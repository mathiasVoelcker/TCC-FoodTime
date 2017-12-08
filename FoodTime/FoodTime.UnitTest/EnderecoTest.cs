using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FoodTime.UnitTest
{
    [TestClass]
    public class EnderecoTest
    {
        [TestMethod]
        public void Testar_Inicializacao_De_Endereco()
        {
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

            //usuario = new Endereco(email, senha, nome, sobrenome, fotoPerfil, dataNascimento, isAdmin);

            //Assert.IsTrue(usuario.Email == email);
            ////Assert.IsTrue(usuario.Senha == senha);
            //Assert.IsTrue(usuario.Nome == nome);
            //Assert.IsTrue(usuario.Sobrenome == sobrenome);
            //Assert.IsTrue(usuario.FotoPerfil == fotoPerfil);
            //Assert.IsTrue(usuario.DataNascimento == dataNascimento);
            //Assert.IsTrue(usuario.Admin == isAdmin);
        }
    }
}
