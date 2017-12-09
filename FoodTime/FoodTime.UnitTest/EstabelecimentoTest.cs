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
            Assert.IsTrue(estabelecimento.Telefone == telefone);
            Assert.IsTrue(estabelecimento.Categorias == listaCategorias);
            Assert.IsTrue(estabelecimento.HorarioAbertura == horaAbertura);
            Assert.IsTrue(estabelecimento.HorarioFechamento == horaFechamento);
            Assert.IsTrue(estabelecimento.PrecoMedio == precoMedio);
            Assert.IsTrue(estabelecimento.Fotos == listaFotos);
            Assert.IsTrue(estabelecimento.Aprovado == aprovado);
            Assert.IsTrue(estabelecimento.ValidarEntrada().Count == 1);
            Assert.IsTrue(estabelecimento.ValidarEntrada().Contains("Nome não pode ser nulo."));
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
            Assert.IsTrue(estabelecimento.Telefone == telefone);
            Assert.IsTrue(estabelecimento.Categorias == listaCategorias);
            Assert.IsTrue(estabelecimento.HorarioAbertura == horaAbertura);
            Assert.IsTrue(estabelecimento.HorarioFechamento == horaFechamento);
            Assert.IsTrue(estabelecimento.PrecoMedio == precoMedio);
            Assert.IsTrue(estabelecimento.Fotos == listaFotos);
            Assert.IsTrue(estabelecimento.Aprovado == aprovado);
            Assert.IsTrue(estabelecimento.ValidarEntrada().Count == 1);
            Assert.IsTrue(estabelecimento.ValidarEntrada().Contains("Tamanho máximo 100 caracteres."));
        }



    }
}
