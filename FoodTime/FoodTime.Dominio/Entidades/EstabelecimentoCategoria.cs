using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Dominio.Entidades
{
    public class EstabelecimentoCategoria
    {
        public EstabelecimentoCategoria(Estabelecimento estabelecimento, Categoria categoria)
        {
            Estabelecimento = estabelecimento;
            Categoria = categoria;
        }

        protected EstabelecimentoCategoria()
        {
        }

        public int Id { get; private set; }

        public Estabelecimento Estabelecimento { get; private set; }
        public Categoria Categoria { get; private set; }

        public List<string> ValidarEntrada()
        {
            List<string> mensagens = new List<string>();

            if (Estabelecimento == null)
                mensagens.Add("Deve conter um Estabelecimento vinculado.");

            if (Categoria == null)
                mensagens.Add("Deve conter uma Categoria vinculada.");

            return mensagens;
        }
    }
}
