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
            Estabelecimento estabelecimento;
            var nome = "nome teste";
            var telefone = "telefone teste";
            DateTime horaFechamento = new DateTime().Date;
            DateTime horaAbertura = new DateTime().Date;
            decimal precoMedio = 14.0M;
            bool aprovado = true;

            estabelecimento = new Estabelecimento(nome, telefone, endereco, listaCategorias, horaAbertura, horaFechamento, precoMedio, listaFotos, aprovado);

            Assert.IsTrue(estabelecimento.Nome == nome);
            Assert.IsTrue(estabelecimento.Telefone == telefone);
            Assert.IsTrue(estabelecimento.Categorias == listaCategorias);
            Assert.IsTrue(estabelecimento.HorarioAbertura == horaAbertura);
            Assert.IsTrue(estabelecimento.HorarioFechamento == horaFechamento);
            Assert.IsTrue(estabelecimento.PrecoMedio == precoMedio);
            Assert.IsTrue(estabelecimento.Fotos == listaFotos);
            Assert.IsTrue(estabelecimento.Aprovado == aprovado);
            Assert.IsTrue(estabelecimento.ValidarEntrada().Count == 0);
        }

        [TestMethod]
        public void Testar_Validar_De_Estabelecimento_Com_Nome_Nulo_Ou_Vazio()
        {
            Endereco endereco = new Endereco("rua teste", "numero teste", "", "", "Centro", "Porto Alegre", "Rio Grande do Sul", "96508060", 15.0M, 15.0M);
            List<Categoria> listaCategorias = new List<Categoria>();
            List<Foto> listaFotos = new List<Foto>();
            Estabelecimento estabelecimento;
            var nome = "";
            var telefone = "telefone teste";
            DateTime horaFechamento = new DateTime().Date;
            DateTime horaAbertura = new DateTime().Date;
            decimal precoMedio = 14.0M;
            bool aprovado = true;

            estabelecimento = new Estabelecimento(nome, telefone, endereco, listaCategorias, horaAbertura, horaFechamento, precoMedio, listaFotos, aprovado);

            Assert.IsTrue(estabelecimento.Nome == nome);
            Assert.IsTrue(estabelecimento.ValidarEntrada().Count == 1);
            Assert.IsTrue(estabelecimento.ValidarEntrada().Contains("Nome não pode ser nulo."));
        }

        [TestMethod]
        public void Testar_Validar_De_Estabelecimento_Com_Endereco_Nulo_Ou_Vazio()
        {
            Endereco endereco = null;
            List<Categoria> listaCategorias = new List<Categoria>();
            List<Foto> listaFotos = new List<Foto>();
            Estabelecimento estabelecimento;
            var nome = "nome teste";
            var telefone = "telefone teste";
            DateTime horaFechamento = new DateTime().Date;
            DateTime horaAbertura = new DateTime().Date;
            decimal precoMedio = 14.0M;
            bool aprovado = true;

            estabelecimento = new Estabelecimento(nome, telefone, endereco, listaCategorias, horaAbertura, horaFechamento, precoMedio, listaFotos, aprovado);

            Assert.IsTrue(estabelecimento.Endereco==null);
            Assert.IsTrue(estabelecimento.ValidarEntrada().Count == 1);
            Assert.IsTrue(estabelecimento.ValidarEntrada().Contains("Deve conter um Endereço atrelado ao Estabelecimento."));
        }

        [TestMethod]
        public void Testar_Validar_De_Estabelecimento_Com_Nome_Maior()
        {
            Endereco endereco = new Endereco("rua teste", "numero teste", "", "", "Centro", "Porto Alegre", "Rio Grande do Sul", "96508060", 15.0M, 15.0M);
            List<Categoria> listaCategorias = new List<Categoria>();
            List<Foto> listaFotos = new List<Foto>();
            Estabelecimento estabelecimento;
            var nome = "Preciso de um nome muito grande para esse estabelecimento. Tem que atingir 100 caracteres para fazer o teste";
            var telefone = "telefone teste";
            DateTime horaFechamento = new DateTime().Date;
            DateTime horaAbertura = new DateTime().Date;
            decimal precoMedio = 14.0M;
            bool aprovado = true;

            estabelecimento = new Estabelecimento(nome, telefone, endereco, listaCategorias, horaAbertura, horaFechamento, precoMedio, listaFotos, aprovado);

            Assert.IsTrue(estabelecimento.Nome == nome);
            Assert.IsTrue(estabelecimento.ValidarEntrada().Count == 1);
            Assert.IsTrue(estabelecimento.ValidarEntrada().Contains("Tamanho máximo 100 caracteres."));
        }

        [TestMethod]
        public void Testar_Validar_De_Estabelecimento_Com_Telefone_Nulo_Ou_Vazio()
        {
            Endereco endereco = new Endereco("rua teste", "numero teste", "", "", "Centro", "Porto Alegre", "Rio Grande do Sul", "96508060", 15.0M, 15.0M);
            List<Categoria> listaCategorias = new List<Categoria>();
            List<Foto> listaFotos = new List<Foto>();
            Estabelecimento estabelecimento;
            var nome = "nome teste";
            var telefone = "";
            DateTime horaFechamento = new DateTime().Date;
            DateTime horaAbertura = new DateTime().Date;
            decimal precoMedio = 14.0M;
            bool aprovado = true;

            estabelecimento = new Estabelecimento(nome, telefone, endereco, listaCategorias, horaAbertura, horaFechamento, precoMedio, listaFotos, aprovado);

            Assert.IsTrue(estabelecimento.Telefone == telefone);
            Assert.IsTrue(estabelecimento.ValidarEntrada().Count == 1);
            Assert.IsTrue(estabelecimento.ValidarEntrada().Contains("Telefone não pode ser nulo."));
        }

        [TestMethod]
        public void Testar_Validar_De_Estabelecimento_Com_Telefone_Maior()
        {
            Endereco endereco = new Endereco("rua teste", "numero teste", "", "", "Centro", "Porto Alegre", "Rio Grande do Sul", "96508060", 15.0M, 15.0M);
            List<Categoria> listaCategorias = new List<Categoria>();
            List<Foto> listaFotos = new List<Foto>();
            Estabelecimento estabelecimento;
            var nome = "nome teste";
            var telefone = "+5551987654321982236511";
            DateTime horaFechamento = new DateTime().Date;
            DateTime horaAbertura = new DateTime().Date;
            decimal precoMedio = 14.0M;
            bool aprovado = true;

            estabelecimento = new Estabelecimento(nome, telefone, endereco, listaCategorias, horaAbertura, horaFechamento, precoMedio, listaFotos, aprovado);

            Assert.IsTrue(estabelecimento.Telefone == telefone);
            Assert.IsTrue(estabelecimento.ValidarEntrada().Count == 1);
            Assert.IsTrue(estabelecimento.ValidarEntrada().Contains("Tamanho máximo 20 caracteres."));
        }

        [TestMethod]
        public void Testar_Validar_De_Estabelecimento_Com_Preco_Medio_Nulo_Ou_Vazio()
        {
            Endereco endereco = new Endereco("rua teste", "numero teste", "", "", "Centro", "Porto Alegre", "Rio Grande do Sul", "96508060", 15.0M, 15.0M);
            List<Categoria> listaCategorias = new List<Categoria>();
            List<Foto> listaFotos = new List<Foto>();
            Estabelecimento estabelecimento;
            var nome = "nome teste";
            var telefone = "telefone teste";
            DateTime horaFechamento = new DateTime().Date;
            DateTime horaAbertura = new DateTime().Date;
            decimal precoMedio = 0M;
            bool aprovado = true;

            estabelecimento = new Estabelecimento(nome, telefone, endereco, listaCategorias, horaAbertura, horaFechamento, precoMedio, listaFotos, aprovado);

            Assert.IsTrue(estabelecimento.PrecoMedio == precoMedio);
            Assert.IsTrue(estabelecimento.ValidarEntrada().Count == 1);
            Assert.IsTrue(estabelecimento.ValidarEntrada().Contains("O Estabelecimento deve conter um preço médio."));
        }

        [TestMethod]
        public void Testar_Validar_De_Estabelecimento_Com_Lista_De_Fotos_Nulo_Ou_Vazio()
        {
            Endereco endereco = new Endereco("rua teste", "numero teste", "", "", "Centro", "Porto Alegre", "Rio Grande do Sul", "96508060", 15.0M, 15.0M);
            List<Categoria> listaCategorias = new List<Categoria>();
            List<Foto> listaFotos = null;
            Estabelecimento estabelecimento;
            var nome = "nome teste";
            var telefone = "telefone teste";
            DateTime horaFechamento = new DateTime().Date;
            DateTime horaAbertura = new DateTime().Date;
            decimal precoMedio = 15.4M;
            bool aprovado = true;

            estabelecimento = new Estabelecimento(nome, telefone, endereco, listaCategorias, horaAbertura, horaFechamento, precoMedio, listaFotos, aprovado);

            Assert.IsTrue(estabelecimento.Fotos == listaFotos);
            Assert.IsTrue(estabelecimento.Fotos == null);
            Assert.IsTrue(estabelecimento.Aprovado == aprovado);
            Assert.IsTrue(estabelecimento.ValidarEntrada().Count == 1);
            Assert.IsTrue(estabelecimento.ValidarEntrada().Contains("A Lista de Fotos não pode ser nula."));
        }

        [TestMethod]
        public void Testar_Validar_De_Estabelecimento_Com_Lista_De_Categorias_Nulo_Ou_Vazio()
        {
            Endereco endereco = new Endereco("rua teste", "numero teste", "", "", "Centro", "Porto Alegre", "Rio Grande do Sul", "96508060", 15.0M, 15.0M);
            List<Categoria> listaCategorias = null;
            List<Foto> listaFotos = new List<Foto>();
            Estabelecimento estabelecimento;
            var nome = "nome teste";
            var telefone = "telefone teste";
            DateTime horaFechamento = new DateTime().Date;
            DateTime horaAbertura = new DateTime().Date;
            decimal precoMedio = 15.4M;
            bool aprovado = true;

            estabelecimento = new Estabelecimento(nome, telefone, endereco, listaCategorias, horaAbertura, horaFechamento, precoMedio, listaFotos, aprovado);

            Assert.IsTrue(estabelecimento.Categorias == null);
            Assert.IsTrue(estabelecimento.Categorias == listaCategorias);
            Assert.IsTrue(estabelecimento.ValidarEntrada().Count == 1);
            Assert.IsTrue(estabelecimento.ValidarEntrada().Contains("A Lista de Categorias não pode ser nula."));
        }

        [TestMethod]
        public void Testar_Validar_De_Estabelecimento_Metodo_Esta_Aberto_Return_True()
        {
            Endereco endereco = new Endereco("rua teste", "numero teste", "", "", "Centro", "Porto Alegre", "Rio Grande do Sul", "96508060", 15.0M, 15.0M);
            List<Categoria> listaCategorias = null;
            List<Foto> listaFotos = new List<Foto>();
            Estabelecimento estabelecimento;
            var nome = "nome teste";
            var telefone = "telefone teste";
            DateTime horaFechamento = new DateTime().Date.AddHours(3);
            DateTime horaAbertura = new DateTime().Date;
            decimal precoMedio = 15.4M;
            bool aprovado = true;

            estabelecimento = new Estabelecimento(nome, telefone, endereco, listaCategorias, horaAbertura, horaFechamento, precoMedio, listaFotos, aprovado);

            Assert.IsTrue(estabelecimento.HorarioAbertura == horaAbertura);
            Assert.IsTrue(estabelecimento.HorarioFechamento == horaFechamento);
            Assert.IsTrue(estabelecimento.EstaAberto(new DateTime().Date));
        }

        [TestMethod]
        public void Testar_Validar_De_Estabelecimento_Metodo_Esta_Aberto_Return_False()
        {
            Endereco endereco = new Endereco("rua teste", "numero teste", "", "", "Centro", "Porto Alegre", "Rio Grande do Sul", "96508060", 15.0M, 15.0M);
            List<Categoria> listaCategorias = null;
            List<Foto> listaFotos = new List<Foto>();
            Estabelecimento estabelecimento;
            var nome = "nome teste";
            var telefone = "telefone teste";
            DateTime horaFechamento = new DateTime().Date.AddHours(12);
            DateTime horaAbertura = new DateTime().Date.AddHours(3);
            decimal precoMedio = 15.4M;
            bool aprovado = true;

            estabelecimento = new Estabelecimento(nome, telefone, endereco, listaCategorias, horaAbertura, horaFechamento, precoMedio, listaFotos, aprovado);

            Assert.IsTrue(estabelecimento.HorarioAbertura == horaAbertura);
            Assert.IsTrue(estabelecimento.HorarioFechamento == horaFechamento);
            Assert.IsFalse(estabelecimento.EstaAberto(new DateTime().Date));
        }


        [TestMethod]
        public void Testar_Validar_De_Estabelecimento_Metodo_Distancia_Coeficiente()
        {
            Endereco endereco = new Endereco("rua teste", "numero teste", "", "", "Centro", "Porto Alegre", "Rio Grande do Sul", "96508060", 0m, 0m);
            List<Categoria> listaCategorias = null;
            List<Foto> listaFotos = new List<Foto>();
            Estabelecimento estabelecimento;
            var nome = "nome teste";
            var telefone = "telefone teste";
            DateTime horaFechamento = new DateTime().Date.AddHours(12);
            DateTime horaAbertura = new DateTime().Date.AddHours(3);
            decimal precoMedio = 15.4M;
            bool aprovado = true;
            var latitude = 30m;
            var longitude = 40m;

            estabelecimento = new Estabelecimento(nome, telefone, endereco, listaCategorias, horaAbertura, horaFechamento, precoMedio, listaFotos, aprovado);
      
            var result = (402.5m - 50m)/402.5m;

            Assert.IsTrue(estabelecimento.DistanciaCoeficiente(latitude, longitude) == result);
        }

        [TestMethod]
        public void Testar_Validar_De_Estabelecimento_Metodo_Distancia_Estabelecimento()
        {
            Endereco endereco = new Endereco("rua teste", "numero teste", "", "", "Centro", "Porto Alegre", "Rio Grande do Sul", "96508060", 0m, 0m);
            List<Categoria> listaCategorias = null;
            List<Foto> listaFotos = new List<Foto>();
            Estabelecimento estabelecimento;
            var nome = "nome teste";
            var telefone = "telefone teste";
            DateTime horaFechamento = new DateTime().Date.AddHours(12);
            DateTime horaAbertura = new DateTime().Date.AddHours(3);
            decimal precoMedio = 15.4M;
            bool aprovado = true;
            var latitude = 30m;
            var longitude = 40m;

            estabelecimento = new Estabelecimento(nome, telefone, endereco, listaCategorias, horaAbertura, horaFechamento, precoMedio, listaFotos, aprovado);

            var result = 50m;

            Assert.IsTrue(estabelecimento.DistanciaEstabelecimento(latitude, longitude) == result);
        }


    }
}
