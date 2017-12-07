using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Dominio.Entidades
{
    public class EstabelecimentoFotos
    {
        public EstabelecimentoFotos(string foto, int idUsuario)
        {
            Foto = foto;
            IdUsuario = idUsuario;
        }

        protected EstabelecimentoFotos()
        {
        }

        public int Id { get; private set; }
        public string Foto { get; private set; }
        public int IdUsuario { get; private set; }

        public List<string> ValidarEntrada()
        {
            List<string> mensagens = new List<string>();

            if (string.IsNullOrWhiteSpace(Foto))
                mensagens.Add("Foto não pode ser nulo.");

            if (Foto.Length > 500)
                mensagens.Add("O tamanho máximo são 500 caracteres.");

            if (IdUsuario==0)
                mensagens.Add("A foto deve conter um Usuário atrelado a ela.");

            return mensagens;
        }
    }
}
