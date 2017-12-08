using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Dominio.Entidades
{
    public class EstabelecimentoPreferencia
    {

        public EstabelecimentoPreferencia(Estabelecimento estabelecimento, Preferencia preferencia, Boolean aprovado)
        {
            Preferencia = preferencia;
            Estabelecimento = estabelecimento;
            Aprovado = aprovado;
        }

        protected EstabelecimentoPreferencia()
        {
        }

        public int Id { get; private set; }

        public Preferencia Preferencia { get; private set; }
        public Estabelecimento Estabelecimento { get; private set; }
        public Boolean Aprovado { get; private set; }

        public List<string> ValidarEntrada()
        {
            List<string> mensagens = new List<string>();

            if (Preferencia==null)
                mensagens.Add("Deve ter uma Preferencia vinculada.");

            if (Estabelecimento==null)
                mensagens.Add("Deve ter um Estabelecimento vinculada.");

            return mensagens;
        }
    }
}
