using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Dominio.Entidades
{
    public class Foto
    {
        public Foto(string caminho)
        {
            Caminho = caminho;
            
        }

        protected Foto()
        {
        }

        public int Id { get; private set; }
        public string Caminho { get; private set; }

        public List<string> ValidarEntrada()
        {
            List<string> mensagens = new List<string>();

            if (string.IsNullOrWhiteSpace(Caminho))
                mensagens.Add("Caminho não pode ser nulo.");

            if (Caminho.Length > 200)
                mensagens.Add("O tamanho máximo são 200 caracteres.");


            

            return mensagens;
        }
    }
}
