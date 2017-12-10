using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Dominio.Entidades
{
    public class Categoria
    {
        public Categoria(string descricao)
        {
            Descricao = descricao;
        }

        protected Categoria()
        {
        }

        public int Id { get; private set; }

        public string Descricao { get; private set; }

        public List<string> ValidarEntrada()
        {
            List<string> mensagens = new List<string>();

            if (string.IsNullOrWhiteSpace(Descricao))
                mensagens.Add("Descricao não pode ser nulo.");

            if (Descricao.Length>50)
                mensagens.Add("O tamanho máximo são 50 caracteres.");

            return mensagens;
        }
    }
}
