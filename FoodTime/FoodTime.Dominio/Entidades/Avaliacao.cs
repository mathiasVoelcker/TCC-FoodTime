using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Dominio.Entidades
{
    public class Avaliacao
    {
        public Avaliacao(int nota, decimal precoMedio, string comentario, string fotoAvaliacao, bool recomendado, DateTime dataAvaliacao, Usuario usuario, Estabelecimento estabelecimento)
        {
            Nota = nota;
            PrecoMedio = precoMedio;
            Comentario = comentario;
            FotoAvaliacao = fotoAvaliacao;
            Recomendado = recomendado;
            DataAvaliacao = dataAvaliacao;
            Usuario = usuario;
            Estabelecimento = estabelecimento;
        }

        protected Avaliacao()
        {
        }

        public int Id { get; private set; }
        public int Nota { get; private set; }
        public decimal PrecoMedio { get; private set; }
        public string Comentario { get; private set; }
        public string FotoAvaliacao { get; private set; }
        public bool Recomendado { get; private set; }
        public DateTime DataAvaliacao { get; private set; }
        public Usuario Usuario { get; private set; }
        public Estabelecimento Estabelecimento { get; private set; }

        public List<string> ValidarEntrada()
        {
            List<string> mensagens = new List<string>();

            if (this.Nota > 10)
                mensagens.Add("Nota não pode ser maior que 10.");

            if (this.Nota < 0)
                mensagens.Add("Nota não pode ser menor que 0.");

            if (this.PrecoMedio < 0)
                mensagens.Add("Preço médio não pode ser negativo.");

            if (Comentario.Length > 500)
                mensagens.Add("O comentário não pode ter mais de 500 caracteres.");

            if (string.IsNullOrWhiteSpace(Comentario))
                mensagens.Add("Comentário não pode ser nulo.");

            return mensagens;
        }
    }

}
