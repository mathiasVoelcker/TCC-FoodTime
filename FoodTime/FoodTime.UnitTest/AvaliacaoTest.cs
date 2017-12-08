using FoodTime.Dominio.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.UnitTest
{
    [TestClass]
    public class AvaliacaoTest
    {
        [TestMethod]
        public void Testar_Inicializacao_De_Avaliacao()
        {
            Avaliacao avaliacao;
            var nota = 10;
            var precoMedio = 5.5m;
            var comentario = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            var fotoAvaliacao = "teste";
            var recomentado = true;
            var dataAvaliacao = new DateTime(2010, 8, 18);

            avaliacao = new Avaliacao(nota, precoMedio, comentario, fotoAvaliacao, recomentado, dataAvaliacao, null, null);

            Assert.IsTrue(avaliacao.Nota == nota);
            Assert.IsTrue(avaliacao.PrecoMedio == precoMedio);
            Assert.IsTrue(avaliacao.Comentario == comentario);
            Assert.IsTrue(avaliacao.FotoAvaliacao == fotoAvaliacao);
            Assert.IsTrue(avaliacao.DataAvaliacao == dataAvaliacao);
            Assert.IsTrue(avaliacao.Recomendado == recomentado);
        }

        [TestMethod]
        public void Testar_ValidarEntrada_Nota_10()
        {
            Avaliacao avaliacao;
            var nota = 10;
            var precoMedio = 5.5m;
            var comentario = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            var fotoAvaliacao = "teste";
            var recomentado = true;
            var dataAvaliacao = new DateTime(2010, 8, 18);

            avaliacao = new Avaliacao(nota, precoMedio, comentario, fotoAvaliacao, recomentado, dataAvaliacao, null, null);

            Assert.IsTrue(avaliacao.ValidarEntrada().Count() == 0);
        }

        [TestMethod]
        public void Testar_ValidarEntrada_Nota_Zero()
        {
            Avaliacao avaliacao;
            var nota = 0;
            var precoMedio = 5.5m;
            var comentario = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            var fotoAvaliacao = "teste";
            var recomentado = true;
            var dataAvaliacao = new DateTime(2010, 8, 18);

            avaliacao = new Avaliacao(nota, precoMedio, comentario, fotoAvaliacao, recomentado, dataAvaliacao, null, null);

            Assert.IsTrue(avaliacao.ValidarEntrada().Count() == 0);
        }

        [TestMethod]
        public void Testar_ValidarEntrada_PrecoMedio_Zero()
        {
            Avaliacao avaliacao;
            var nota = 5;
            var precoMedio = 0m;
            var comentario = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            var fotoAvaliacao = "teste";
            var recomentado = true;
            var dataAvaliacao = new DateTime(2010, 8, 18);

            avaliacao = new Avaliacao(nota, precoMedio, comentario, fotoAvaliacao, recomentado, dataAvaliacao, null, null);

            Assert.IsTrue(avaliacao.ValidarEntrada().Count() == 0);
        }

        [TestMethod]
        public void Testar_ValidarEntrada_Comentario_500_Caracteres()
        {
            Avaliacao avaliacao;
            var nota = 5;
            var precoMedio = 5.5m;
            var comentario = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibu";
            var fotoAvaliacao = "teste";
            var recomentado = true;
            var dataAvaliacao = new DateTime(2010, 8, 18);

            avaliacao = new Avaliacao(nota, precoMedio, comentario, fotoAvaliacao, recomentado, dataAvaliacao, null, null);

            Assert.IsTrue(avaliacao.ValidarEntrada().Count() == 0);
        }

        [TestMethod]
        public void Testar_ValidarEntrada_Nota_Acima_De_Dez()
        {
            Avaliacao avaliacao;
            var nota = 11;
            var precoMedio = 5.5m;
            var comentario = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            var fotoAvaliacao = "teste";
            var recomentado = true;
            var dataAvaliacao = new DateTime(2010, 8, 18);

            avaliacao = new Avaliacao(nota, precoMedio, comentario, fotoAvaliacao, recomentado, dataAvaliacao, null, null);

            Assert.IsTrue(avaliacao.ValidarEntrada().Contains("Nota não pode ser maior que 10."));
        }

        [TestMethod]
        public void Testar_ValidarEntrada_Nota_Abaixo_De_Zero()
        {
            Avaliacao avaliacao;
            var nota = -1;
            var precoMedio = 5.5m;
            var comentario = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            var fotoAvaliacao = "teste";
            var recomentado = true;
            var dataAvaliacao = new DateTime(2010, 8, 18);

            avaliacao = new Avaliacao(nota, precoMedio, comentario, fotoAvaliacao, recomentado, dataAvaliacao, null, null);

            Assert.IsTrue(avaliacao.ValidarEntrada().Contains("Nota não pode ser menor que 0."));
        }

        [TestMethod]
        public void Testar_ValidarEntrada_PrecoMedio_Abaixo_De_Zero()
        {
            Avaliacao avaliacao;
            var nota = 5;
            var precoMedio = -0.1m;
            var comentario = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            var fotoAvaliacao = "teste";
            var recomentado = true;
            var dataAvaliacao = new DateTime(2010, 8, 18);

            avaliacao = new Avaliacao(nota, precoMedio, comentario, fotoAvaliacao, recomentado, dataAvaliacao, null, null);

            Assert.IsTrue(avaliacao.ValidarEntrada().Contains("Preço médio não pode ser negativo."));
        }

        [TestMethod]
        public void Testar_ValidarEntrada_Comentario_501_Caracteres()
        {
            Avaliacao avaliacao;
            var nota = 5;
            var precoMedio = 5.5m;
            var comentario = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibu.";
            var fotoAvaliacao = "teste";
            var recomentado = true;
            var dataAvaliacao = new DateTime(2010, 8, 18);

            avaliacao = new Avaliacao(nota, precoMedio, comentario, fotoAvaliacao, recomentado, dataAvaliacao, null, null);

            Assert.IsTrue(avaliacao.ValidarEntrada().Contains("O comentário não pode ter mais de 500 caracteres."));
        }

        [TestMethod]
        public void Testar_ValidarEntrada_Comentario_Nulo()
        {
            Avaliacao avaliacao;
            var nota = 5;
            var precoMedio = 5.5m;
            var comentario = "";
            var fotoAvaliacao = "teste";
            var recomentado = true;
            var dataAvaliacao = new DateTime(2010, 8, 18);

            avaliacao = new Avaliacao(nota, precoMedio, comentario, fotoAvaliacao, recomentado, dataAvaliacao, null, null);

            Assert.IsTrue(avaliacao.ValidarEntrada().Contains("Comentário não pode ser nulo."));
        }

        [TestMethod]
        public void Testar_ValidarEntrada_Comentario_Espaco_Em_Branco()
        {
            Avaliacao avaliacao;
            var nota = 5;
            var precoMedio = 5.5m;
            var comentario = " ";
            var fotoAvaliacao = "teste";
            var recomentado = true;
            var dataAvaliacao = new DateTime(2010, 8, 18);

            avaliacao = new Avaliacao(nota, precoMedio, comentario, fotoAvaliacao, recomentado, dataAvaliacao, null, null);

            Assert.IsTrue(avaliacao.ValidarEntrada().Contains("Comentário não pode ser nulo."));
        }

    }
}
