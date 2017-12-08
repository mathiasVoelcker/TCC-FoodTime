﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoodTime.Dominio.Entidades;

namespace FoodTime.UnitTest
{
    [TestClass]
    public class UsuarioTest
    {
        [TestMethod]
        public void Testar_Inicializacao_De_Usuario()
        {
            Usuario usuario;
            var nome = "testeNome";
            var sobrenome = "testeSobrenome";
            var email = "teste@email.com";
            var senha = "testeSenha";
            var dataNascimento = new DateTime(2010, 8, 18);
            var fotoPerfil = "testeFotoPerfil";
            var isAdmin = true;

            usuario = new Usuario(email, senha, nome, sobrenome, fotoPerfil, dataNascimento, isAdmin);

            Assert.IsTrue(usuario.Email == email);
            //Assert.IsTrue(usuario.Senha == senha);
            Assert.IsTrue(usuario.Nome == nome);
            Assert.IsTrue(usuario.Sobrenome == sobrenome);
            Assert.IsTrue(usuario.FotoPerfil == fotoPerfil);
            Assert.IsTrue(usuario.DataNascimento == dataNascimento);
            Assert.IsTrue(usuario.Admin == isAdmin);
        }
        [TestMethod]
        public void Testar_ValidarSenha()
        {
            Usuario usuario;
            var nome = "testeNome";
            var sobrenome = "testeSobrenome";
            var email = "teste@email.com";
            var senha = "testeSenha";
            var dataNascimento = new DateTime(2010, 8, 18);
            var fotoPerfil = "testeFotoPerfil";
            var isAdmin = true;

            usuario = new Usuario(email, senha, nome, sobrenome, fotoPerfil, dataNascimento, isAdmin);

            Assert.IsTrue(usuario.ValidarSenha(senha));
        }
    }
}