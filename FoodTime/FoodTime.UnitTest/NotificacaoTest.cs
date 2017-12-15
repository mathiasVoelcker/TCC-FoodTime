using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoodTime.Dominio.Entidades;

namespace FoodTime.UnitTest
{

    [TestClass]
    public class NotificacaoTest
    {
        [TestMethod]
        public void Testar_Inicializacao_De_Notificacao()
        {
            Notificacao notificacao;

            Usuario usuario;
            var nome = "testeNome";
            var sobrenome = "testeSobrenome";
            var email = "teste@email.com";
            var senha = "testeSenha";
            var dataNascimento = new DateTime(2010, 8, 18);
            var fotoPerfil = "testeFotoPerfil";
            var isAdmin = true;

            usuario = new Usuario(email, senha, nome, sobrenome, fotoPerfil, dataNascimento, isAdmin, null);

            Grupo grupo;
            var nomeGrupo = "FoodTime";
            var imagem = "C:/Users/Usuario/AppData/Roaming/NVIDIA/GL/GLCache/hashs/3c823953fa783a6e3fa2343995e9093fa783a3fab95e3fa7895e3fa3885f995e3faa88c2a2/cb5d9093fa783a6725dc7b9b95e3fa7838/d9093fa783a6725dc73fa783a6b9b95e3fa/img.jpg";

            grupo = new Grupo(nomeGrupo, imagem);

            Endereco endereco = new Endereco("rua teste",  "numero teste",  "", "Centro", "Porto Alegre", "Rio Grande do Sul", "96508060", 15.0M, 15.0M);
            List<Categoria> listaCategorias = new List<Categoria>();
            List<Foto> listaFotos = new List<Foto>();
            Estabelecimento estabelecimento;
            var nomeEstabelecimento = "nome teste";
            var telefone = "telefone teste";
            DateTime horaFechamento = new DateTime().Date;
            DateTime horaAbertura = new DateTime().Date;
            decimal precoMedio = 14.0M;
            bool aprovado = true;

            estabelecimento = new Estabelecimento(nomeEstabelecimento, telefone, endereco, listaCategorias, horaAbertura, horaFechamento, precoMedio, listaFotos, aprovado);


            notificacao = new Notificacao(usuario, estabelecimento, grupo, true);

            Assert.IsTrue(notificacao.Usuario == usuario);
            Assert.IsTrue(notificacao.Estabelecimento == estabelecimento);
            Assert.IsTrue(notificacao.Grupo == grupo);
            Assert.IsTrue(notificacao.Visibilidade == true);
        }

        [TestMethod]
        public void Testar_Validar_Notificacao_Com_Usuario_Nulo()
        {
            Notificacao notificacao;
            Grupo grupo;
            var nomeGrupo = "FoodTime";
            var imagem = "C:/Users/Usuario/AppData/Roaming/NVIDIA/GL/GLCache/hashs/3c823953fa783a6e3fa2343995e9093fa783a3fab95e3fa7895e3fa3885f995e3faa88c2a2/cb5d9093fa783a6725dc7b9b95e3fa7838/d9093fa783a6725dc73fa783a6b9b95e3fa/img.jpg";

            grupo = new Grupo(nomeGrupo, imagem);

            Endereco endereco = new Endereco("rua teste",  "numero teste",  "", "Centro", "Porto Alegre", "Rio Grande do Sul", "96508060", 15.0M, 15.0M);
            List<Categoria> listaCategorias = new List<Categoria>();
            List<Foto> listaFotos = new List<Foto>();
            Estabelecimento estabelecimento;
            var nomeEstabelecimento = "nome teste";
            var telefone = "telefone teste";
            DateTime horaFechamento = new DateTime().Date;
            DateTime horaAbertura = new DateTime().Date;
            decimal precoMedio = 14.0M;
            bool aprovado = true;

            estabelecimento = new Estabelecimento(nomeEstabelecimento, telefone, endereco, listaCategorias, horaAbertura, horaFechamento, precoMedio, listaFotos, aprovado);
            notificacao = new Notificacao(null, estabelecimento, grupo, true);

            Assert.IsTrue(notificacao.ValidarEntrada().Count == 1);
            Assert.IsTrue(notificacao.ValidarEntrada().Contains("Deve ter um Usuario vinculado."));
            Assert.IsTrue(notificacao.Estabelecimento == estabelecimento);
            Assert.IsTrue(notificacao.Grupo == grupo);
            Assert.IsTrue(notificacao.Visibilidade == true);
        }

        [TestMethod]
        public void Testar_Validar_Notificacao_Com_EstabelecimentoEGrupo_Nulo()
        {
            Notificacao notificacao;

            Usuario usuario;
            var nome = "testeNome";
            var sobrenome = "testeSobrenome";
            var email = "teste@email.com";
            var senha = "testeSenha";
            var dataNascimento = new DateTime(2010, 8, 18);
            var fotoPerfil = "testeFotoPerfil";
            var isAdmin = true;

            usuario = new Usuario(email, senha, nome, sobrenome, fotoPerfil, dataNascimento, isAdmin, null);
  
            notificacao = new Notificacao(usuario, null, null, true);

            Assert.IsTrue(notificacao.Usuario == usuario);
            Assert.IsTrue(notificacao.ValidarEntrada().Count == 1);
            Assert.IsTrue(notificacao.ValidarEntrada().Contains("Deve ter um Grupo ou um estabelecimento vinculado."));
            Assert.IsTrue(notificacao.Visibilidade == true);
        }

        [TestMethod]
        public void Testar_Validar_Notificacao_Com_Grupo_Nulo()
        {
            Notificacao notificacao;

            Usuario usuario;
            var nome = "testeNome";
            var sobrenome = "testeSobrenome";
            var email = "teste@email.com";
            var senha = "testeSenha";
            var dataNascimento = new DateTime(2010, 8, 18);
            var fotoPerfil = "testeFotoPerfil";
            var isAdmin = true;

            usuario = new Usuario(email, senha, nome, sobrenome, fotoPerfil, dataNascimento, isAdmin, null);


            Endereco endereco = new Endereco("rua teste",  "numero teste",  "", "Centro", "Porto Alegre", "Rio Grande do Sul", "96508060", 15.0M, 15.0M);
            List<Categoria> listaCategorias = new List<Categoria>();
            List<Foto> listaFotos = new List<Foto>();
            Estabelecimento estabelecimento;
            var nomeEstabelecimento = "nome teste";
            var telefone = "telefone teste";
            DateTime horaFechamento = new DateTime().Date;
            DateTime horaAbertura = new DateTime().Date;
            decimal precoMedio = 14.0M;
            bool aprovado = true;

            estabelecimento = new Estabelecimento(nomeEstabelecimento, telefone, endereco, listaCategorias, horaAbertura, horaFechamento, precoMedio, listaFotos, aprovado);
            notificacao = new Notificacao(usuario, estabelecimento, null, true);

            Assert.IsTrue(notificacao.Grupo == null);
            Assert.IsTrue(notificacao.Estabelecimento == estabelecimento);
            Assert.IsTrue(notificacao.Visibilidade == true);
        }

        [TestMethod]
        public void Testar_Validar_Notificacao_Com_Estabelecimento_Nulo()
        {
            Notificacao notificacao;

            Usuario usuario;
            var nome = "testeNome";
            var sobrenome = "testeSobrenome";
            var email = "teste@email.com";
            var senha = "testeSenha";
            var dataNascimento = new DateTime(2010, 8, 18);
            var fotoPerfil = "testeFotoPerfil";
            var isAdmin = true;

            usuario = new Usuario(email, senha, nome, sobrenome, fotoPerfil, dataNascimento, isAdmin, null);

            Grupo grupo;
            var nomeGrupo = "FoodTime";
            var imagem = "C:/Users/Usuario/AppData/Roaming/NVIDIA/GL/GLCache/hashs/3c823953fa783a6e3fa2343995e9093fa783a3fab95e3fa7895e3fa3885f995e3faa88c2a2/cb5d9093fa783a6725dc7b9b95e3fa7838/d9093fa783a6725dc73fa783a6b9b95e3fa/img.jpg";

            grupo = new Grupo(nomeGrupo, imagem);

            notificacao = new Notificacao(usuario, null, grupo, true);

            Assert.IsTrue(notificacao.Grupo == grupo);
            Assert.IsTrue(notificacao.Estabelecimento == null);
            Assert.IsTrue(notificacao.Visibilidade == true);
        }
    }
}
