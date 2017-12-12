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
            var foto = "C:/Users/Usuario/AppData/Roaming/NVIDIA/GL/GLCache/hashs/3c823953fa783a6e3fa2343995e9093fa783a3fab95e3fa7895e3fa3885f995e3faa88c2a2/cb5d9093fa783a6725dc7b9b95e3fa7838/d9093fa783a6725dc73fa783a6b9b95e3fa/img.jpg";

            grupo = new Grupo(nome, foto);

            Assert.IsTrue(grupo.Nome == nome);
            Assert.IsTrue(grupo.Foto == foto);
        }

        [TestMethod]
        public void Testar_Validar_Grupo_Com_Nome_Maior()
        {
            Grupo grupo;

            var nome = "Usando llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun";
            var foto = "C:/Users/Usuario/AppData/Roaming/NVIDIA/GL/GLCache/hashs/3c823953fa783a6e3fa2343995e9093fa783a3fab95e3fa7895e3fa3885f995e3faa88c2a2/cb5d9093fa783a6725dc7b9b95e3fa7838/d9093fa783a6725dc73fa783a6b9b95e3fa/img.jpg";
            
            grupo = new Grupo(nome, foto);

            Assert.IsTrue(grupo.Nome == nome);
            Assert.IsTrue(grupo.Foto == foto);
            Assert.IsTrue(grupo.ValidarEntrada().Count == 1);
        }

        [TestMethod]
        public void Testar_Validar_Grupo_Com_Nome_Nulo()
        {
            Grupo grupo;
            var nome = "";
            var foto = "C:/Users/Usuario/AppData/Roaming/NVIDIA/GL/GLCache/hashs/3c823953fa783a6e3fa2343995e9093fa783a3fab95e3fa7895e3fa3885f995e3faa88c2a2/cb5d9093fa783a6725dc7b9b95e3fa7838/d9093fa783a6725dc73fa783a6b9b95e3fa/img.jpg";

            grupo = new Grupo(nome, foto);

            Assert.IsTrue(grupo.ValidarEntrada().Count == 1);
            Assert.IsTrue(grupo.Foto == foto);
            Assert.IsTrue(grupo.ValidarEntrada().Contains("Nome não pode ser nulo."));

        }

        [TestMethod]
        public void Testar_Validar_Grupo_Com_Foto_Maior()
        {
            Grupo grupo;
            var nome = "Usando llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun";
            var foto = "C:/Users/Usuario/AppData/Roaming/NVIDIA/GL/GLCache/hashs/3c823953fa783a6e3fa2343995e9093fa783a3fab95e3fa7895e3fa3885f995e3faa88c2a2/cb5d9093fa783a6725dc7b9b95e3fa7838/d9093fa783a6725dc73fa783a6b9b95e3fa/3c823953fa783a6e3fa2343995e9093fa783a3fab95e3fa7895e3fa3885f995e3faa88c2a2/3c823953fa783a6e3fa2343995e9093fa783a3fab95e3fa7895e3fa3885f995e3faa88c2a2/3c823953fa783a6e3fa2343995e9093fa783a3fab95e3fa7895e3fa3885f995e3faa88c2a2/3c823953fa783a6e3fa2343995e9093fa783a3fab95e3fa7895e3fa3885f995e3faa88c2a2/3c823953fa783a6e3fa2343995e9093fa783a3fab95e3fa7895e3fa3885f995e3faa88c2a2/img.jpg";

            grupo = new Grupo(nome, foto);
            Assert.IsTrue(grupo.Nome == nome);
            Assert.IsTrue(grupo.ValidarEntrada().Contains("O tamanho máximo são 500 caracteres."));
        }

        [TestMethod]
        public void Testar_Validar_Grupo_Com_Foto_Nula()
        {
            Grupo grupo;
            var nome = "Usando llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun llorem ipsun";
            var foto = "";

            grupo = new Grupo(nome, foto);

            Assert.IsTrue(grupo.Nome == nome);
            Assert.IsTrue(grupo.ValidarEntrada().Contains("Foto não pode ser nula."));

        }

    }
}
