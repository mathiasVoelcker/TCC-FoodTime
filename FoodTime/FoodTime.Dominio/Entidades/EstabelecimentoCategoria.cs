using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Dominio.Entidades
{
    public class EstabelecimentoCategoria
    {
        public EstabelecimentoCategoria(int idEstabelecimento, int idCategoria)
        {
            IdEstabelecimento = idEstabelecimento;
            IdCategoria = idCategoria;
        }

        protected EstabelecimentoCategoria()
        {
        }

        public int Id { get; private set; }

        public int IdEstabelecimento { get; private set; }
        public int IdCategoria { get; private set; }

        public List<string> ValidarEntrada()
        {
            List<string> mensagens = new List<string>();

            if (IdEstabelecimento == 0)
                mensagens.Add("Deve conter um Estabelecimento vinculado.");

            if (IdCategoria == 0)
                mensagens.Add("Deve conter uma Categoria vinculada.");

            return mensagens;
        }
    }
}
