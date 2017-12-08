using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoodTime.Dominio.Entidades;

namespace FoodTime.UnitTest
{
    [TestClass]
    public class FotoTest
    {
        [TestMethod]
        public void Testar_Inicializacao_De_Foto()
        {
            Foto foto;
            var caminho = "C:/Users/Administrador/Pictures";
           
            foto = new Foto(caminho);

            Assert.IsTrue(foto.Caminho == caminho);
            Assert.IsTrue(foto.ValidarEntrada().Count==0);
        }

        [TestMethod]
        public void Testar_Validar_Foto_Com_Caminho_Maior()
        {
            Foto foto;
            var caminho = "C:/Users/Usuario/AppData/Roaming/NVIDIA/GL/GLCache/hashs/3c823953fa783a6e3fa2343995e9093fa783a3fab95e3fa7895e3fa3885f995e3faa88c2a2/cb5d9093fa783a6725dc7b9b95e3fa7838/d9093fa783a6725dc73fa783a6b9b95e3fa/img.jpg";

            foto = new Foto(caminho);

            Assert.IsTrue(foto.ValidarEntrada().Count == 1);
            Assert.IsTrue(foto.ValidarEntrada().Contains("O tamanho máximo são 200 caracteres."));
        }

        [TestMethod]
        public void Testar_Validar_Foto_Com_Caminho_Nulo()
        {
            Foto foto;
            var caminho = "";

            foto = new Foto(caminho);

            Assert.IsTrue(foto.ValidarEntrada().Count == 1);
            Assert.IsTrue(foto.ValidarEntrada().Contains("Caminho não pode ser nulo."));
        }
    }
}
