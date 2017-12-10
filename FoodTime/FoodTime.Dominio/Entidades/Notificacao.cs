using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Dominio.Entidades
{
    public class Notificacao
    {
        public Notificacao(Usuario usuario, Estabelecimento estabelecimento, Grupo grupo, bool visibilidade)
        {
            Usuario = usuario;
            Estabelecimento = estabelecimento;
            Grupo = grupo;
            Visibilidade = visibilidade;
        }

        protected Notificacao()
        {
        }

        public int Id { get; private set; }
        public Usuario Usuario { get; private set; }
        public Estabelecimento Estabelecimento { get; private set; }
        public Grupo Grupo { get; private set; }
        public bool Visibilidade { get; private set; }       
       

        public List<string> ValidarEntrada()
        {
            List<string> mensagens = new List<string>();

            if (Usuario == null)
                mensagens.Add("Deve ter um Usuario vinculado.");

            if (Estabelecimento == null)
                mensagens.Add("Deve ter um Estabelecimento vinculado.");

            if (Grupo == null)
                mensagens.Add("Deve ter um Grupo vinculado.");

            return mensagens;
        }



    }
}
