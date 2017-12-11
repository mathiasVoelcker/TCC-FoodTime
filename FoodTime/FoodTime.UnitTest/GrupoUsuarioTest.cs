using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoodTime.Dominio.Entidades;

namespace FoodTime.UnitTest
{
    [TestClass]
    public class GrupoUsuarioTest
    {
        [TestMethod]
        public void Testar_Inicializacao_De_GrupoUsuario()
        {
            GrupoUsuario grupoUsuario;

            Usuario usuario;
            var nome = "testeNome";
            var sobrenome = "testeSobrenome";
            var email = "teste@email.com";
            var senha = "testeSenha";
            var dataNascimento = new DateTime(2010, 8, 18);
            var fotoPerfil = "testeFotoPerfil";
            var isAdmin = true;

            usuario = new Usuario(email, senha, nome, sobrenome, fotoPerfil, dataNascimento, isAdmin, null, null);

            Grupo grupo;
            var nomeGrupo = "FoodTime";
            var imagem = "C:/Users/Usuario/AppData/Roaming/NVIDIA/GL/GLCache/hashs/3c823953fa783a6e3fa2343995e9093fa783a3fab95e3fa7895e3fa3885f995e3faa88c2a2/cb5d9093fa783a6725dc7b9b95e3fa7838/d9093fa783a6725dc73fa783a6b9b95e3fa/img.jpg";

            grupo = new Grupo(nomeGrupo, imagem);


            grupoUsuario = new GrupoUsuario(usuario, grupo, true);

            Assert.IsTrue(grupoUsuario.Usuario == usuario);
            Assert.IsTrue(grupoUsuario.Grupo == grupo);
            Assert.IsTrue(grupoUsuario.Aprovado == true);
        }

        [TestMethod]
        public void Testar_Validar_GrupoUsuario_Com_Usuario_Nulo()
        {
            GrupoUsuario grupoUsuario;
            Grupo grupo;
            var nomeGrupo = "FoodTime";
            var imagem = "C:/Users/Usuario/AppData/Roaming/NVIDIA/GL/GLCache/hashs/3c823953fa783a6e3fa2343995e9093fa783a3fab95e3fa7895e3fa3885f995e3faa88c2a2/cb5d9093fa783a6725dc7b9b95e3fa7838/d9093fa783a6725dc73fa783a6b9b95e3fa/img.jpg";

            grupo = new Grupo(nomeGrupo, imagem);

            grupoUsuario = new GrupoUsuario(null, grupo, true);

            Assert.IsTrue(grupoUsuario.ValidarEntrada().Count ==1);
            Assert.IsTrue(grupoUsuario.ValidarEntrada().Contains("Deve ter um Usuario vinculado."));
            Assert.IsTrue(grupoUsuario.Grupo == grupo);
            Assert.IsTrue(grupoUsuario.Aprovado == true);
        }

        [TestMethod]
        public void Testar_Validar_GrupoUsuario_Com_Grupo_Nulo()
        {
            GrupoUsuario grupoUsuario;

            Usuario usuario;
            var nome = "testeNome";
            var sobrenome = "testeSobrenome";
            var email = "teste@email.com";
            var senha = "testeSenha";
            var dataNascimento = new DateTime(2010, 8, 18);
            var fotoPerfil = "testeFotoPerfil";
            var isAdmin = true;

            usuario = new Usuario(email, senha, nome, sobrenome, fotoPerfil, dataNascimento, isAdmin, null, null);


            grupoUsuario = new GrupoUsuario(usuario, null, true);

            Assert.IsTrue(grupoUsuario.ValidarEntrada().Count == 1);
            Assert.IsTrue(grupoUsuario.ValidarEntrada().Contains("Deve ter um Grupo vinculado."));
            Assert.IsTrue(grupoUsuario.Usuario == usuario);
            Assert.IsTrue(grupoUsuario.Aprovado == true);
        }

    }
}
