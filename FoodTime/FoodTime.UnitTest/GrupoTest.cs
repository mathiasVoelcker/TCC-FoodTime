using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoodTime.Dominio.Entidades;

namespace FoodTime.UnitTest
{
    [TestClass]
    public class GrupoTest
    {
        [TestMethod]
        public void Testar_Inicializacao_De_Grupo()
        {
            Grupo grupo;
            var nome = "FoodTime";
            var imagem = "C:/Users/Usuario/AppData/Roaming/NVIDIA/GL/GLCache/hashs/3c823953fa783a6e3fa2343995e9093fa783a3fab95e3fa7895e3fa3885f995e3faa88c2a2/cb5d9093fa783a6725dc7b9b95e3fa7838/d9093fa783a6725dc73fa783a6b9b95e3fa/img.jpg";

            grupo = new Grupo(nome, imagem);

            Assert.IsTrue(grupo.Nome == nome);
            Assert.IsTrue(grupo.Imagem == imagem);
        }

        [TestMethod]
        public void Testar_Validar_Grupo_Com_Nome_Maior()
        {
            Grupo grupo;

            var nome = "Usando llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun";
            var imagem = "C:/Users/Usuario/AppData/Roaming/NVIDIA/GL/GLCache/hashs/3c823953fa783a6e3fa2343995e9093fa783a3fab95e3fa7895e3fa3885f995e3faa88c2a2/cb5d9093fa783a6725dc7b9b95e3fa7838/d9093fa783a6725dc73fa783a6b9b95e3fa/img.jpg";
            
            grupo = new Grupo(nome, imagem);

            Assert.IsTrue(grupo.Nome == nome);
            Assert.IsTrue(grupo.Imagem == imagem);
            Assert.IsTrue(grupo.ValidarEntrada().Count == 1);
        }

        [TestMethod]
        public void Testar_Validar_Grupo_Com_Nome_Nulo()
        {
            Grupo grupo;
            var nome = "";
            var imagem = "C:/Users/Usuario/AppData/Roaming/NVIDIA/GL/GLCache/hashs/3c823953fa783a6e3fa2343995e9093fa783a3fab95e3fa7895e3fa3885f995e3faa88c2a2/cb5d9093fa783a6725dc7b9b95e3fa7838/d9093fa783a6725dc73fa783a6b9b95e3fa/img.jpg";

            grupo = new Grupo(nome, imagem);

            Assert.IsTrue(grupo.ValidarEntrada().Count == 1);
            Assert.IsTrue(grupo.Imagem == imagem);
            Assert.IsTrue(grupo.ValidarEntrada().Contains("Nome não pode ser nulo."));

        }

        [TestMethod]
        public void Testar_Validar_Grupo_Com_Imagem_Maior()
        {
            Grupo grupo;
            var nome = "Usando llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun";
            var imagem = "C:/Users/Usuario/AppData/Roaming/NVIDIA/GL/GLCache/hashs/3c823953fa783a6e3fa2343995e9093fa783a3fab95e3fa7895e3fa3885f995e3faa88c2a2/cb5d9093fa783a6725dc7b9b95e3fa7838/d9093fa783a6725dc73fa783a6b9b95e3fa/3c823953fa783a6e3fa2343995e9093fa783a3fab95e3fa7895e3fa3885f995e3faa88c2a2/3c823953fa783a6e3fa2343995e9093fa783a3fab95e3fa7895e3fa3885f995e3faa88c2a2/3c823953fa783a6e3fa2343995e9093fa783a3fab95e3fa7895e3fa3885f995e3faa88c2a2/3c823953fa783a6e3fa2343995e9093fa783a3fab95e3fa7895e3fa3885f995e3faa88c2a2/3c823953fa783a6e3fa2343995e9093fa783a3fab95e3fa7895e3fa3885f995e3faa88c2a2/img.jpg";

            grupo = new Grupo(nome, imagem);
            Assert.IsTrue(grupo.Nome == nome);
            Assert.IsTrue(grupo.ValidarEntrada().Contains("O tamanho máximo são 500 caracteres."));
        }

        [TestMethod]
        public void Testar_Validar_Grupo_Com_Imagem_Nula()
        {
            Grupo grupo;
            var nome = "Usando llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun";
            var imagem = "";

            grupo = new Grupo(nome, imagem);

            Assert.IsTrue(grupo.Nome == nome);
            Assert.IsTrue(grupo.ValidarEntrada().Contains("Imagem não pode ser nula."));

        }

    }
}
